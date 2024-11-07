using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrepareGame : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI countText = null;

    private void Start()
    {
        countText.gameObject.SetActive(false);
    }

    [PunRPC]
    public void SetGame()
    {
        photonView.RPC("Countdown", RpcTarget.All);
    }

    [PunRPC]
    private IEnumerator Countdown() {
        
        Debug.LogErrorFormat("Countdown");
        countText.gameObject.SetActive(true);
        countText.text = "3";
        yield return new WaitForSecondsRealtime(1);
        countText.text = "2";
        yield return new WaitForSecondsRealtime(1);
        countText.text = "1";
        yield return new WaitForSecondsRealtime(1);
        countText.text = "Go!";
        yield return new WaitForSecondsRealtime(1);
        countText.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
