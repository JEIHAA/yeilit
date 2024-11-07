using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour
{
    [SerializeField, Range(10f, 30f)] private float moveSpeed = 30f;
    [SerializeField, Range(50f, 100f)] private float rotSpeed = 100f;
    private Rigidbody rb = null;

    private void Update()
    {
        //MoveCube();
        MoveCubeWithRB();
        RotateCube();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void MoveCube() {
        if (Input.GetKey(KeyCode.W)) {
            transform.position = transform.position + (transform.forward * moveSpeed * Time.deltaTime); 
            // 회전했으면 방향벡터가 바뀌어서 그 뱡향으로 가야하는데 Vector3.forward는 월드좌표 기준으로 0,0,1이라서 내 방향대로 가지 않고 월드 좌표상의 forward방항으로 움직임
            // 나의 회전값을 가지고 있는 transform.forward를 가지고 계산해야함
            // 위치를 강제로 변경하기 때문에 충돌판정이 제대로 이루어지지 않음
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            // transform.Translate는 어느 방향으로 얼마만큼 이동할 것인지만 있으면 됨
            // Translate 행렬을 만듦. 현재 내 위치에 행렬을 곱해줌. 내 위치가 누적됨
            // (Vector3.back * moveSpeed * Time.deltaTime);는 회전되기 전의 이동값
            // DX와 openGL의 계산하는 방식이 다름
        }
    }

    private void MoveCubeWithRB() {
        if (Input.GetKey(KeyCode.W))
        {
            //rb.AddForce(transform.forward * moveSpeed);
            //Speed : 속력 
            //Velocity : 속도  (방향과 힘) 유니티가 지원하는 기능 중 가장 안전함
            rb.velocity = transform.forward * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //rb.AddForce(-transform.forward * moveSpeed);
            rb.velocity = transform.forward * moveSpeed;
        }
    }

    private void RotateCube() {
        if (Input.GetKey(KeyCode.Q)) { 
            transform.Rotate(Vector3.up, rotSpeed*Time.deltaTime * -1f); // 엔진마다 양수방향이 다름
            // Rotate(); 회전 행렬을 만듦. 지금 상태에서 얼마만큼 회전하면 되는지만 필요함. 방향과 각도만 필요
            // 내 로컬 축 기준
        }
        if (Input.GetKey(KeyCode.E))
        {
            Vector3 newRot = transform.rotation.eulerAngles;
            newRot.y += rotSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(newRot);
            // eulerAngle울 가져와서 y를 증가시킨 후에 Quaternion 계산해줌(위치이동)
            // 부모 축에 영향을 받은 상태 기준
        }
    }
}
