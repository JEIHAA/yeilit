using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TankCannonBall;

public class TankTurret : MonoBehaviour
{
    [SerializeField] private Transform spawnPointTr = null;
    [SerializeField] private GameObject cannonBallPrefab = null;

    private void Awake()
    {
        //cannonBallPrefab = Resources.Load("Prefabs\\P_CannonBall") as GameObject;
    }

    public void TurnWithTarget(Vector3 _target){
        StopAllCoroutines();
        StartCoroutine(TurnCoroutine(_target));
    }

    // Co-op
    // 코루틴(Coroutine)
    // Task Manager
    // 코루틴으로 안돌리면 이 작업이 끝날 때까지 다른 작업을 안함
    private IEnumerator TurnCoroutine(Vector3 _target) {
        Quaternion start = transform.rotation; // 현재 각도
        _target.y = transform.position.y;  // 마우스 Y값 보정(안하면 포탑 땅에 박힘)

        Vector3 dir = (_target - transform.position); // 방향벡터 만들고 정규화
        dir.Normalize();

        Quaternion end = Quaternion.LookRotation(dir);

        // Quaterninon.Euler는 x축 몇도 y축 몇도, z축 몇도 회전할건지 넣어주는것 (각도를 알고있는 상황)
        // LookRotation 각도는 모르고 방향을 알고있는상황 (아크탄젠트로 각도를 구하고 방향 벡터를 구함)

        float t = 0f;
        while (t < 1f) {
            // Lerp: Linear Interpolation(선형보간)
            transform.rotation = Quaternion.Lerp(start, end, t);

            t += Time.deltaTime;

            Debug.DrawLine(transform.position, _target, Color.yellow);

            yield return null;
        }
        transform.rotation = end;
    }

    public void Fire(TankCannonBall.OnDestoryDelegate _onDestroyDelegate) {
        GameObject go = Instantiate(cannonBallPrefab, spawnPointTr.position, spawnPointTr.rotation);
        TankCannonBall cannonBall = go.GetComponent<TankCannonBall>();
        cannonBall.OnDestroyCallback = _onDestroyDelegate;
        /*Debug.Log(SpawnPointTr.rotation);
        Debug.Log(SpawnPointTr.localRotation); // 부모로부터 얼마나 돌아갔는지*/

        /*Debug.Log(SpawnPointTr.rotation.eulerAngles);*/
        // cannonBall 생성
        //Instantiate(cannonBallPrefab, spawnPointTr.position, spawnPointTr.rotation) ;
    }

}
