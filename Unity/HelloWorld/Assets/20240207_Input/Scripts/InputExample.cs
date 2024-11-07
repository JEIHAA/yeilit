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
        // �������� �����̴� �� ���� ������ A -1 ~ 1 D
        // ��� ��ġ. ���� ��ġ���� �ش� �� ��ŭ �̵�
        float axisH = Input.GetAxis("Horizontal"); 
        transform.Translate(Vector3.right * axisH * speed * Time.deltaTime);
    }

    private void InputGetKey() {
        if (Input.GetKey(KeyCode.A))
        {
            // ���� ��ġ. ���� ��ġ�� �ش� ��ġ�� �ٲ�ġ��
            transform.position = transform.position + (Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (Vector3.right * speed * Time.deltaTime);
        }
    }

    private void Test() {
        if (Input.GetKeyDown(KeyCode.A))
        { // Ű�� ������
            Debug.Log("Input Down A");
        }

        if (Input.GetKeyUp(KeyCode.A))
        { // Ű�� �ö����
            Debug.Log("Input Up A");
        }

        if (Input.GetKey(KeyCode.Space))
        { // ������ ����
            Debug.Log("Input Space");
        }
    }
}
