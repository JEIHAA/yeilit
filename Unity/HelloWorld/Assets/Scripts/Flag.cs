using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode] // EditMode에서 실행한다. 실행시키지 않아도 코드가 돌아감
public class Flag : MonoBehaviour
{
    [SerializeField] private int number = 0;
    [SerializeField] private Flag[] nearFlags = null;
    [SerializeField] private bool onDebugMode = true;
    [SerializeField] private Color debugLineColor = Color.black;
    private Flag flag = null;

    private MeshRenderer[] mrs = null;
    private TextMeshPro numberText = null;

    private void Awake()
    {
        flag = GetComponent<Flag>();
        mrs = GetComponentsInChildren<MeshRenderer>(); // GetComponents Pole, Flag 두개라서 배열로 받음
        numberText = GetComponentInChildren<TextMeshPro>(); // GetComponent
    }

    private void Start()
    {
        numberText.text = number.ToString();
    }

    public int GetNumber() {
        return number;
    }

    public Flag[] GetNearFlag()
    {
        return nearFlags;
    }


    public Vector3 GetPosition()
    {
        return transform.position;
    }
    

    private void SetColors(Color _color) {
        foreach (MeshRenderer mr in mrs) {
            mr.material.SetColor("_Main", _color);
        }
    }

    public void SetSelectColor() {
        SetColors(Color.yellow);
    }

    public void SetTouchedColor() {
        SetColors(Color.red);
    }

    public void ResetColor()
    {
        SetColors(Color.white);
    }

    private void Update()
    {
        if (!onDebugMode) return;
        foreach (Flag flag in nearFlags) {
            UnityEngine.Debug.DrawLine(transform.position, flag.GetPosition(), debugLineColor);
        }
    }
}
