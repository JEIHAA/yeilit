using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWallet : MonoBehaviour
{
    [SerializeField]private VMPlayer player = null;
    private UIWalletMoney money = null;

    private void Awake()
    {
        money = GetComponentInChildren<UIWalletMoney>(); // �ڽ� �߿� �����ϱ� InChildren�ؾ���
    }

    // MVC Pattern
    public void SetMoney(int _money) {
        money.SetMoney(_money);
        player.Money = _money;
    }

    // Unit Test ��ɺ� �׽�Ʈ. �׽�Ʈ �� �� �ִ� ȯ���� �׽�Ʈ ����
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            SetMoney(50000);
        
    }
}
