using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UITimelineGroup : MonoBehaviour
{
    private enum EType { Backward, Forward }
    
    public delegate void OnClickSkipDelegate(float _time);
    private OnClickSkipDelegate onClickSkipCallback = null;
    public OnClickSkipDelegate OnClickSkipCallback { 
        set { onClickSkipCallback = value; }
    }

    private UITimeline timeline = null;
    private Button[] skipBtns = null;

    private void Awake()
    {
        timeline = GetComponentInChildren<UITimeline>();
        skipBtns = GetComponentsInChildren<Button>();
        skipBtns[(int)EType.Backward].onClick.AddListener(
            () => {
                onClickSkipCallback?.Invoke(-10f);
            });

        skipBtns[(int)EType.Forward].onClick.AddListener(
            () => {
                onClickSkipCallback?.Invoke(10f);
            });
    }

    public void UpdateTimeline(float _ratio) {
        timeline.UpdateTimeline(_ratio);
    }
}
