using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotateAround : MonoBehaviour
{
    [SerializeField, Range(0.1f, 5f)] private float radius = 1f;
    [SerializeField, Range(0.1f, 5f)] private float angle = 1f;
    [SerializeField] private float speed = 1f;
    //private float angle = 0f;
    void Update()
    {
        uint currentSecond = (uint)System.DateTime.Now.TimeOfDay.TotalSeconds; // 시스템 시간 상 자정부터 현재까지 지난 시간이 총 몇 초인지 반환함
        //angle += Time.deltaTime * speed;
        //Debug.Log(angle);
        //if (angle > 360f) { angle = 0f;}
        // * Mathf.Deg2Rad: 삼각함수를 계산하려면 단위가 무조건 라디안이여야 하기 때문에 안에있는 angle(디그리)을 라디안으로 변환
        float x = Mathf.Cos((-currentSecond * speed * Mathf.Deg2Rad) + Mathf.PI / 2f); // Cos은 삼각형의 한 각도가 특정 각도(매개 변수 float)일 때의 밑변의 길이를 구함 = x 
        float y = Mathf.Sin((currentSecond * speed * Mathf.Deg2Rad) + Mathf.PI / 2f); // Sin은 삼각형의 한 각도가 특정 각도일 때(매개 변수 float)의 높이를 구함 = y
        // currentSecond가 아주 큰 수여도 90도가 넘어가면 다시 0도부터 시작함, 1초당 6도, 60초가 지나면 360도를 지남.
        // 따라서 현재 시각이 xx시 xx분 15초일 경우 (15*6)도의 각도일 때 Cos값과 Sin값을 구하는 것.
        // Cos값과 Sin값이 x와 y축이 되기 때문에 Vector3에 넣고 반지름을 곱해준 뒤(원형으로 움직임) Position에 넣어주면 현재 시각에 따른 위치가 결정됨
        transform.localPosition = new Vector3(x, y, -1f) * radius;
        Debug.Log(currentSecond);
    }
    //초 360/60 1초 6도
    //분 360/60/60 1초 0.1도 / 10초 1도 / 60초,1분  6도 / 1시간  360도
    //시간 360/60/60/12 1초 0.00833...도 /10초 0.0833.. 1분 0.5도 / 2분 1도/ 1시간 30도 /12시간 360도
}