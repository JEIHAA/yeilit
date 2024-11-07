using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOBlock : MonoBehaviour
{
    private MeshRenderer mr = null;

    private void Awake()
    {
        mr = GetComponentInChildren<MeshRenderer>();
    }

    public void SetColor(Color _color)
    {
        mr.material.SetColor("_Color", _color);
    }
}
