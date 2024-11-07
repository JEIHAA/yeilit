using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineCounter : MonoBehaviour
{
    /*    private void Start()
        {
            StartCoroutine(CounterCoroutine());
        }*/

    private void OnEnable() { // 스크립트가 켜질 때 호출됨. 새로 생성해서 넣어줄 때도 호출됨
        Debug.Log("On Enable");
    }
    private void OnDisable() // 스크립트가 꺼질 때 호출됨. 제거할 때도 호출됨
    {
        Debug.Log("On Disable");
    }

    private IEnumerator Start() // Update는 코루틴으로 못만듦
    {
        gameObject.SetActive(true); // 해당 게임 오브젝트의 액티브를 끔
        bool isActive = gameObject.activeSelf; // getter만 있음. 켜져있는지 꺼져있는지 확인만 가능
        this.enabled = true; // 해당 스크립트가 꺼짐
        // 오브젝트의 액티브가 꺼지면 실행이 안됨
        // 실행 중에 꺼졌다 켜져도 다시 실행 안됨
        // 오브젝트의 스크립트가 꺼지는건 코루틴의 실행에 영향을 끼치지 않음
        yield return new WaitForSeconds(1f);
    }

    private void Update()
    {
        Debug.Log("Counter"); // Update는 오브젝트가 꺼지든 스크립트가 꺼지든 모두 종료되지만 다시 켜면 다시 실행됨
    }

    private void OnMouseDown()
    {
        Debug.Log("On Mouse Down");
    }
    private void OnMouseDrag()
    {
        Debug.Log("On Mouse Drag");
    }

    public void CounterStart() {
        StartCoroutine(CounterCoroutine());
    }

    private IEnumerator CounterCoroutine() {
        int cnt = 0;
        while (true) {
            Debug.Log("cnt: " + cnt++);
            yield return new WaitForSeconds(1f);
        }
    }
}
