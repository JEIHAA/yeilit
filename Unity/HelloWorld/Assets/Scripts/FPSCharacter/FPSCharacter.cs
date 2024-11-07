using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCharacter : MonoBehaviour
{
    private Rigidbody rb = null;
    private FPSHead head = null;
    private FPSArm arm = null;
    private FPSGun gun = null;

    private float sensitivity = 5f;
    private float moveSpeed = 10f;
    private float rotY = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        head = GetComponentInChildren<FPSHead>();
        arm = GetComponentInChildren<FPSArm>();
        gun = GetComponentInChildren<FPSGun>();

        rotY = transform.rotation.y;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Keyboard Input (Move)
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        MovingProcess(h, v);

        // Mouse Input (Move)
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        head.HeadRotate(mx, my);
        arm.ArmRotate(my, mx, sensitivity);
        Turn(mx);

        // Mouse Input (Click)
        if (Input.GetMouseButton(0)) { gun.HoldTrigger(); }
        if (Input.GetMouseButtonUp(0)) { gun.Fire(); }
    }

    private void MovingProcess(float _h, float _v)
    {
        Vector3 forward = transform.forward * _v;
        Vector3 right = transform.right * _h;
        Vector3 dir = forward + right;
        //Vector3 dir = transform.forward + new Vector3(_h, 0f, _v); 
        dir.Normalize();
        rb.velocity = dir * moveSpeed;
    }

    private void Turn(float _mx)
    {
        rotY += _mx * sensitivity;
        transform.rotation = Quaternion.Euler(0f, rotY, 0f);
    }
}
