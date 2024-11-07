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
        _point.y = transform.position.y; // rigidbody 들어있어서 y값 보정해줘야함. 안그러면 마우스로 찍는게 땅이라서 땅 파고 들어가려다 막혀서 빌빌거림
        Vector3 dir = _point - transform.position;
        dir.Normalize();

        transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * moveSpeed);
        transform.position = transform.position + (dir * moveSpeed * Time.deltaTime);

        /*Vector3 dist = transform.position - _point;
        dist.magnitude // 벡터의 길이*/
        if (Vector3.Distance(transform.position, _point) < stopDistance) {
            isMoving = false;
        }
    }

    private void SetPointPosition(Vector3 _pos) {
        pointTr.position = _pos;
    }

}
