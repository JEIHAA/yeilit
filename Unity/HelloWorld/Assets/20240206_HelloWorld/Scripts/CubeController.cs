using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Unity Life Cycle
public class CubeController : MonoBehaviour // 컴포넌트로 상속 받기 위해서는 MonoBehaviour가 필수
{
    [SerializeField] private int val = 0;
    [HideInInspector] public int publicVal = 0;

    [SerializeField, Range(0f, 10f)] private float speed = 10f;

    // 안쓰는 유니티 함수를 오버라이딩하면 퍼포먼스가 떨어짐, 아예 지워두는게 좋음
    // 유니티에서 자체적으로 만든 함수들만 override 키워드를 안써도 됨
    // 첫번째 프레임이 그려지기 전 한번만 호출
    void Start()
    {
        Debug.Log("val :"+ val);
    }

    // 1프레임마다 호출 60프레임이면 1초에 60번 호출되는 것
    void Update()
    {
        transform.position = transform.position + (Vector3.forward * speed * Time.deltaTime);
    }
}
