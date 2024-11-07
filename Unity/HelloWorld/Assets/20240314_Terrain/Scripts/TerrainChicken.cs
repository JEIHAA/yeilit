using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TerrainChicken : MonoBehaviour
{
    private CharacterController ctrl = null;
    private float moveSpeed = 10f;

    private void Awake()
    {
        ctrl = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float axisH = Input.GetAxis("Horizontal");
        float axisV = Input.GetAxis("Vertical");
        Vector3 speed = new Vector3(axisH, 0f, axisV);
        speed.Normalize();

        ctrl.SimpleMove(speed * moveSpeed);
    }
}

