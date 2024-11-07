using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterSound : MonoBehaviour
{
    [SerializeField] private Collider splashingSoundCollider = null;
    [SerializeField] private AudioSource underWaterSource = null;
    [SerializeField] private AudioClip waterSplashingClip = null;
    [SerializeField] private AudioClip underWaterClip = null;

    private void OnTriggerEnter(Collider _collider)
    {
        underWaterSource.PlayOneShot(waterSplashingClip);
        underWaterSource.PlayOneShot(underWaterClip);
    }
}
