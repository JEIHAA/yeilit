using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
public class VRInputSystem : MonoBehaviour
{
    [SerializeField] InputActionProperty AButton;

    private MashMallowEatnMake eatnMake = null;

    private void Awake()
    {
        eatnMake = GetComponentInChildren<MashMallowEatnMake>();
    }

    private void Update()
    {
        AButton.action.performed += ClickAButton;
    }

    public void ClickAButton(InputAction.CallbackContext obj)
    {
        eatnMake.MakeNewMashMallow();
    }

}
