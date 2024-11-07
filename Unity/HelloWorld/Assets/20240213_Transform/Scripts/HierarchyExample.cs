using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HierarchyExample : MonoBehaviour
{
    private Transform testChild = null;

    private void Start() {
        Transform tr = GetComponent<Transform>();
        //transform. ��� ������Ʈ�� ������ �ֱ� ������ �̹� �����������. ������ ���� �ʾƵ� �ҷ��ͼ� �� �� ���� 

        Transform childTr = GetComponentInChildren<Transform>(gameObject); // �ڽĵ��� ������ �ִ� ������Ʈ �߿� ��������
        Debug.Log("childTr: " + childTr.name); // �θ� ���� ������Ʈ�� �����ؼ� �˻��� �� ���� ù��°�� ������(�θ� ������ ������ �θ� ���� ��������)

        Child child = GetComponentInChildren<Child>(); // Child��� ��Ҹ� ���� ������Ʈ���� ������
        Debug.Log("child: " + child.name);

        Transform[] childTrs = GetComponentsInChildren<Transform>();

        for (int i = 0; i < childTrs.Length; i++) {
            Debug.LogFormat("childTrs[{0}] : {1}", i, childTrs[i].name);
        }

        testChild = GetComponentInChildren<Child>().transform;

    }

    private void Update()
    {
        //TranslateChild();
        //RotateChild();
        ScaleChild();
    }

    private void TranslateChild() {
        // Mathf.Abs(Mathf.Sin); Sin���� ���밪���� ������ 0~1���� �Դٰ���
        //testChild.position = Vector3.up * Mathf.Abs(Mathf.Sin(Time.time*5f));  // ���� ��ǥ���� 0~1 ���̸� �Դٰ���
        testChild.localPosition = Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 5f)); // �θ� �������� ��밪 0~1 ���̸� �Դٰ���
    }

    private void RotateChild()
    {
        // Quaternion �����
        //testChild.rotation
        // Pitch, Yaw, Roll : x�� ȸ��, y�� ȸ��, z�� ȸ��
        // ����Ƽ������ ���� �ȵǾ� ������ �𸮾󿡼��� �Լ� �̸��� Pitch, Yaw, Roll��
        testChild.localRotation = Quaternion.Euler(0f, Time.time * 100f, 0f); // ���� �о�� ���� Euler�� �ص� ��, ���� �־��� �� Euler�� �ϸ� �ȵ�
    }

    private void ScaleChild() {
        // testChild.scale�� ����
        testChild.localScale = Vector3.one * Mathf.Sin(Time.time * 5f);   
    }



    private void OnDrawGizmos()
    {
        // RGB
        // XYZ
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, Vector3.right);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero, Vector3.up);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Vector3.zero, Vector3.left);

        Gizmos.color = Color.white;
    }
}
