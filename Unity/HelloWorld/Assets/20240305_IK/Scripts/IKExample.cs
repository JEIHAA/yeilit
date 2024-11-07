using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKExample : MonoBehaviour
{
    [SerializeField]
    private Transform targetTr = null;
    [SerializeField]
    private Transform grabPtTr = null;

    [SerializeField, Range(0f, 1f)]
    private float weight = 1f;

    private Animator anim = null;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int _layerIndex)
    {
        anim.SetLookAtWeight(weight);
        anim.SetLookAtPosition(targetTr.position);

        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, weight);
        anim.SetIKPosition(AvatarIKGoal.LeftHand, grabPtTr.position);

        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, weight);
        anim.SetIKRotation(AvatarIKGoal.LeftHand, grabPtTr.rotation);
    }
}
