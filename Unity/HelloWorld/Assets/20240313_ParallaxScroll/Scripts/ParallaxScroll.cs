using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    [SerializeField] private int defaultSpeed = 2;
    [SerializeField] private CharMove charMove = null;
    private SpriteRenderer[] backgroundSheet = null;
    private Vector3 firstSheetPos = new Vector3();
    private Vector3 lastSheetPos = new Vector3();
    private LayerManager layerManager = null;
    private int sheetLen = 0;
    private float direction = 1;

    private void Awake()
    {
        backgroundSheet = GetComponentsInChildren<SpriteRenderer>();
        layerManager = GetComponentInParent<LayerManager>();
    }

    private void Start()
    {
        sheetLen = backgroundSheet.Length;
        firstSheetPos = layerManager.GetFirstSheetPos();
        Debug.Log(firstSheetPos.x);
        lastSheetPos = layerManager.GetLastSheetPos();
        Debug.Log(lastSheetPos.x);
    }

    private void Update()
    {
        movingSheet();
        direction = charMove.getDirection();
    }

    private void movingSheet() {
        int i = 0;
        int speed = defaultSpeed;
        Vector3 sheetPos = new Vector3(direction,0,0);

        for (i =0; i<sheetLen; ++i) {
            if (sheetLen <= 0 && backgroundSheet == null) Debug.Log("sheet is null");

            if (backgroundSheet[i].transform.position.x <= -20 || backgroundSheet[i].transform.position.x > lastSheetPos.x) resetSheetPos(i);

            backgroundSheet[i].transform.position = backgroundSheet[i].transform.position + (sheetPos * speed * Time.deltaTime);
            speed += 1;
        }

        speed = defaultSpeed;
    }

    private void resetSheetPos(int _i)
    {
        if (direction == -1)
        {
            float x = lastSheetPos.x;
            float y = backgroundSheet[_i].transform.position.y;
            float z = backgroundSheet[_i].transform.position.z;
            backgroundSheet[_i].transform.position = new Vector3(x, y, z);
        }
        else if (direction == 1) {
            float x = firstSheetPos.x - 20f;
            float y = backgroundSheet[_i].transform.position.y;
            float z = backgroundSheet[_i].transform.position.z;
            backgroundSheet[_i].transform.position = new Vector3(x, y, z);
        }
    }
}
