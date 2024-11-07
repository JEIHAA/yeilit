using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class FPSBall : MonoBehaviour
{
    private Rigidbody rb = null;
    private Collider col = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    private void Start()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        col.enabled = false;
    }

    public void SetPosition(Vector3 _pos)
    {
        transform.position = _pos;
    }

    public void AttachParent(Transform _parentTr) {
        transform.SetParent(_parentTr); // 부모에 붙임
    }

    public void DetachParent() {
        //transform.parent = null; // 되긴 되지만 SetParent를 권장
        transform.SetParent(null);
    }

    public void SetSizeWithPower(float _power) {
        _power = Mathf.Clamp(_power, 0.1f, 1f);
        transform.localScale = Vector3.one * _power;
    }

    public void Shoot(Vector3 _dir, float _power) {
        rb.useGravity = true;
        rb.isKinematic = false;
        col.enabled = true;
        rb.AddForce(_dir * _power  * 10f, ForceMode.Impulse);

        Destroy(gameObject, 5f);
    }
}
