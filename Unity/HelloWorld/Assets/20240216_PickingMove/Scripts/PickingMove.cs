using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingMove : MonoBehaviour
{
    private Transform pointTr = null;
    private float moveSpeed = 10f;
    private Vector3 pointPos = Vector3.zero;
    private bool isMoving = false;
    private const float stopDistance = 0.02f;

    private void Awake()
    {
        pointTr = GameObject.FindGameObjectWithTag("PickingPoint").transform;
    } 

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            isMoving = PickingProcess(ref pointPos);

        if (isMoving)
        {
            SetPointPosition(pointPos);
            MovingToPoint(pointPos);
            //transLookAt(pointPos);
        }
    }

    private bool PickingProcess(ref Vector3 _point) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            _point = hit.point;
            return true;
        }

        return false;
    }

    private void MovingToPoint(Vector3 _point)
    {
        _point.y = transform.position.y; // rigidbody ����־ y�� �����������. �ȱ׷��� ���콺�� ��°� ���̶� �� �İ� ������ ������ �����Ÿ�
        Vector3 dir = _point - transform.position;
        dir.Normalize();

        transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * moveSpeed);
        transform.position = transform.position + (dir * moveSpeed * Time.deltaTime);

        /*Vector3 dist = transform.position - _point;
        dist.magnitude // ������ ����*/
        if (Vector3.Distance(transform.position, _point) < stopDistance) {
            isMoving = false;
        }
    }

    private void SetPointPosition(Vector3 _pos) {
        pointTr.position = _pos;
    }

}
