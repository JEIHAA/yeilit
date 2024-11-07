using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWallet : MonoBehaviour
{
    [SerializeField]private VMPlayer player = null;
    private UIWalletMoney money = null;

    private void Awake()
    {
        money = GetComponentInChildren<UIWalletMoney>(); // 자식 중에 있으니까 InChildren해야함
    }

    // MVC Pattern
    public void SetMoney(int _money) {
        money.SetMoney(_money);
        player.Money = _money;
    }

    // Unit Test 기능별 테스트. 테스트 할 수 있는 환경은 테스트 베드
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            SetMoney(50000);
        
    }
}
