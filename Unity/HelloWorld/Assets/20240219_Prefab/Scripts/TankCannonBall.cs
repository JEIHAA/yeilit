using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCannonBall : MonoBehaviour
{
    public delegate void OnDestoryDelegate(Vector3 _pos);
    private OnDestoryDelegate onDestroyCallback = null;
    public OnDestoryDelegate OnDestroyCallback
    {
        set { onDestroyCallback = value; }
    }
    [SerializeField] private GameObject fxExplosionPrefab = null;


    private float moveSpeed = 30f;

    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        /*if (Input.GetKeyDown(KeyCode.P))
            Destroy(this); // this : 현재 이 클래스(TankCannonBall)라서 CannonBall에 넣어둔 TankCannonBall Script Component가 사라짐*/
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.CompareTag("Wall")) {
            Destroy(gameObject); // Component도 삭제할 수 있기 때문에 gameObject를 넣어줘야함
        }
    }
    private void OnDestroy()
    {
        //Instantiate(fxExplosionPrefab, transform.position, Quaternion.identity);
        onDestroyCallback?.Invoke(transform.position);
    }
}
