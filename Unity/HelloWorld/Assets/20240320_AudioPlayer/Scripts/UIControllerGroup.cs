using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIControllerGroup : MonoBehaviour
{
    public enum EType { Play, Pause, Stop }

    private Button[] btns = null;

    private void Awake()
    {
        btns = GetComponentsInChildren<Button>();
    }

    public void AddOnClickEvent(EType _type, UnityAction _action) {
        btns[(int)_type].onClick.AddListener(_action);
    }
}
