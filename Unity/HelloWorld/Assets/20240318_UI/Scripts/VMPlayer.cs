using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VMPlayer : MonoBehaviour
{
    private int money = 50000;

    public int Money { get { return money; } set { money = value; } }

    public bool CanPay(int _price) {
        return money >= _price;
    }

    public void Pay(int _price) {
        money -= _price;
    }
}
