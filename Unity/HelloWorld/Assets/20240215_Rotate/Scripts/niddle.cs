using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class niddle : MonoBehaviour
{
    [SerializeField] Transform centerTr = null;
    private float angle = 0f;
    private float speed = 100f;
    private float radius = 5f;
    // Update is called once per frame
    void Update()
    {
        angle -= Time.deltaTime * speed;
        if (angle < -360f) { angle = 0f; }
        RotateWiithAngle(angle);
        LookAtCenter();
    }
    private void RotateWiithAngle(float _angle)
    {
        //�� ����
        // �ﰢ�Լ��� ����ҷ��� ������ ������ �����̿��� �ϱ⶧���� �ȿ��ִ� angle������ �������� ������ֱ����� Deg2Rad�� �����
        // �Լ� ������ ������ ������� �����ϱ⶧���� x������ ���� 0���� �����ϱ⶧���� 12�ù����� ���������Ϸ��� ������ +90 or -90������Ѵ�.
        // ������ x�� -�̱⶧���� ����x��������� ���۵Ǿ +90�ؾ��Ѵ�
        float x = Mathf.Cos((Mathf.PI / 2f) + angle * Mathf.Deg2Rad);
        float y = Mathf.Sin((Mathf.PI / 2f) + angle * Mathf.Deg2Rad);
        Vector3 newPos = centerTr.position + (new Vector3(x, y, 0f) * radius);
        transform.position = newPos;
    }
    private void LookAtCenter()
    {
        Vector3 dir = (transform.position - centerTr.position).normalized; //����ȭ�� ���Ͱ� �ʿ��Ұ��
        //dir.Normalize(); // �� �ڽ��� ����ȭ�� �ʿ��Ұ��
        float theta = Mathf.Atan2(dir.y, dir.x);
        //�ﰢ�Լ� ��ũ ź��Ʈ
        transform.rotation = Quaternion.Euler(0f, 0f, 90f + (theta * Mathf.Rad2Deg)); // ���Ϸ��� ������ ���Ǽ� Deg�� �ٲ������
    }
}
