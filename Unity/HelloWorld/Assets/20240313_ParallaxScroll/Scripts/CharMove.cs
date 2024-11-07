using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    private SpriteRenderer spriteRenderer = null;
    private float direction = -1;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            spriteRenderer.flipX = true;
            direction = 1;

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = false;
            direction = -1;
        }
    }

    public float getDirection() {
        return direction;
    }
}
