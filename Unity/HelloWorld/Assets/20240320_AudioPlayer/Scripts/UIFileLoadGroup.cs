using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFileLoadGroup : MonoBehaviour
{
    public delegate void OnClickFileLoadDelegate(AudioClip _clip);
    private OnClickFileLoadDelegate onClickFileLoadCallback = null;
    public OnClickFileLoadDelegate OnClickFileLoadCallback
    {
        set { onClickFileLoadCallback = value; }
    }

    private string fileName = null;

    public void OnChangedFileName(string _fileName)
    {
        //Debug.Log(_fileName);
        fileName = _fileName;
    }

    public void OnClickFileLoad() {
        //Debug.Log("File Load");
        AudioClip clip = ResourceManager.Instance.LoadAudioClip(fileName);
        if (clip != null) {
            /*if (onClickFileLoadCallback != null)
                onClickFileLoadCallback(clip);*/
            onClickFileLoadCallback?.Invoke(clip);
        }else
        {
            Debug.LogError(fileName + "load failed");
        }
    }

}
