using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimeline : MonoBehaviour
{
    [SerializeField] private RectTransform imgForntTr = null;
    [SerializeField] private float ratio = 0f;

    private float maxWhidth = 0f;

    private void Awake()
    {
        maxWhidth = imgForntTr.sizeDelta.x;
    }

    private void Update()
    {
        UpdateTimeline(ratio);
    }

    public void UpdateTimeline(float _ratio) {
        Vector3 newSize = imgForntTr.sizeDelta;
        newSize.x = maxWhidth * _ratio;
        imgForntTr.sizeDelta = newSize;
    }

}
