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
            // ȸ�������� ���⺤�Ͱ� �ٲ� �� �������� �����ϴµ� Vector3.forward�� ������ǥ �������� 0,0,1�̶� �� ������ ���� �ʰ� ���� ��ǥ���� forward�������� ������
            // ���� ȸ������ ������ �ִ� transform.forward�� ������ ����ؾ���
            // ��ġ�� ������ �����ϱ� ������ �浹������ ����� �̷������ ����
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            // transform.Translate�� ��� �������� �󸶸�ŭ �̵��� �������� ������ ��
            // Translate ����� ����. ���� �� ��ġ�� ����� ������. �� ��ġ�� ������
            // (Vector3.back * moveSpeed * Time.deltaTime);�� ȸ���Ǳ� ���� �̵���
            // DX�� openGL�� ����ϴ� ����� �ٸ�
        }
    }

    private void MoveCubeWithRB() {
        if (Input.GetKey(KeyCode.W))
        {
            //rb.AddForce(transform.forward * moveSpeed);
            //Speed : �ӷ� 
            //Velocity : �ӵ�  (����� ��) ����Ƽ�� �����ϴ� ��� �� ���� ������
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
            transform.Rotate(Vector3.up, rotSpeed*Time.deltaTime * -1f); // �������� ��������� �ٸ�
            // Rotate(); ȸ�� ����� ����. ���� ���¿��� �󸶸�ŭ ȸ���ϸ� �Ǵ����� �ʿ���. ����� ������ �ʿ�
            // �� ���� �� ����
        }
        if (Input.GetKey(KeyCode.E))
        {
            Vector3 newRot = transform.rotation.eulerAngles;
            newRot.y += rotSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(newRot);
            // eulerAngle�� �����ͼ� y�� ������Ų �Ŀ� Quaternion �������(��ġ�̵�)
            // �θ� �࿡ ������ ���� ���� ����
        }
    }
}
