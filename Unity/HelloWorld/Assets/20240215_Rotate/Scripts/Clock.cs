using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
[SerializeField] float speed = 0f;
    void Update()
    {
        SecondRotate();
    }
    private void SecondRotate()
    {
        uint currentSecond = (uint)System.DateTime.Now.TimeOfDay.TotalSeconds;
        transform.eulerAngles = new Vector3(0, 0, -currentSecond * speed);
    }

    private void LookAt() {
        Vector3 dir = (transform.position - Vector3.zero).normalized;
        dir.Normalize(); // 위 아래 똑같음 정규화된 벡터가 필요하냐 나 자신을 정규화하냐의 차이
        float theta = Mathf.Atan2(dir.y, dir.x);

        transform.rotation = Quaternion.Euler(0f, 0f, 90f + (theta * Mathf.Rad2Deg));
    }
}

