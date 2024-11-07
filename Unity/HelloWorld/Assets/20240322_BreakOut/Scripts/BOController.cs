using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOController : MonoBehaviour
{
    public delegate void OnInputAxisDelegate(float _axisX);
    private OnInputAxisDelegate onInputAxisCallback = null;
    public OnInputAxisDelegate OnInputAxisCallback
    {
        set { onInputAxisCallback = value; }
    }

    private OnInputButtonDelegate onInputButtonCallback = null;
    public delegate void OnInputButtonDelegate();
    public OnInputButtonDelegate OnInputButtonCallback
    {
        set { onInputButtonCallback = value; }
    }

    private void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        onInputAxisCallback?.Invoke(axisX);

        if (Input.GetKeyDown(KeyCode.Space))
            onInputButtonCallback?.Invoke();
    }
}
