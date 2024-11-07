using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BOUIBoundingCount : MonoBehaviour
{
    private TextMeshProUGUI textCount = null;

    private void Awake()
    {
        textCount = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateCount(int _cnt) {
        textCount.text = _cnt.ToString("D3");
    }
}
