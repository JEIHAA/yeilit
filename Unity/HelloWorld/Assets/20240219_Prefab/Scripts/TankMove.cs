using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    [SerializeField, Range(10f, 30f)] private float moveSpeed = 20f;
    [SerializeField, Range(100f, 200f)] private float turnSpeed = 150f;

    public void MoveForward() {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); // transform에 있는 회전행렬을 건드는 것
    }

    public void MoveBack() {
        transform.position = transform.position + ((transform.forward * -1f) * moveSpeed * Time.deltaTime);
    }

    // X : Pitch, Y : Yaw, Z : Roll
    public void TurnLeft() {
        transform.Rotate(Vector3.up, -1f * turnSpeed * Time.deltaTime); // Rotate(증분값)
    }

    public void TurnRight() {
        transform.rotation = transform.rotation * Quaternion.Euler(0f, turnSpeed * Time.deltaTime, 0f);
    }
}
