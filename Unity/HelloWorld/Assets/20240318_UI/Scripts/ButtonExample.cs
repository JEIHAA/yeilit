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
        //AddListener(PrintDebugLog("test")) X. PrintDebugLog("test")를 호출하고 있는 것
        //델리게이트에는 함수 포인터를 넣어야함.
        //이거때문에 AnotherButtonPress같은 함수를 만드는 게 낭비라서 람다식을 사용함. C#에서는 ArrowFunction.
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
