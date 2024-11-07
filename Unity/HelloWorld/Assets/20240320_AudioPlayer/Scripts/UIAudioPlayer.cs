using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UIAudioPlayer : MonoBehaviour
{
    private AudioSource audioSource = null;

    private UIFileLoadGroup fileLoadGroup = null;
    private UIFileNameGroup fileNameGroup = null;
    private UIControllerGroup controllerGroup = null;
    private UIVolumeGroup volumeGroup = null;
    private UITimelineGroup timelineGroup = null;

    private float clipLength = 0f;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (!audioSource)
            audioSource = gameObject.AddComponent<AudioSource>();

        fileLoadGroup = GetComponentInChildren<UIFileLoadGroup>();
        fileNameGroup = GetComponentInChildren<UIFileNameGroup>();
        controllerGroup = GetComponentInChildren<UIControllerGroup>();
        volumeGroup = GetComponentInChildren<UIVolumeGroup>();
        timelineGroup = GetComponentInChildren<UITimelineGroup>();
    }

    private void Start()
    {
        fileLoadGroup.OnClickFileLoadCallback = OnClickFileLoadCallback;
        controllerGroup.AddOnClickEvent(UIControllerGroup.EType.Play,
            () =>
            {
                //Debug.Log("play");
                audioSource?.Play();
            });
        controllerGroup.AddOnClickEvent(UIControllerGroup.EType.Pause,
            () => {
                //Debug.Log("Pause");
                if (audioSource.isPlaying)
                    audioSource?.Pause();
                else
                    audioSource?.UnPause();
            });
        controllerGroup.AddOnClickEvent(UIControllerGroup.EType.Stop,
            () => {
                //Debug.Log("Stop");
                audioSource?.Stop();
            });

        audioSource.volume = volumeGroup.GetVolume();
        volumeGroup.SetChangedVolumeCallback(
            (float _vol) => 
            {
                audioSource.volume = _vol;
            });

        timelineGroup.UpdateTimeline(0f);
        timelineGroup.OnClickSkipCallback = OnClickSkipCallback;
    }

    private void Update()
    {
        if (audioSource.isPlaying)
            UpdateTimeline();
    }

    private void OnClickFileLoadCallback(AudioClip _clip)
    {
        fileNameGroup.SetFileName(_clip.name);
    }

    private void UpdateTimeline()
    {
        float clipLength = audioSource.clip.length;
        float time = audioSource.time; //time.Sample이 조금 더 정교함. 리듬게임만들때 사용할수있음
        float ratio = time / clipLength;

        timelineGroup.UpdateTimeline(ratio);
    }

    private void OnClickSkipCallback(float _time) {
        float skipTime = audioSource.time + _time;
        skipTime = Mathf.Clamp(skipTime, 0f, audioSource.clip.length - 0.001f);
        audioSource.time = skipTime;
        timelineGroup.UpdateTimeline(skipTime / audioSource.clip.length);
    }
}
