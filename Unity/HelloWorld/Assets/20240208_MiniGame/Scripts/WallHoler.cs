using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHoler : MonoBehaviour
{
    [SerializeField] private float respawnPosZ = 10f;
    [SerializeField] private float endPosZ = -4f;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float waveSpeed = 0f;

    private void Start()
    {
        Respawn();
    }
    private void Update()
    {
        //MovingProcess();
        MovingWaveProcess();
        if (CheckEndPosition()) {
            Respawn();
        }
    }

    public void Respawn() {
        Vector3 newPos = transform.position;
        newPos.x = UnityEngine.Random.Range(-3f, 3f);
        newPos.z = respawnPosZ;
        transform.position = newPos;

        waveSpeed = Random.Range(1f, 3f);
    }

    public bool CheckEndPosition() {
        return transform.position.z < endPosZ;
    }

    public void MovingProcess() {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

    private void MovingWaveProcess() {
        Vector3 newPos = new Vector3();
        newPos.x = Mathf.Sin(Time.time * waveSpeed) * 3f;
        newPos.z = transform.position.z + (-1f * moveSpeed * Time.deltaTime);

        transform.position = newPos;
    }
}

