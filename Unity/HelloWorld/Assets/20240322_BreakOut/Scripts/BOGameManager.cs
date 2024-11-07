using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOGameManager : MonoBehaviour
{
    [SerializeField] private BOBlockManager blockMng = null;
    [SerializeField] private BOPaddle paddle = null;
    [SerializeField] private BOController controller = null;

    private void Awake()
    {
        controller.OnInputAxisCallback = OnInputAxisCallback;
        controller.OnInputButtonCallback = OnInputButtonCallback;
    }

    private void OnInputAxisCallback(float _axisX) {
        paddle.MoveProcess(_axisX);
    }

    private void OnInputButtonCallback() {
        paddle.Detache();
    }
}
