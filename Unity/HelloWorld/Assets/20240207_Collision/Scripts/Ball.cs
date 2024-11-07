using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class Ball : MonoBehaviour
{

    // Collision Detect �浹 ����
    // ���� ȣ������ �ʾҴµ� �����
    // overriding�� ���� ȣ������ �ʾƵ� ��𼱰� �������� ȣ����
    // CallBack �Լ�
    private void OnCollisionEnter(Collision _collision)
    {
        Debug.Log("On Collision Enter!");
    }

    private void OnCollisionExit(Collision _collision)
    {
        Debug.Log("On Collision Exit!");
    }

    private void OnCollisionStay(Collision _collision) // �浹�� �ƴ���
    {
        Debug.Log("On Collision Stay!");
    }

    private void OnTriggerEnter(Collider _collider) // � �浹ü�� �ε�������
    {
        Debug.Log("On Trigger Enter!");
    }

    private void OnTriggerStay(Collider _collider) {
        Debug.Log("On Trigger Stay!");
    }

    private void OnTriggeExit(Collider _collider)
    {
        Debug.Log("On Trigger Exit!");
    }








}
