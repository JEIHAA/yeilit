using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Unity Life Cycle
public class CubeController : MonoBehaviour // ������Ʈ�� ��� �ޱ� ���ؼ��� MonoBehaviour�� �ʼ�
{
    [SerializeField] private int val = 0;
    [HideInInspector] public int publicVal = 0;

    [SerializeField, Range(0f, 10f)] private float speed = 10f;

    // �Ⱦ��� ����Ƽ �Լ��� �������̵��ϸ� �����ս��� ������, �ƿ� �����δ°� ����
    // ����Ƽ���� ��ü������ ���� �Լ��鸸 override Ű���带 �Ƚᵵ ��
    // ù��° �������� �׷����� �� �ѹ��� ȣ��
    void Start()
    {
        Debug.Log("val :"+ val);
    }

    // 1�����Ӹ��� ȣ�� 60�������̸� 1�ʿ� 60�� ȣ��Ǵ� ��
    void Update()
    {
        transform.position = transform.position + (Vector3.forward * speed * Time.deltaTime);
    }
}
