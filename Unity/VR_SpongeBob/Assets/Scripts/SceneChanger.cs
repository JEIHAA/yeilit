using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Collider player = null;

    private void OnTriggerEnter(Collider other)
    {
        LoadingScenesManager.LoadScene("VR_SpongeBob");
    }

}
