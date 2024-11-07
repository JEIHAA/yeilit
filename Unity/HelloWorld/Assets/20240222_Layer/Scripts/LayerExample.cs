using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerExample : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        layerMask |= 1 << LayerMask.NameToLayer("Blue"); // 레이어의 번호를 이름으로 바꿔줌
        layerMask |= 1 << LayerMask.NameToLayer("Red"); // 1을 Red의 번호(7) 만큼 쉬프트
        layerMask |= 1 << LayerMask.NameToLayer("Green"); // 왼쪽으로 한번 쉬프트 - 2배, 오른쪽으로 한번 쉬프트 절반
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) // Mathf.Infinity - 끝이 없음 - 검사 최대 거리, layerMask - 어떤걸 검사할지
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}
