using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Texture2D;

public class FlagPathManager : MonoBehaviour
{
    public delegate void Del();
    private Del mDel = null;
    public Del MDel
    {
        set { mDel = value; }
    }
    [SerializeField] private PathFinder pathFinder = null;
    [SerializeField] private GUIPathList guiPathList = null;
    [SerializeField] public Flag startFlag = null; // getter
    [SerializeField] public Flag endFlag = null;    // setter

    private Flag curFlag = null;
    private Flag[] nearFlagList = null;
    private Flag[] totalFlag = null;
    private List<int> prev = new List<int>(); // 각 요소(플래그 번호) 직전 노드
    private List<float> cost = new List<float>(); // Distance
    private List<bool> visited = new List<bool>();
    public List<Flag> pathList = new List<Flag>();

    //private Dictionary<int, float> costOfEachFlag = new Dictionary<int, float>();

    private void Awake()
    {
        totalFlag = GetComponentsInChildren<Flag>();
    }

    private void Start()
    {
        //InitCostList();
        curFlag = startFlag;
        PathFinding(startFlag, endFlag);
    }

    private void InitList(Flag _startFlag)
    {
        int i = 0;
        int totalLen = totalFlag.Length;
        int startFlagIdx = _startFlag.GetNumber() - 1;
        for (; i < totalLen; ++i)
        {
            prev.Add(-1);
            cost.Add(float.MaxValue);
            visited.Add(false);
        }
        prev[startFlagIdx] = startFlagIdx;
        cost[startFlagIdx] = 0;
        visited[startFlagIdx] = true;
        //Debug.Log(string.Join(", ", prev));
        //Debug.Log(string.Join(", ", cost));
    }

    // startFlag에서 출발했을 때 각 Flag까지의 최적 경로를 찾아 반환함
    // 각 부분 함수로 만들어 따로 빼는 작업 해야함
    public List<Flag> PathFinding(Flag _startFlag, Flag _endFlag)
    {
        InitList(_startFlag);
        float dist;
        float totalDist;
        int nearFlagIdx;
        int nextFlagIdx;
        int visitStatus = 0;
        int cur = curFlag.GetNumber() - 1;
        int i = 0;
        while (true)
        {
            if (visitStatus >= totalFlag.Length) break;
            Debug.Log("while 시작!!!!!!!!!!!!!!!");
            nearFlagList = curFlag.GetNearFlag();
            Debug.Log("curFlagIdx: " + cur + ", nearFlagListLen: " + nearFlagList.Length);
            for (; i < nearFlagList.Length; ++i)
            {
                nearFlagIdx = nearFlagList[i].GetNumber() - 1;
                if (!visited[nearFlagIdx])
                {
                    dist = CalculateFlagsDistance(curFlag, nearFlagList[i]);
                    Debug.Log("cruFlag: " + curFlag + ", nearFlagList[" + i + "]: " + nearFlagList[i] + "dist: " + dist);
                    totalDist = dist + cost[cur];
                    Debug.Log("cost[" + nearFlagIdx + "] : " + cost[nearFlagIdx] + ", totalDist: " + totalDist + " totalDist!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    if (totalDist < cost[nearFlagIdx]) // 지금 해당 플래그(인덱스) 위치에 저장되어 있는 cost보다 dist가 작을 경우
                    {
                        cost[nearFlagIdx] = totalDist; // cost 배열에 현재 플래그에서 다음 플래그까지의 거리를 저장
                        prev[nearFlagIdx] = cur; // 현재 플래그에서 다음 플래그에 가는 가장 짧은 길을 위해 직전에 거쳐간 플래그를 저장
                        Debug.Log("cost[nearFlagIdx]: " + "nearFlagIdx: " + nearFlagIdx + " : " + cost[nearFlagIdx] + "cost 갱신됨");
                    }
                }
            }
            i = 0;
             Debug.Log("cost: " + string.Join(", ", cost) + " COST!!!!!!!!!!!!!!!");
             Debug.Log("prev: " + string.Join(", ", prev) + " PREV!!!!!!!!!!!!!!!");
            if (curFlag.GetNumber() == endFlag.GetNumber()) break;
            Debug.Log("curFlag: "+curFlag);
            nextFlagIdx = FindMinCostIdx(nearFlagList, cost);
            curFlag = totalFlag[nextFlagIdx];
            visited[nextFlagIdx] = true;
            visitStatus++;
            cur = curFlag.GetNumber() - 1;
             Debug.Log("nextFlagIdx: " + nextFlagIdx + ", nextFlag: " + totalFlag[nextFlagIdx]+ " NEXTFLAG!!!!!!!!!!!!!!!!! !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
             Debug.Log("cur: "+cur+", totalFlag[cur]: " + totalFlag[cur]);
        }
        pathList = MakePathList(prev, _startFlag, _endFlag);
        mDel?.Invoke();
        return pathList;
    }

    // flag와 flag 사이의 거리를 반환함
    private float CalculateFlagsDistance(Flag _curFlag, Flag _nextFlag)
    {
        float distance = Vector3.Distance(GetFlagPosition(_curFlag), GetFlagPosition(_nextFlag));
        return distance;
    }

    // nearFlagList에서 아직 최적 경로를 찾지 못한 Flag 중 현재 Flag에서 가장 가까운 Flag의 인덱스를 반환함
    private int FindMinCostIdx(Flag[] _nearList, List<float> _cost)
    {
        float minCost = float.MaxValue;
        int minCostIdx = 0;
        int nearListidx;
        for (int flags = 0; flags < _nearList.Length; ++flags)
        {
            nearListidx = _nearList[flags].GetNumber() - 1;
            Debug.Log("nearListidx: " + nearListidx + ", cost[nearListidx]: " + cost[nearListidx]);
            if (!visited[nearListidx] && cost[nearListidx] < minCost)
            {
                minCost = cost[nearListidx];
                minCostIdx = nearListidx;
            }
        }
        Debug.Log("final: " + string.Join(", ", visited));
        return minCostIdx;
    }

    // PathFinding에서 반환된 startFlag에서 출발하는 모든 flag의 최적 경로 리스트 중 startFlag에서 endFlag까지의 경로 리스트만 뽑아냄
    private List<Flag> MakePathList(List<int> _prevList,Flag _startFlag, Flag _endFlag)
    {
        List<Flag> pathList = new List<Flag>();
        int endFlagIdx = _endFlag.GetNumber() - 1;
        Debug.Log("prev!!!!!! 이제 pathList 만들어야함"+string.Join(", ", _prevList));
        int i = endFlagIdx;
        pathList.Add(totalFlag[i]);
        while (i >= 0) {
            if (totalFlag[i].GetNumber() == _startFlag.GetNumber() || i <= 0) break;
            pathList.Add(totalFlag[_prevList[i]]);
            Debug.Log("totalFlag[_prevList["+i+"]: " + totalFlag[_prevList[i]]);
            Debug.Log("_prevList["+i+"]: " + _prevList[i]);
            i = _prevList[i];
        }
        pathList.Reverse();
        Debug.Log(string.Join(", ", pathList));
        
        return pathList;
    }

    // startFlag - endFlag 최적 경로 배열 안에 있는 각 flag의 position을 반환함
    public Vector3 GetFlagPosition(Flag _flag){
        Vector3 flagPosition = _flag.transform.position;
        return flagPosition;
    }

    public List<Flag> GetPathList() {
        Debug.Log(string.Join(", ", pathList));
        return pathList;
    }


    /*  /// 두번째 시도. nextFlag 찾는 알고리즘. 실패!!

        private void InitCostList() { 
            for (int i = 0; i < totalFlag.Length; ++i) {
                costOfEachFlag.Add(totalFlag[i].GetNumber()-1, float.MaxValue);
            }
        }

        public Flag[] PathFinding(Flag _curFlag, Flag _endFlag)
        {
            if (startFlag == null || endFlag == null) return null;
            nearFlagList = _curFlag.GetNearFlag(); 
            int nextFlagNumber;
            float cost;

            int i = 0;
            while (true) {
                if (nearFlagList[i].GetVisitStatus())
                {
                    i++;
                    continue;
                }
                if (i >= nearFlagList.Length || CompareEndFlag(nearFlagList[i], endFlag)) { 
                    break;
                }
                nextFlagNumber = nearFlagList[i].GetNumber();
                cost = CalculateFlagsDistance(curFlag, nearFlagList[i]);
                if (costOfEachFlag[nextFlagNumber] >= cost)
                {
                    AddCostList(costOfEachFlag, nextFlagNumber, cost);
                    pathList.Add(curFlag);
                    //nextFlag = nearFlagList[i];
                    curFlag = nearFlagList[i];
                }
                PathFinding(nextFlag, endFlag);
                Debug.LogFormat("curFlag: {0}", curFlag, "nearFlag[{1}]", nearFlagList[i], "nextFlag: {}", nextFlag);
                foreach (KeyValuePair<int, float> item in costOfEachFlag)
                {
                    Console.WriteLine("costList Key: {0} cost: {1}", item.Key, item.Value);
                }

                i++;
            }
            return null;
        }*/
    /*    private void AddCostList(Dictionary<int, float> _costList, int _flagNum, float _cost)
    {
        _costList[_flagNum] += _cost;
    }
*/

    /*    // 첫 시도. nearFlag와 endFlag 중 중복되는 Flag를 찾고 존재한다면 해당 플래그로 이동./ 실패!!!
        private int GetNearFlagLen(Flag _flag)
        {
            Flag[] nearFlags = _flag.GetNearFlag();
            int nearFlagLen = nearFlags.Length;
            return nearFlagLen;
        }

        public void FindDuplicationNextFlag()
        { // nextFlag를 전역으로 때려넣을지 return 해주고 쓸때마다 지역으로 만들어서 받아쓸지?
            int NearEndFlagLen = GetNearFlagLen(endFlag);
            int NearCurFlagLen = GetNearFlagLen(curFlag);
            for (int i = 0; i < NearCurFlagLen; ++i)
            {
                Debug.Log("end" + endFlag.GetNearFlag()[i]);
                Debug.Log("cur" + curFlag.GetNearFlag()[i]);
                if (curFlag.GetNearFlag()[i] == endFlag)
                {
                    nextFlag = endFlag;
                    return;
                }
                for (int j = 0; j < NearEndFlagLen; ++j)
                {
                    if (curFlag.GetNearFlag()[i] == endFlag.GetNearFlag()[j])
                    {
                        nextFlag = curFlag.GetNearFlag()[i];
                        Debug.Log("nextFlag:" + nextFlag);
                        return;
                    }
                }
            }
        }*/

}

