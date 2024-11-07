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
    // �ڷ�ƾ(Coroutine)
    // Task Manager
    // �ڷ�ƾ���� �ȵ����� �� �۾��� ���� ������ �ٸ� �۾��� ����
    private IEnumerator TurnCoroutine(Vector3 _target) {
        Quaternion start = transform.rotation; // ���� ����
        _target.y = transform.position.y;  // ���콺 Y�� ����(���ϸ� ��ž ���� ����)

        Vector3 dir = (_target - transform.position); // ���⺤�� ����� ����ȭ
        dir.Normalize();

        Quaternion end = Quaternion.LookRotation(dir);

        // Quaterninon.Euler�� x�� � y�� �, z�� � ȸ���Ұ��� �־��ִ°� (������ �˰��ִ� ��Ȳ)
        // LookRotation ������ �𸣰� ������ �˰��ִ»�Ȳ (��ũź��Ʈ�� ������ ���ϰ� ���� ���͸� ����)

        float t = 0f;
        while (t < 1f) {
            // Lerp: Linear Interpolation(��������)
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
        Debug.Log(SpawnPointTr.localRotation); // �θ�κ��� �󸶳� ���ư�����*/

        /*Debug.Log(SpawnPointTr.rotation.eulerAngles);*/
        // cannonBall ����
        //Instantiate(cannonBallPrefab, spawnPointTr.position, spawnPointTr.rotation) ;
    }

}
