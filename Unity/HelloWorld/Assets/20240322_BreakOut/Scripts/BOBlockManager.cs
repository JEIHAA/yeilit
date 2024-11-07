using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOBlockManager : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab = null;
    [SerializeField] private Color[] colors = null;

    //[SerializeField, Range(1f, 9f)]
    private int colCnt = 9;
    //[SerializeField, Range(1f, 6f)]
    private int rowCnt = 6;

    private List<GameObject> blockList = new List<GameObject>();


    private void Start()
    {
        BuildBlocks();
    }

    private void BuildBlocks()
    {
        // W: 1, H: 0.3
        float startX = transform.position.x - (colCnt * 0.5f) + (1f * 0.5f);
        float startY = transform.position.y + (rowCnt >> 1) - (0.5f * 0.5f);
        float offsetX = 1f;
        float offsetY = 0.5f;

        for (int row = 0; row < rowCnt; ++row)
        {
            for (int col = 0; col < colCnt; ++col)
            {
                GameObject go =
                    Instantiate(blockPrefab, transform);
                blockList.Add(go);
                go.transform.localPosition = new Vector3(startX + (offsetX * col), startY - (offsetY * row), 0f);

                BOBlock block = go.GetComponent<BOBlock>();
                block.SetColor(colors[row]);
            }
        }
    }


}