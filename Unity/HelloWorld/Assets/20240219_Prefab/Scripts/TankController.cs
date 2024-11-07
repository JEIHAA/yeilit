using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    //TankMove���� �����̴� ��ɸ� ����� �ΰ� TankController���� ȣ���ؼ� �����̴� ���
    [SerializeField] private TankMove tankMove = null;
    [SerializeField] TankTurret tankTurret = null;
    private Vector3 point = Vector3.zero;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            tankMove.MoveForward();
        if (Input.GetKey(KeyCode.S))
            tankMove.MoveBack();

        if (Input.GetKey(KeyCode.A))
            tankMove.TurnLeft();
        if (Input.GetKey(KeyCode.D))
            tankMove.TurnRight();


        if (Input.GetMouseButtonDown(0))
        {
            if (Utility.Picking(ref point))
            {
                tankTurret.TurnWithTarget(point);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            tankTurret.Fire(OnDestoroyCannonBall);
        }
    }

    private void OnDestoroyCannonBall(Vector3 _pos)
    {
        // �Ҹ�
        // ��ź ����
        // �ı��ɶ����� ĳ�� Prefab�� �ҷ����⶧���� �ſ� �������ڵ��� ������ �ҷ��� 1���� �ҷ����°� ����
        Instantiate(Resources.Load("Prefabs\\P_FX_Explosion"), _pos, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(point, point + (Vector3.up  *3f));
        Gizmos.color = Color.white;
    }
}
