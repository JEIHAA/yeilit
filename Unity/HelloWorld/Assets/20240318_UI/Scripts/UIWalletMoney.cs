using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class UIWalletMoney : MonoBehaviour
{
    private TextMeshProUGUI textMoney = null;

    private void Awake()
    {
        textMoney = GetComponent<TextMeshProUGUI>();
    }

    public void SetMoney(int _money) {
        textMoney.text = _money.ToString();
    }
}
