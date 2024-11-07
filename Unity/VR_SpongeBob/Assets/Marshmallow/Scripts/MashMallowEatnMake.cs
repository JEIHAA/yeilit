using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashMallowEatnMake : MonoBehaviour
{
    private MashMallowCook mashCook = null;
    [SerializeField] private GameObject go = null;
    private bool exit = true;

    private void Awake()
    {
        mashCook = GetComponentInChildren<MashMallowCook>();
    }

    private void OnTriggerEnter(Collider _collision)
    {

        if(_collision.CompareTag("MainCamera"))
        {
            Eat();
        }
    }

    public void Eat()
    {
        if(exit==true)
        {
            go.SetActive(false);
            exit = false;
        }
    }
    
    public void MakeNewMashMallow()
    {
        if(exit==false)
        {
            go.SetActive(true);
            mashCook.Reset(exit);
            exit = true;
        }
        else
        {
            Debug.Log("이미 마쉬멜로가 존재합니다.");
        }
       
    }
}
