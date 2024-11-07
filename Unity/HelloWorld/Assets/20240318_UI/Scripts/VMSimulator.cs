using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VMSimulator : MonoBehaviour
{
    [SerializeField] private VMDatabase vmDB = null;
    [SerializeField] private VMPlayer vmPlayer = null;
    [SerializeField] private UIVMButtonHolder vmBtnHolder = null;
    [SerializeField] private UIVMHolder vmHolder = null;
    [SerializeField] private UIWallet wallet = null;

    private void Start()
    {
        vmHolder.Init(vmDB.FindAll(), ProductButtonCallback);
        vmBtnHolder.SetOnClickCallback(VMButtonCallback);
        wallet.SetMoney(vmPlayer.Money);
    }

    private void VMButtonCallback(int _idx) {
        vmHolder.TurnOn(_idx);
    }

    private void ProductButtonCallback(int _vmIdx, int _btnIdx) {
        UIProductInfo.ProductInfo info = new UIProductInfo.ProductInfo();
        if (vmDB.FindProductInfo(_vmIdx, _btnIdx, ref info))
        {
            if (info.HasStock()) {
                if (vmPlayer.CanPay(info.price)) {
                    vmPlayer.Pay(info.price);
                    wallet.SetMoney(vmPlayer.Money);
                    info.PrintInfo();
                }
            }
            info.PrintInfo();

            // 데이터베이스 재고 줄이기
            vmDB.StockDecrement(_vmIdx, _btnIdx);

            // 갱신된 DB 정보 가져오기
            if(vmDB.FindProductInfo(_vmIdx, _btnIdx, ref info)) {
                // 해당 버튼 정보 갱신
                vmHolder.UpdateStock(_vmIdx, _btnIdx, info.stock);
            }
        }


    }
}
