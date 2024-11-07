using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform cameraTransform;

    public float mouseSensitivity = 100f;

    private Rigidbody rb;
    private float rotationX = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // WASD 키 입력 처리
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 캐릭터 이동
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        // 마우스 입력으로 카메라 회전 처리
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // 스페이스바 입력 처리하여 점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // 마우스 감도 조절
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DecreaseMouseSensitivity();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            IncreaseMouseSensitivity();
        }
    }

    void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        float distanceToGround = GetComponent<Collider>().bounds.extents.y;
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
    }

    void IncreaseMouseSensitivity()
    {
        mouseSensitivity += 10f;
    }

    void DecreaseMouseSensitivity()
    {
        mouseSensitivity -= 10f;
        if (mouseSensitivity < 0f)
        {
            mouseSensitivity = 0f;
        }
    }
}