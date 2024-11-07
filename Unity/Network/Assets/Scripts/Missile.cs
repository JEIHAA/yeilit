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
        // PhotonNetwork.Instantiate�� ������� ����
        PhotonNetwork.Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!photonView.IsMine) return;
        // ���� ���� �Ѿ� �ƴϸ� ó�� ����
        // ���� �� ó���Ϸ��� �ϸ� Ŭ���̾�Ʈ ������ŭ ó���ؾ��ϴµ�
        // ������ ����� Ŭ���̾�Ʈ 4���� �Ѵ�°� 4�� ����
        // ������ ó���ϴ� ������ �������

        if (owner != other.gameObject &&
            other.CompareTag("Player"))
        {
            other.GetComponent<PlayerCtrl>().OnDamage(1); // ���� ���� PlayerCtrl�� OnDamage
            // ������ ������� Ŭ���̾�Ʈ�� �÷��̾ �ƴ϶�
            // �� Ŭ���̾�Ʈ�� ������� ���� ���� �н� hp�� ��°���
            // �� Ŭ���̾�Ʈ�� ������� ���� ���� �н��� hp�� ��� �ٸ� Ŭ���̾�Ʈ�� �ڽſ��� RPC�� ������ ��
            SelfDestroy();
        }
    }
}

