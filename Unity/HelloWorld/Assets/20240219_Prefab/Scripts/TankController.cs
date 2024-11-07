using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    //TankMove에는 움직이는 기능만 만들어 두고 TankController에서 호출해서 움직이는 방식
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
        // 소리
        // 포탄 갯수
        // 파괴될때마다 캐논볼 Prefab을 불러오기때문에 매우 안좋은코드임 위에서 불러서 1번만 불러오는게 좋음
        Instantiate(Resources.Load("Prefabs\\P_FX_Explosion"), _pos, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(point, point + (Vector3.up  *3f));
        Gizmos.color = Color.white;
    }
}
