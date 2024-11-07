using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PicKingExample : MonoBehaviour
{
    [SerializeField] private GameObject[] objs = null;
    private Camera mainCam = null;

    private void Update()
    {
        ResetColor();
        GameObject go = ModernPickingProcess();
        if (go != null)  SetColorAtGO(go);
    }


    private GameObject PickingProcess() { // �ʹ� ���� ��� ���� �Ⱦ�
        //transform.localToWorldMatrix;
        mainCam = Camera.main;
        Vector3 mousePos = Input.mousePosition; // ���콺�� ��ġ�� �������� ���콺�� z���� ����. z�� 0�̶� ī�޶󺸴� �ڿ� �־ ��ġ�� ������
        mousePos.z = mainCam.nearClipPlane; // ���콺�� ī�޶� �����̷� ������
        Vector3 toWorld = mainCam.ScreenToWorldPoint(mousePos);
        Vector3 dir = (toWorld - mainCam.transform.position).normalized; 

        RaycastHit hit;
        if (Physics.Raycast(mainCam.transform.position, dir, out hit)) {
            Debug.Log(hit.transform.name);
        }

        Debug.DrawLine(mainCam.transform.position, dir, Color.red); // Ray ��ġ ǥ������

        return null;
    }

    private GameObject ModernPickingProcess() { // �˾Ƽ� ���� �� ������� ������
        mainCam = Camera.main;
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            return hit.transform.gameObject;
        }
        return null;
    }

    private void ResetColor() {
        foreach (GameObject go in objs) {
            MeshRenderer mr = go.GetComponent<MeshRenderer>();
            mr.material.SetColor("_Color", Color.white);
        }
    }

    private void SetColorAtGO(GameObject _go) {
        MeshRenderer mr = _go.GetComponent<MeshRenderer>();
        mr.material.SetColor("_Color", new Color(1f,0f,0f));
    }
}
