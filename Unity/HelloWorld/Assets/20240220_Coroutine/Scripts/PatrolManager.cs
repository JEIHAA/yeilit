using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolManager : MonoBehaviour
{
    [SerializeField] private PatrolChicken chicken = null;
    [SerializeField] private PatrolPointHolder pph = null;

    /*// 게으른 초기화
    // Lazy Initialization
    public bool Init() // 초기화용 함수를 따로 만들어두면 초기화 순서를 보장할 수 있음 
    {
        chicken.Init();
        patrolPointHoler.Init();
        return true;
    }*/

    private void Start() // Awake로 하면 pph가 초기화되기 전에 먼저 호출되어버릴 수도 있음. 순서 보장안됨
    {
        Vector3 chickenPos = chicken.GetPosition();
        Vector3 nearPointPos = pph.GetNearPoint(chickenPos);
        chicken.PatrolStart(nearPointPos);
        chicken.PatrolDoneCallback = PatrolDoneCallback;
    }

    private void PatrolDoneCallback() {
        //chicken.PatrolStart(pph.GetNearPoint(chicken.GetPosition()));
        chicken.PatrolStart(pph.GetRandomPoint());
    }
}
