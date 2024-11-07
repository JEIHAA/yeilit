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
            Destroy(this); // this : ���� �� Ŭ����(TankCannonBall)�� CannonBall�� �־�� TankCannonBall Script Component�� �����*/
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.CompareTag("Wall")) {
            Destroy(gameObject); // Component�� ������ �� �ֱ� ������ gameObject�� �־������
        }
    }
    private void OnDestroy()
    {
        //Instantiate(fxExplosionPrefab, transform.position, Quaternion.identity);
        onDestroyCallback?.Invoke(transform.position);
    }
}
