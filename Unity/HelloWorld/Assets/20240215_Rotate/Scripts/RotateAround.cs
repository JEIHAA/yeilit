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
        uint currentSecond = (uint)System.DateTime.Now.TimeOfDay.TotalSeconds; // �ý��� �ð� �� �������� ������� ���� �ð��� �� �� ������ ��ȯ��
        //angle += Time.deltaTime * speed;
        //Debug.Log(angle);
        //if (angle > 360f) { angle = 0f;}
        // * Mathf.Deg2Rad: �ﰢ�Լ��� ����Ϸ��� ������ ������ �����̿��� �ϱ� ������ �ȿ��ִ� angle(��׸�)�� �������� ��ȯ
        float x = Mathf.Cos((-currentSecond * speed * Mathf.Deg2Rad) + Mathf.PI / 2f); // Cos�� �ﰢ���� �� ������ Ư�� ����(�Ű� ���� float)�� ���� �غ��� ���̸� ���� = x 
        float y = Mathf.Sin((currentSecond * speed * Mathf.Deg2Rad) + Mathf.PI / 2f); // Sin�� �ﰢ���� �� ������ Ư�� ������ ��(�Ű� ���� float)�� ���̸� ���� = y
        // currentSecond�� ���� ū ������ 90���� �Ѿ�� �ٽ� 0������ ������, 1�ʴ� 6��, 60�ʰ� ������ 360���� ����.
        // ���� ���� �ð��� xx�� xx�� 15���� ��� (15*6)���� ������ �� Cos���� Sin���� ���ϴ� ��.
        // Cos���� Sin���� x�� y���� �Ǳ� ������ Vector3�� �ְ� �������� ������ ��(�������� ������) Position�� �־��ָ� ���� �ð��� ���� ��ġ�� ������
        transform.localPosition = new Vector3(x, y, -1f) * radius;
        Debug.Log(currentSecond);
    }
    //�� 360/60 1�� 6��
    //�� 360/60/60 1�� 0.1�� / 10�� 1�� / 60��,1��  6�� / 1�ð�  360��
    //�ð� 360/60/60/12 1�� 0.00833...�� /10�� 0.0833.. 1�� 0.5�� / 2�� 1��/ 1�ð� 30�� /12�ð� 360��
}