using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPointHolder : MonoBehaviour
{
    private Transform[] patrolPoints = null;
    private int lastPointIdx = 0;

    private void Awake()
    {
        patrolPoints = GetComponentsInChildren<Transform>();
    }

    public Vector3 GetNearPoint(Vector3 _sour) {
        int nearIdx = 1;
        
        if (patrolPoints == null || patrolPoints.Length < 1)
            return Vector3.zero;

        if (nearIdx == lastPointIdx) ++nearIdx;

        for (int i = nearIdx+1; i < patrolPoints.Length; ++i) {
            if (i == lastPointIdx) continue;
            // magnitude는 정확함, 루트 계산 제외하고 비용을 절감한게 sqrMagnitude
            // magnitude(sqrt) : A^2 + B^2
            // sqrMagnitude    : A+B
            float nearDist = (_sour - patrolPoints[nearIdx].position).sqrMagnitude;
            if (nearDist < 1f) nearDist = 1000f;
            float curDist = (_sour - patrolPoints[i].position).sqrMagnitude;
            if (curDist < 1f) nearDist = 1000f;

            if (curDist < nearDist) nearIdx = i;
        }

        lastPointIdx = nearIdx; // 원래 이따구로 코드짜면 안됨
        return patrolPoints[nearIdx].position;
    }

    public Vector3 GetRandomPoint() {
        return patrolPoints[Random.Range(1, patrolPoints.Length)].position;
    }
}
