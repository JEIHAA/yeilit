using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class MashMallowCook : MonoBehaviour
{
    [SerializeField]private Material[] material = null;
    [SerializeField] private GameObject mCookgo = null;
    private MeshRenderer mr = null;
    private static float cookTime = 0f;


    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        ChangeCookAlbedo();
    }

    public void Reset(bool _exit)
    {
        if (!_exit)
        {
            Debug.Log(cookTime);
            mr.material = material[0];
            cookTime = 0f;
        }
    }

    public void ChangeCookAlbedo()
    {
        if(cookTime<4f)
        {
            mr.material = material[0];
        }
        else if (cookTime < 8f)
        {
            mr.material = material[1];
        }
        else if(cookTime< 12f )
        {
            mr.material = material[2];
        }
        else if(16f<cookTime)
        {
            mr.material = material[3];
        }
    }

    private void OnTriggerStay(Collider _collision)
    {
        if(_collision.CompareTag("BonFire"))
        {
            cookTime += Time.deltaTime;
            Debug.Log(cookTime);
        }
    }



}
