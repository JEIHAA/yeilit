using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputExample : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private bool isAxis = false;

    void Update()
    {
        if (!isAxis) InputGetKey();
        else InputGetKey();
    }

    private void InputGetAxis() {
        // 수평으로 움직이는 축 값을 가져옴 A -1 ~ 1 D
        // 상대 위치. 현재 위치에서 해당 값 만큼 이동
        float axisH = Input.GetAxis("Horizontal"); 
        transform.Translate(Vector3.right * axisH * speed * Time.deltaTime);
    }

    private void InputGetKey() {
        if (Input.GetKey(KeyCode.A))
        {
            // 절대 위치. 현재 위치를 해당 위치로 바꿔치기
            transform.position = transform.position + (Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (Vector3.right * speed * Time.deltaTime);
        }
    }

    private void Test() {
        if (Input.GetKeyDown(KeyCode.A))
        { // 키가 눌리면
            Debug.Log("Input Down A");
        }

        if (Input.GetKeyUp(KeyCode.A))
        { // 키가 올라오면
            Debug.Log("Input Up A");
        }

        if (Input.GetKey(KeyCode.Space))
        { // 누르는 동안
            Debug.Log("Input Space");
        }
    }
}
