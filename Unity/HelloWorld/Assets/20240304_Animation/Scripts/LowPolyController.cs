using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowPolyController : MonoBehaviour
{
    private Animator anim = null;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float v = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", v);
        anim.SetInteger("IntSpeed", (int)v);

        if (Input.GetMouseButtonDown(0))
            anim.SetBool("IsAttack", true);

        if (Input.GetMouseButtonUp(0))
            anim.SetBool("IsAttack", false);
    }
}
