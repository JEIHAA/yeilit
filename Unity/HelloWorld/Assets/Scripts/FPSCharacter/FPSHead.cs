using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSHead : MonoBehaviour
{
    private Vector3 rot = Vector3.zero;

    private void Start()
    {
        rot = transform.rotation.eulerAngles;
    }

    // Mouse X/Y
    public void HeadRotate(float _mx, float _my, float _senstivity = 5f)
    {
        //transform.rotation = Quaternion.Euler(_my, _mx, 0f); // ���� ���� �������� �����
        //transform.Rotate(_my, _mx, 0f); // ���������ϸ� ���� ���� ������
        rot.x -= _my * _senstivity;
        rot.x = Mathf.Clamp(rot.x, -45f, 60f); // �ּҰ��� �ִ밪�� �� ������ �Ѿ�� �ּҰ��� �ִ밪�� �־���
        //rot.y += _mx;
        transform.localRotation = Quaternion.Euler(rot);
    }
}
