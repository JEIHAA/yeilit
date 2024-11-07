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
            Debug.Log(name + " / " + price + " / " + stock + "개");
        }
    }

    public static string EnumToString(EProduct _name) {
        switch (_name) {
            case EProduct.Coke: return "콜라";
            case EProduct.Coffe: return "커피";
            case EProduct.Milk: return "우유";
            case EProduct.Kkang: return "깡";
            case EProduct.Homerun: return "홈런볼";
        }
        return string.Empty;
    }
}
