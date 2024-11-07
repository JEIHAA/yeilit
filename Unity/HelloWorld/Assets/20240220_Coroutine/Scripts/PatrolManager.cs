using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolManager : MonoBehaviour
{
    [SerializeField] private PatrolChicken chicken = null;
    [SerializeField] private PatrolPointHolder pph = null;

    /*// ������ �ʱ�ȭ
    // Lazy Initialization
    public bool Init() // �ʱ�ȭ�� �Լ��� ���� �����θ� �ʱ�ȭ ������ ������ �� ���� 
    {
        chicken.Init();
        patrolPointHoler.Init();
        return true;
    }*/

    private void Start() // Awake�� �ϸ� pph�� �ʱ�ȭ�Ǳ� ���� ���� ȣ��Ǿ���� ���� ����. ���� ����ȵ�
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
