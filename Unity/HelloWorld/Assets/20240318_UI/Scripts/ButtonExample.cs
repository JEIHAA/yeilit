using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonExample : MonoBehaviour
{
    [SerializeField] private Button btnAnother = null;

    private void Awake()
    {
        btnAnother.onClick.AddListener(AnotherButtonListener);
        //AddListener(PrintDebugLog("test")) X. PrintDebugLog("test")�� ȣ���ϰ� �ִ� ��
        //��������Ʈ���� �Լ� �����͸� �־����.
        //�̰Ŷ����� AnotherButtonPress���� �Լ��� ����� �� ����� ���ٽ��� �����. C#������ ArrowFunction.
        btnAnother.onClick.AddListener(
            () =>
            {
                PrintDebugLog("This is lambda");
            });
    }

    public void AnotherButtonPress() {
        PrintDebugLog("Another button Pressed");
    }

    private void AnotherButtonListener() {
        PrintDebugLog("Another Button Listener");
    }

    private void PrintDebugLog(string _msg) {
        Debug.Log(_msg);
    }

}
