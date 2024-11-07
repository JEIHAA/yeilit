using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOBall : MonoBehaviour
{
    private enum EState { Stay, Move }
    [SerializeField] private Transform boundingCountTr = null;

    private EState state = EState.Stay;
    private Vector3 moveDir = Vector3.zero;
    private float moveSpeed = 10f;

    private BOUIBoundingCount uiBoundingCount = null;
    private int boundingCount = 0;

    private void Awake()
    {
        uiBoundingCount = boundingCountTr.GetComponent<BOUIBoundingCount>();
    }

    public void MoveStart(Vector3 _dir) {
        moveDir = _dir;
        state = EState.Move;
    }

    private void UpdateDirWithAxis(float _axisX) {
        Vector3 axis = new Vector3(_axisX, 0f, 0f);
        moveDir = (moveDir + axis).normalized;
    }

    private void FlipX() {
        Vector3 newDir = moveDir;
        newDir.x *= -1f;
        moveDir = newDir;
    }

    private void FlipY()
    {
        Vector3 newDir = moveDir;
        newDir.y *= -1f;
        moveDir = newDir;
    }

    private void Update()
    {
        UpdateBoundingCountPosition();

        if (state == EState.Stay) return;

        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision _collision)
    {
        GameObject colGo = _collision.gameObject;
        if (colGo.CompareTag("WallLeft") || colGo.CompareTag("WallRight"))
        {
            FlipX();
            uiBoundingCount.UpdateCount(++boundingCount);
        }
        else if (colGo.CompareTag("WallUp") || colGo.CompareTag("WallDown"))
        {
            FlipY();
            uiBoundingCount.UpdateCount(++boundingCount);
        }
        else if (colGo.CompareTag("Paddle"))
        {
            uiBoundingCount.UpdateCount(++boundingCount);
            if (transform.position.y > colGo.transform.position.y)
            {   FlipY();
            }
            else
                FlipX();
            UpdateDirWithAxis(colGo.GetComponent<BOPaddle>().AxisX);
        }
    }

    private void UpdateBoundingCountPosition() {
        Vector3 worldToScreen = Camera.main.WorldToScreenPoint(transform.position); // 공의 월드 포지션을 스크린 포지션으로
        boundingCountTr.position = worldToScreen + (Vector3.up * 30f);
    }
}
