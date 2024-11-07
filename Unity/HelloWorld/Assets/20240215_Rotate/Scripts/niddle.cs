using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class niddle : MonoBehaviour
{
    [SerializeField] Transform centerTr = null;
    private float angle = 0f;
    private float speed = 100f;
    private float radius = 5f;
    // Update is called once per frame
    void Update()
    {
        angle -= Time.deltaTime * speed;
        if (angle < -360f) { angle = 0f; }
        RotateWiithAngle(angle);
        LookAtCenter();
    }
    private void RotateWiithAngle(float _angle)
    {
        //초 돌림
        // 삼각함수를 계산할려면 단위가 무조건 라디안이여야 하기때문에 안에있는 angle정수를 라디안으로 만들어주기위해 Deg2Rad를 사용함
        // 함수 시작은 오른쪽 양수에서 시작하기때문에 x라인이 각도 0으로 시작하기때문에 12시방향을 기준으로하려면 각도를 +90 or -90해줘야한다.
        // 지금은 x가 -이기때문에 왼쪽x축기준으로 시작되어서 +90해야한다
        float x = Mathf.Cos((Mathf.PI / 2f) + angle * Mathf.Deg2Rad);
        float y = Mathf.Sin((Mathf.PI / 2f) + angle * Mathf.Deg2Rad);
        Vector3 newPos = centerTr.position + (new Vector3(x, y, 0f) * radius);
        transform.position = newPos;
    }
    private void LookAtCenter()
    {
        Vector3 dir = (transform.position - centerTr.position).normalized; //정규화된 벡터가 필요할경우
        //dir.Normalize(); // 내 자신이 정규화가 필요할경우
        float theta = Mathf.Atan2(dir.y, dir.x);
        //삼각함수 아크 탄젠트
        transform.rotation = Quaternion.Euler(0f, 0f, 90f + (theta * Mathf.Rad2Deg)); // 오일러는 각도로 계산되서 Deg로 바꿔줘야함
    }
}
