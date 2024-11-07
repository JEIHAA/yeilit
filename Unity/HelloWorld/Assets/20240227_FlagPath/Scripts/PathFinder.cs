using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private FlagPathManager flagPathManager = null;
    public enum Estatus { Ready, Moving, Done }
    private Estatus status = Estatus.Ready;

    private List<Flag> pathList = new List<Flag>();

    private float moveSpeed = 10f;
    private bool isMoving = false;
    private const float stopDistance = 0.01f;

    private void Start()
    {
        flagPathManager.MDel = StartProcess;
    }
    private void StartProcess()
    {
        pathList = flagPathManager.pathList;
        Debug.Log("pathfinder " + string.Join(", ", pathList));
        Debug.Log(status);
        if (status == Estatus.Ready)
        {
            StartMove(pathList);
            //StartCoroutine(MoveCoroutine(pathList));
        }
    }

    WaitForSeconds wait1Sec = new WaitForSeconds(1f);

    /*    public IEnumerator MoveCoroutine(List<Flag> _pathList )
        {
            int order;
            for(order = 0; order < _pathList.Count; ++order) {
                isMoving = true;
                Debug.Log("StartMove");
                if (_pathList == null || _pathList.Count == 0) { 
                    Debug.Log("pathList Error");
                    StopAllCoroutines();
                    //return;
                }
                pathList = _pathList;
                Debug.Log(_pathList[order].ToString());
                Vector3 nextFlagPos = _pathList[order].transform.position;
                Debug.Log(nextFlagPos);
                status = Estatus.Moving;
                if (isMoving)
                    MoveProcess(nextFlagPos);

                if (order >= _pathList.Count)
                {
                    status = Estatus.Done;
                    StopAllCoroutines();
                    Debug.Log("stop");
                }
                yield return wait1Sec;
            }

        }*/

    /*public void StartMove(List<Flag> _pathList) { 
        if (_pathList == null || _pathList.Count == 0)
        {
            Debug.Log("pathList Error");
            return;
        }
        int order;
        Vector3 nextFlagPos;
        for (order = 0; order < _pathList.Count; ++order) {
            if (status == Estatus.Moving) { 
                Debug.Log("_pathList[order]: " + _pathList[order]);
                nextFlagPos = _pathList[order].transform.position;
                Debug.Log("nextFlagPos: "+nextFlagPos);
                MoveProcess(nextFlagPos);
            }
        }

    }

    public void MoveProcess(Vector3 _nextFlagPos)
    {

        Debug.Log("MoveProcess");
        float dist = Vector3.Distance(this.transform.position, _nextFlagPos);

        Vector3 dir = _nextFlagPos - transform.position;
        dir.Normalize();

        Debug.Log("start!! curPos: " + transform.position + ", nextPos: " + _nextFlagPos);
        transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * moveSpeed);
        transform.position = transform.position + (dir * moveSpeed * Time.deltaTime);
        Debug.Log("end!! curPos: " + transform.position + ", nextPos: " + _nextFlagPos);

        if (dist < stopDistance)
        {
            Debug.Log("도착");
            isMoving = false;
            status = Estatus.Ready;
            return;
        }
    }*/
    public void StartMove(List<Flag> _pathList)
    {
        if (_pathList == null || _pathList.Count == 0)
        {
            Debug.Log("pathList Error");
            return;
        }

        StartCoroutine(MoveToNextPosition(_pathList));
    }

    private IEnumerator MoveToNextPosition(List<Flag> _pathList)
    {
        foreach (var flag in _pathList)
        {
            Vector3 nextFlagPos = flag.transform.position;
            Debug.Log(flag);

            MoveProcess(nextFlagPos);

            // 이동이 완료될 때까지 대기
/*            while (status == Estatus.Moving)
            {
                Debug.Log("대기!!!!!!!!!!!!!!!!!!!!!!");
                Debug.Log(status);
                yield return wait1Sec;
            }*/
            yield return wait1Sec;
        }
    }

    public void MoveProcess(Vector3 _nextFlagPos)
    {
        Debug.Log("1: "+status);
        Debug.Log("MoveProcess");

        status = Estatus.Moving;
        _nextFlagPos.y = transform.position.y;
        Vector3 dir = _nextFlagPos - transform.position;
        dir.Normalize();

        Debug.Log("dist: "+Vector3.Distance(transform.position, _nextFlagPos));

        Debug.Log("start!! curPos: " + transform.position + ", nextPos: " + _nextFlagPos);
        transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * moveSpeed);
        //transform.position = transform.position + (dir * moveSpeed * Time.deltaTime);
        transform.position = _nextFlagPos;
        Debug.Log("end!! curPos: " + transform.position + ", nextPos: " + _nextFlagPos);
        Debug.Log("2: "+status);

        Debug.Log("dist: " + Vector3.Distance(transform.position, _nextFlagPos));
        if (Vector3.Distance(transform.position, _nextFlagPos) <= stopDistance)
        {
            Debug.Log("도착");
            status = Estatus.Ready;
        }
    }
}
