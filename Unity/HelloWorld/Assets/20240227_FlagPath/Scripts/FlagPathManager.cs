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
    private List<int> prev = new List<int>(); // �� ���(�÷��� ��ȣ) ���� ���
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

    // startFlag���� ������� �� �� Flag������ ���� ��θ� ã�� ��ȯ��
    // �� �κ� �Լ��� ����� ���� ���� �۾� �ؾ���
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
            Debug.Log("while ����!!!!!!!!!!!!!!!");
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
                    if (totalDist < cost[nearFlagIdx]) // ���� �ش� �÷���(�ε���) ��ġ�� ����Ǿ� �ִ� cost���� dist�� ���� ���
                    {
                        cost[nearFlagIdx] = totalDist; // cost �迭�� ���� �÷��׿��� ���� �÷��ױ����� �Ÿ��� ����
                        prev[nearFlagIdx] = cur; // ���� �÷��׿��� ���� �÷��׿� ���� ���� ª�� ���� ���� ������ ���İ� �÷��׸� ����
                        Debug.Log("cost[nearFlagIdx]: " + "nearFlagIdx: " + nearFlagIdx + " : " + cost[nearFlagIdx] + "cost ���ŵ�");
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

    // flag�� flag ������ �Ÿ��� ��ȯ��
    private float CalculateFlagsDistance(Flag _curFlag, Flag _nextFlag)
    {
        float distance = Vector3.Distance(GetFlagPosition(_curFlag), GetFlagPosition(_nextFlag));
        return distance;
    }

    // nearFlagList���� ���� ���� ��θ� ã�� ���� Flag �� ���� Flag���� ���� ����� Flag�� �ε����� ��ȯ��
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

    // PathFinding���� ��ȯ�� startFlag���� ����ϴ� ��� flag�� ���� ��� ����Ʈ �� startFlag���� endFlag������ ��� ����Ʈ�� �̾Ƴ�
    private List<Flag> MakePathList(List<int> _prevList,Flag _startFlag, Flag _endFlag)
    {
        List<Flag> pathList = new List<Flag>();
        int endFlagIdx = _endFlag.GetNumber() - 1;
        Debug.Log("prev!!!!!! ���� pathList ��������"+string.Join(", ", _prevList));
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

    // startFlag - endFlag ���� ��� �迭 �ȿ� �ִ� �� flag�� position�� ��ȯ��
    public Vector3 GetFlagPosition(Flag _flag){
        Vector3 flagPosition = _flag.transform.position;
        return flagPosition;
    }

    public List<Flag> GetPathList() {
        Debug.Log(string.Join(", ", pathList));
        return pathList;
    }


    /*  /// �ι�° �õ�. nextFlag ã�� �˰���. ����!!

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

    /*    // ù �õ�. nearFlag�� endFlag �� �ߺ��Ǵ� Flag�� ã�� �����Ѵٸ� �ش� �÷��׷� �̵�./ ����!!!
        private int GetNearFlagLen(Flag _flag)
        {
            Flag[] nearFlags = _flag.GetNearFlag();
            int nearFlagLen = nearFlags.Length;
            return nearFlagLen;
        }

        public void FindDuplicationNextFlag()
        { // nextFlag�� �������� ���������� return ���ְ� �������� �������� ���� �޾ƾ���?
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

