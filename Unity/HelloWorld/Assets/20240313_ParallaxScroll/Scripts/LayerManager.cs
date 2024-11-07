using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    private ParallaxScroll[] layers = null;
    private int layerLen = 0;

    private Transform[] firstLayerChildren = null;
    private Vector3 firstSheetPos = new Vector3();

    private Transform[] lastLayerChildren = null;
    private int lastChildrenLen = 0;
    private Vector3 lastSheetPos = new Vector3();

    private void Awake()
    {
        layers = GetComponentsInChildren<ParallaxScroll>();
        layerLen = layers.Length;

        firstLayerChildren = layers[0].GetComponentsInChildren<Transform>();

        lastLayerChildren = layers[layerLen-1].GetComponentsInChildren<Transform>();
        lastChildrenLen = lastLayerChildren.Length;
    }

    public Vector3 GetFirstSheetPos()
    {
        firstSheetPos = firstLayerChildren[0].GetComponent<Transform>().transform.position;
        return firstSheetPos;
    }

    public Vector3 GetLastSheetPos() {
        lastSheetPos = lastLayerChildren[lastChildrenLen-1].GetComponent<Transform>().transform.position;
        return lastSheetPos;
    }
}
