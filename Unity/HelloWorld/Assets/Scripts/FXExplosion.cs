using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXExplosion : MonoBehaviour
{
    private float duration = 0.5f;
    private float speed = 30f;
    private void Start()
    {
        duration = Random.Range(0.5f, 1f);
        Destroy(gameObject, duration);
    }
    private void Update()
    {
        transform.localScale += Vector3.one * speed * Time.deltaTime;
    }
}
