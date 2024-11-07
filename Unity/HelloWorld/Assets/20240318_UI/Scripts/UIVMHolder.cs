using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIVMHolder : MonoBehaviour
{
    private UIVendingMachine[] vms = null;
    private UIVendingMachine prevVM = null;

    private void Awake()
    {
        vms = GetComponentsInChildren<UIVendingMachine>();
    }

    private void Start()
    {
        
    }

    public void Init(VMDatabase.VMInfo[] _vmInfos, UIProductButton.OnClickDelegate _onClickCallback) {
        /*foreach (UIVendingMachine vm in vms)
            vm.Init();*/
        for (int i = 0; i< _vmInfos.Length; ++i) {
            // 원래 여기서 자판기 생성 (현재 코드 상에서는 이미 만들어져있음)
            vms[i].Init(_vmInfos[i], _onClickCallback);
        }
        TurnOffAll();
    }

    private void TurnOffAll() {
        foreach (UIVendingMachine vm in vms)
            vm.TurnOnOff(false);
    }
    public void TurnOn(int _idx) {
        if (prevVM != null)
            prevVM.TurnOnOff(false);

        vms[_idx].TurnOnOff(true);

        prevVM = vms[_idx];
    }

    public void UpdateStock(int _vmIdx, int _btnIdx, int _stock)
    {
        foreach (UIVendingMachine vm in vms) {
            if (vm.EqualIndex(_vmIdx))
                vm.UpdateStock(_btnIdx, _stock);
        }
    }
}
