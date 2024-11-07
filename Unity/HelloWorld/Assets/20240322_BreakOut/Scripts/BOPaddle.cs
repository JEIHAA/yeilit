using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BOPaddle : MonoBehaviour
{
    private Rigidbody rb = null;
    private float moveSpeed = 10f;
    private float axisX = 0f;

    public float AxisX { get { return axisX; } }

    public void MoveProcess(float _axisX) {
        axisX = _axisX;
        transform.Translate(_axisX * moveSpeed * Time.deltaTime, 0f, 0f);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Detache() {
        if (transform.childCount > 0) {
            BOBall ball = transform.GetChild(0).GetComponent<BOBall>();
            Vector3 dir = (Vector3.up + new Vector3(axisX, 0f, 0f)).normalized;
            ball.MoveStart(dir);
            transform.GetChild(0).SetParent(null);
        }
    }

    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.transform.CompareTag("WallLeft"))
            rb.AddForce(Vector3.right, ForceMode.Impulse);
        else if (_collision.transform.CompareTag("WallRight"))
            rb.AddForce(Vector3.left, ForceMode.Impulse);
    }


}
