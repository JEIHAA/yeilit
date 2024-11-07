using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class BtnEvent : MonoBehaviour
{
    [SerializeField] private Player player = null;
    [SerializeField] private Button reButton = null;
    [SerializeField] private WallHoler wall = null;
    [SerializeField] private GameManager manager = null;

    private void Start()
    {
        initBtn();
        reButton.onClick.AddListener(reStart);
    }

    private void initBtn() {
        reButton.gameObject.SetActive(false);
    }

    public void reStart()
    {
        manager.Score = 0;
        wall.Respawn();
        reButton.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
        wall.gameObject.SetActive(true);
        Debug.Log(manager.Score);
    }
}
