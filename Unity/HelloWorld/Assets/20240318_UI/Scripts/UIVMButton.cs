using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIVMButton : MonoBehaviour
{
    public delegate void OnClickDelegate(int _idx);

    private Button btn = null;

    private void Awake()
    {
        btn = GetComponent<Button>();
    }

    public void SetOnClickCallback(int _idx, OnClickDelegate _onClickCallback) {
        btn.onClick.AddListener(
            () => {
                _onClickCallback(_idx);
            });
    }
}
