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


    private GameObject PickingProcess() { // 너무 옛날 방식 이제 안씀
        //transform.localToWorldMatrix;
        mainCam = Camera.main;
        Vector3 mousePos = Input.mousePosition; // 마우스의 위치를 구했지만 마우스는 z값이 없음. z가 0이라서 카메라보다 뒤에 있어서 위치가 안찍힘
        mousePos.z = mainCam.nearClipPlane; // 마우스를 카메라 가까이로 보내줌
        Vector3 toWorld = mainCam.ScreenToWorldPoint(mousePos);
        Vector3 dir = (toWorld - mainCam.transform.position).normalized; 

        RaycastHit hit;
        if (Physics.Raycast(mainCam.transform.position, dir, out hit)) {
            Debug.Log(hit.transform.name);
        }

        Debug.DrawLine(mainCam.transform.position, dir, Color.red); // Ray 위치 표시해줌

        return null;
    }

    private GameObject ModernPickingProcess() { // 알아서 레이 다 만들어줌 요즘방식
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
