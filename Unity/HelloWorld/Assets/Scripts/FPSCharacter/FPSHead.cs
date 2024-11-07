using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSHead : MonoBehaviour
{
    private Vector3 rot = Vector3.zero;

    private void Start()
    {
        rot = transform.rotation.eulerAngles;
    }

    // Mouse X/Y
    public void HeadRotate(float _mx, float _my, float _senstivity = 5f)
    {
        //transform.rotation = Quaternion.Euler(_my, _mx, 0f); // 아주 좁은 영역에서 드득드득
        //transform.Rotate(_my, _mx, 0f); // 끄덕끄덕하면 점점 고개가 기울어짐
        rot.x -= _my * _senstivity;
        rot.x = Mathf.Clamp(rot.x, -45f, 60f); // 최소값과 최대값이 들어감 각각을 넘어서면 최소값과 최대값을 넣어줌
        //rot.y += _mx;
        transform.localRotation = Quaternion.Euler(rot);
    }
}
