using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Text;

public class GUIPathList : MonoBehaviour
{
    // Unity Graphic User Interface
    private TextMeshProUGUI textPath = null;
    [SerializeField] // Test
    private Flag[] path = null;
    private StringBuilder sb = new StringBuilder();


    private void Awake()
    {
        textPath = GetComponent<TextMeshProUGUI>();
        textPath.text = string.Empty;
    }

    private void Start()
    {
        SetPath(path);
    }

    public void SetPath(Flag[] _path) {
        sb.Clear();
        foreach(Flag flag in _path)
        {
            sb.Append(flag.GetNumber().ToString());
            sb.Append(" -> ");
        }
        sb.AppendFormat("({0})", _path.Length);

        textPath.text = sb.ToString();
    }
}
