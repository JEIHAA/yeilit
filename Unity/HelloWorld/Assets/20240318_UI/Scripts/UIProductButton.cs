using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIProductButton : MonoBehaviour
{
    private enum EIndex { Name, Price, Stock }


    public delegate void OnClickDelegate(int _vmIndex, int _btnIdx);
    private OnClickDelegate onClickCallback = null;

    private Button btn = null;
    private TextMeshProUGUI[] texts = null;
    private RectTransform rectTr = null;

    private int vmIdx = -1;
    private int btnIdx = -1;

    private void Awake()
    {
        btn = GetComponentInChildren<Button>();
        texts = GetComponentsInChildren<TextMeshProUGUI>();
        rectTr = GetComponent<RectTransform>();
    }

    public void Init(int _vmIdx, int _btnIdx, UIProductInfo.ProductInfo _info)
    {
        vmIdx = _vmIdx;
        btnIdx = _btnIdx;

        texts[(int)EIndex.Name].text = UIProductInfo.EnumToString(_info.name);
        texts[(int)EIndex.Price].text = _info.price + "¿ø";
        texts[(int)EIndex.Stock].text = _info.stock.ToString() + "°³";
    }

    public void SetOnClickDelegate(OnClickDelegate _callback) {
        onClickCallback = _callback;
        btn.onClick.AddListener(
            () => {
                onClickCallback?.Invoke(vmIdx, btnIdx);
            });
    }

    public void setLocalPosition(Vector3 _localPos) {
        rectTr.localPosition = _localPos;
    }

    public void UpdateStock(int _stock)
    {
        texts[(int)EIndex.Stock].text = _stock.ToString() + "°³";
    }
}
