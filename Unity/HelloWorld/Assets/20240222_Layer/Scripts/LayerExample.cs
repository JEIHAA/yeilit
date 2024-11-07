using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerExample : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        layerMask |= 1 << LayerMask.NameToLayer("Blue"); // ���̾��� ��ȣ�� �̸����� �ٲ���
        layerMask |= 1 << LayerMask.NameToLayer("Red"); // 1�� Red�� ��ȣ(7) ��ŭ ����Ʈ
        layerMask |= 1 << LayerMask.NameToLayer("Green"); // �������� �ѹ� ����Ʈ - 2��, ���������� �ѹ� ����Ʈ ����
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) // Mathf.Infinity - ���� ���� - �˻� �ִ� �Ÿ�, layerMask - ��� �˻�����
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}
