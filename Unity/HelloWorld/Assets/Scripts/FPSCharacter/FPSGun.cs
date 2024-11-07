using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSGun : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab = null;
    private FPSSpawnPoint spawnPoint = null;
    private FPSBall ball = null;

    private float shootPower = 0f;

    private void Awake()
    {
        spawnPoint = GetComponentInChildren<FPSSpawnPoint>();
    }

    private void SpawnBall() {
        GameObject go = Instantiate(projectilePrefab) as GameObject;
        ball = go.GetComponent<FPSBall>();
        ball.SetPosition(spawnPoint.GetPosition());
        ball.AttachParent(transform);
    }

    public void HoldTrigger() {
        if (ball == null) SpawnBall();
        shootPower += Time.deltaTime;
        shootPower = Mathf.Clamp(shootPower, 0.1f, 5f);
        ball.SetSizeWithPower(shootPower);
    }

    public void Fire() {
        ball.DetachParent();

        ball.Shoot(transform.forward, shootPower);
        ball = null;
        shootPower = 0f;
    }
}
