using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using System.Runtime.InteropServices;


public class Missile : MonoBehaviourPun
{
    private bool isShoot = false;
    private Vector3 direction = Vector3.zero;
    private float speed = 10.0f;
    private float duration = 5.0f;
    private GameObject owner = null;


    private void Update()
    {
        if (isShoot)
        {
            this.transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    public void Shoot(GameObject _owner, Vector3 _dir)
    {
        owner = _owner;
        direction = _dir;
        isShoot = true;

        if (photonView.IsMine) Invoke("SelfDestroy", duration);
    }

    private void SelfDestroy()
    {
        // PhotonNetwork.Instantiate로 만들어진 애임
        PhotonNetwork.Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!photonView.IsMine) return;
        // 내가 만든 총알 아니면 처리 안함
        // 전부 다 처리하려고 하면 클라이언트 개수만큼 처리해야하는데
        // 복잡함 어려움 클라이언트 4개면 한대맞고 4번 아픔
        // 서버가 처리하는 구조면 상관없음

        if (owner != other.gameObject &&
            other.CompareTag("Player"))
        {
            other.GetComponent<PlayerCtrl>().OnDamage(1); // 맞은 애의 PlayerCtrl에 OnDamage
            // 실제로 만들어진 클라이언트의 플레이어가 아니라
            // 내 클라이언트에 만들어진 맞은 애의 분신 hp를 까는거임
            // 내 클라이언트에 만들어진 맞은 애의 분신이 hp를 까고 다른 클라이언트의 자신에게 RPC를 보내는 것
            SelfDestroy();
        }
    }
}

