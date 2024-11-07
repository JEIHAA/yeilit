using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VMDatabase : MonoBehaviour
{
    [System.Serializable]
    public struct VMInfo {
        public int vmIndex;
        public string vmName;
        public UIProductInfo.ProductInfo[] productInfos;

        public VMInfo(int _vmIdx, string _vmName, UIProductInfo.ProductInfo[] _productInfos)
        {
            vmIndex = _vmIdx;
            vmName = _vmName;
            productInfos = _productInfos;
        }

        public static VMInfo NULL() {
            // string.Empty =/= null
            // �����Ҵ� �� ������ ���°� =/= �����Ҵ絵 �ȵȰ�
            return new VMInfo(-1, null, null); // �� ��ü
        }

        public bool IsNULL() {
            return vmIndex == -1;
        }
    }



    [SerializeField] private VMInfo[] vmInfos = null;
    [SerializeField] private UIVendingMachine[] vm = null;

    public VMInfo[] FindAll()
    {
        return vmInfos;
    }

    public VMInfo FindWithIndex(int _vmIndex) {
        foreach (VMInfo info in vmInfos) {
            if (info.vmIndex == _vmIndex)
                return info;
        }

        // �� ��ü
        return VMInfo.NULL(); // ����ü�� null�� ����. null ��ü�� ��ȯ        
    }

    public bool FindProductInfo(int _vmIdx, int _btnIdx, ref UIProductInfo.ProductInfo _productInfo) {
        foreach (VMInfo info in vmInfos) {
            if (info.vmIndex == _vmIdx) {
                if (_btnIdx >= 0 && _btnIdx < info.productInfos.Length) {
                    _productInfo = info.productInfos[_btnIdx];
                    return true;
                }
            }
        }
        return false;
    }

    // Increment / Decrement
    public void StockDecrement(int _vmIdx, int _btnIdx) {
        foreach (VMInfo info in vmInfos) {
            if (info.vmIndex == _vmIdx && info.productInfos[_btnIdx].stock >= 0)
            {
                // info.productInfos[_btnIdx].StockDecrement(); ��������
                Debug.Log(info.productInfos[_btnIdx].stock);
                Debug.Log(vm[_vmIdx].btns[_btnIdx]);
                --info.productInfos[_btnIdx].stock;
                if (info.productInfos[_btnIdx].stock <= 0)
                    vm[_vmIdx].btns[_btnIdx].GetComponentInChildren<Button>().interactable = false;
                
            }
        }
    }
}
