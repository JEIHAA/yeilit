using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Collections;

public class UIVolumeGroup : MonoBehaviour
{
    public delegate void ChangedVolume(float _vol);
    private ChangedVolume changedVolumeCallback = null;

    private Slider sliderVolume = null;
    private TextMeshProUGUI textVolume = null;

    private void Awake()
    {
        sliderVolume = GetComponentInChildren<Slider>();
        textVolume = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        UpdateVolumeText();
    }

    public void SetChangedVolumeCallback(ChangedVolume _callback) {
        changedVolumeCallback = _callback;
    }

    public void OnChangedVolume(float _vol) {
        UpdateVolumeText();
        changedVolumeCallback?.Invoke(_vol);
    }

    private void UpdateVolumeText() {
        textVolume.text = sliderVolume.value.ToString("F2"); // 소수점 한자리까지 출력
    }

    public float GetVolume() {
        return sliderVolume.value;
    }
}
