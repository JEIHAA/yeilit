using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class Ball : MonoBehaviour
{

    // Collision Detect 충돌 감지
    // 내가 호출하지 않았는데 실행됨
    // overriding됨 내가 호출하지 않아도 어디선가 누군가가 호출함
    // CallBack 함수
    private void OnCollisionEnter(Collision _collision)
    {
        Debug.Log("On Collision Enter!");
    }

    private void OnCollisionExit(Collision _collision)
    {
        Debug.Log("On Collision Exit!");
    }

    private void OnCollisionStay(Collision _collision) // 충돌이 됐는지
    {
        Debug.Log("On Collision Stay!");
    }

    private void OnTriggerEnter(Collider _collider) // 어떤 충돌체랑 부딪혔는지
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
