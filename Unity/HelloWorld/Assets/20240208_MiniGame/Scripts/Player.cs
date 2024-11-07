using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // delegate 함수 포인터. 반환형 void, 매개변수 없어야함
    public delegate void CollisionDelegate();
    private CollisionDelegate collisionCallback = null;
    public CollisionDelegate CollisionCallback { set { collisionCallback = value; } }

    public delegate void TriggerDelegate();
    private TriggerDelegate triggerCallback = null;
    public TriggerDelegate TriggerCallback { set { triggerCallback = value; } }

    [SerializeField] private float limitLeft = -3.5f;
    [SerializeField] private float limitRight = 3.5f;
    [SerializeField] private float moveSpeed = 7f;

    /*private void Updata() {
        float axisH = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }*/

    public void MoveHorizontal(float _axisH) {
        //if (transform.position.x >= -3.5f && transform.position.x <= 3.5f)
                transform.Translate(Vector3.right * _axisH * moveSpeed * Time.deltaTime);
        #region Failed Limit Check
        /*//if (transform.position.x < limitLeft)
        if(CheckLimitLeft())
        {
            //transform.position.x = -3.5f; //transform은 Vector라서 바로 실수로 값을 변경할 수 없음
            Vector3 newPos = transform.position;
            newPos.x = limitLeft;
            transform.position = newPos;
        }
        else if (CheckLimitRight()) {
            Vector3 newPos = transform.position;
            newPos.x = limitRight;
            transform.position = newPos;
        }*/
        #endregion
        if (CheckLimitLeft())
            FixedLimitHorizontal(limitLeft);
        else if (CheckLimitRight())
            FixedLimitHorizontal(limitRight);
    }

    private bool CheckLimitLeft() {
        return transform.position.x < limitLeft;
    }
    private bool CheckLimitRight()
    {
        return transform.position.x > limitRight;
    }
    private void FixedLimitHorizontal(float _limitH) {
        Vector3 newPos = transform.position;
        newPos.x = _limitH;
        transform.position = newPos;
    }

    private void OnCollisionEnter(Collision _collision)
    {
        /*Debug.Log("On Collision: "+ _collision.gameObject.name);   */
        if (_collision.gameObject.CompareTag("Wall")) { // ==보다 빠름
            if (collisionCallback != null) {
                collisionCallback(); // 이제 이런식으로 안씀 triggerCallback?.Invoke(); 이렇게 씀
            }
        }
    }

    private void OnTriggerEnter(Collider _collider)
    {
        Debug.Log("On Trigger: "+ _collider.name);
        if (_collider.tag == "Gate") { // gameObject.CompareTag보다 느림
            triggerCallback?.Invoke(); // 요즘 권장하는 방식. triggerCallback이 null이 아니면 Invoke를 실행
                                       // ? : null로 초기화하는 애들 null인지 검사하는 기능 
        }
    }
}
