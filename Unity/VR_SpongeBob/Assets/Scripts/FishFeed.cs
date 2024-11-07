using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFeed : MonoBehaviour
{
    public float jumpForce = 7f;
    public float descentSpeed = 0.3f;
    public float lifeTime = 20f;
    public float unJump = 1f;
    private float elapsedTime = 0f;
    private float eatingTime = 0.3f;

    private Rigidbody rb;
    private bool hasJumped = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Jump();
        StartCoroutine(DestroyAfterDelay(lifeTime));
    }

    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.CompareTag("Fish"))
        {
            Destroy(gameObject);
        }
    }

    private void Jump()
    {
        Vector3 jumpDirection = Vector3.up;
        rb.AddForce(jumpDirection * jumpForce, ForceMode.Impulse);
        hasJumped = true;
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    private IEnumerator StartDescentAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        hasJumped = true;
    }

    private void HasJumped()
    {
        if (hasJumped)
        {
            rb.velocity = Vector3.down * descentSpeed;
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 0.3f)
        {
            HasJumped();
        }
    }
}
