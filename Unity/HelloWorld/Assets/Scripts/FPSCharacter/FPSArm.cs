using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSArm : MonoBehaviour
{
    private float rotX = 0.5f;
    

    private void Start()
    {
        rotX = transform.rotation.eulerAngles.x;
    }

    public void ArmRotate(float _my, float _mx, float _sensitivity = 5f) {
        rotX -= _my * _sensitivity;
        rotX = Mathf.Clamp(rotX, -45f, 60f);

        transform.localRotation = Quaternion.Euler(rotX, 0f, 0f);
    }
}
