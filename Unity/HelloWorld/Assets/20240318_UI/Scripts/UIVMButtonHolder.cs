using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIVMButtonHolder : MonoBehaviour
{  
    private UIVMButton[] vmBtns = null;

    private void Awake()
    {
        vmBtns = GetComponentsInChildren<UIVMButton>();
    }

    public void SetOnClickCallback(UIVMButton.OnClickDelegate _onClickCallback) {
        //[0] [1] [2]
        for(int i = 0; i< vmBtns.Length; i++) {
            vmBtns[i].SetOnClickCallback(i, _onClickCallback);
        }
    }
}
