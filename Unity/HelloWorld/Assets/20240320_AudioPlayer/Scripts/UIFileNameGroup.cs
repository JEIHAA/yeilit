using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIFileNameGroup : MonoBehaviour
{
    private TextMeshProUGUI textFileName = null;
    
    private void Awake()
    {
        textFileName = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetFileName(string _fileName) {
        textFileName.text = _fileName;
    }
}
