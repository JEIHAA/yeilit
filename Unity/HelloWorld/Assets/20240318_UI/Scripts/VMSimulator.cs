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

            // �����ͺ��̽� ��� ���̱�
            vmDB.StockDecrement(_vmIdx, _btnIdx);

            // ���ŵ� DB ���� ��������
            if(vmDB.FindProductInfo(_vmIdx, _btnIdx, ref info)) {
                // �ش� ��ư ���� ����
                vmHolder.UpdateStock(_vmIdx, _btnIdx, info.stock);
            }
        }


    }
}
