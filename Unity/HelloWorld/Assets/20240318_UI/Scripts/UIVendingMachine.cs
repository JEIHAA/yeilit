using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIVendingMachine : MonoBehaviour
{
    [SerializeField] private GameObject productButtonPrefab = null;
    /*[SerializeField] private string name = null;
    [SerializeField] private UIProductInfo.ProductInfo[] productInfos = null;*/

    private RectTransform imgBackTr = null;
    private TextMeshProUGUI textName = null;

    private int vmIndex = -1;

    private List<UIProductButton> productBtnList = new List<UIProductButton>();
    public List<UIProductButton> btns { get { return productBtnList; } }

    private void Awake()
    {
        Image imgBack = GetComponentInChildren<Image>();
        imgBackTr = imgBack.GetComponent<RectTransform>();
        textName  = GetComponentInChildren<TextMeshProUGUI>();
    }

    // 게으른 초기화(Lazy Initialization)
    public void Init(VMDatabase.VMInfo _vmInfo, UIProductButton.OnClickDelegate _onClickCallback)
    {
        vmIndex = _vmInfo.vmIndex;
        //textName.text = name;
        textName.text = _vmInfo.vmName;
        BuildButtons(_vmInfo.productInfos, _onClickCallback);
    }

    public void TurnOnOff(bool _on) {
        gameObject.SetActive(_on);
    }

    private void BuildButtons(UIProductInfo.ProductInfo[] _productInfos, UIProductButton.OnClickDelegate _onClickCallback) {
        //odd, even
        bool odd = _productInfos.Length % 2 != 0 ? true : false;
        Vector3 startPos = Vector3.zero;
        float offsetW = 0f;
        float offsetH = 0f;
        CalcstartPosAndOffset(_productInfos, out startPos, out offsetW, out offsetH);

        for (int i = 0; i < _productInfos.Length; ++i) {
            GameObject go = Instantiate(productButtonPrefab, transform);
            UIProductButton productBtn = go.GetComponent<UIProductButton>();
            productBtn.Init(vmIndex, i, _productInfos[i]);

            productBtn.setLocalPosition(new Vector3((30f + startPos.x) + (offsetW * (i % 3)), startPos.y - (offsetH * (i / 3)), 0f));

            productBtn.SetOnClickDelegate(_onClickCallback);

            productBtnList.Add(productBtn);
        }
    }

    private void CalcstartPosAndOffset(UIProductInfo.ProductInfo[] _productInfos, out Vector3 _startPos, out float _offsetW, out float _offsetH) {
        //위치 계산
        float imgW = imgBackTr.sizeDelta.x;
        int divCntW = (_productInfos.Length % 2) + 3;
        float offsetW = imgW / (float)divCntW;
        float startX = -(imgW * 0.5f) + offsetW;

        float imgH = imgBackTr.sizeDelta.y;
        int divCntH = (_productInfos.Length + 2) / 3;
        float offsetH = imgH / (float)divCntH;
        float startY = (imgH * 0.5f) - offsetH;

        _startPos = new Vector3(startX, startY, 0f);
        _offsetW = offsetW;
        _offsetH = offsetH;
    }

    public void UpdateStock(int _btnIdx, int _stock) {
        productBtnList[_btnIdx].UpdateStock(_stock);
    }

    public bool EqualIndex(int _vmIdx) {
        return vmIndex == _vmIdx;
    }
}
