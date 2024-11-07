using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIProductInfo : MonoBehaviour
{
    public enum EProduct { Coke, Coffe, Milk, Kkang, Homerun }

    [System.Serializable]
    public struct ProductInfo
    {
        public EProduct name;
        public int price;
        public int stock;

        public bool HasStock() {
            return stock > 0;
        }

        public void PrintInfo() {
            Debug.Log(name + " / " + price + " / " + stock + "��");
        }
    }

    public static string EnumToString(EProduct _name) {
        switch (_name) {
            case EProduct.Coke: return "�ݶ�";
            case EProduct.Coffe: return "Ŀ��";
            case EProduct.Milk: return "����";
            case EProduct.Kkang: return "��";
            case EProduct.Homerun: return "Ȩ����";
        }
        return string.Empty;
    }
}
