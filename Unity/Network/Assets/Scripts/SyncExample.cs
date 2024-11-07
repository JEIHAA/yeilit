using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

// #define, typedef
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class SyncExample : MonoBehaviour, IPunObservable // ���濡�� ������ ����
{
    // ����ȭ �ϴ� 4���� ���
    // Photon View, RPC, OnPhotonSerializeView, CustomProperties

    private string name = "SyncName";
    private int hp = 100;

    private void Start()
    {
        // ���������� �̱���ó�� ���� �ϳ� �����س��� ������ �� �� ����
        Hashtable ht = new Hashtable();

        ht.Add("HP", hp);
        ht.Add("Name", name);

        PhotonNetwork.LocalPlayer.SetCustomProperties(ht); // �÷��̾����� ���� ���� �ְ� �濡 ���� ���� ����
        

        // �� ����. �ٸ� Ŭ���������� ��
        Hashtable receive = PhotonNetwork.LocalPlayer.CustomProperties;
        hp = (int)receive["HP"];
        name = (string)receive["Name"];
    }

    // �����θ� 10���������� ��� �����
    public void OnPhotonSerializeView(PhotonStream _stream, PhotonMessageInfo _msg) {
        if (_stream.IsWriting) // ������ ��
        {
            _stream.SendNext(name);
            _stream.SendNext(hp);
            // transform ��ä�� ������ �ȵ� transform�� Ŭ������
            // �׷��� Vector�� ����ü�ΰ�
        }
        else if (_stream.IsReading) // �޴� ��
        {
            name = (string)_stream.ReceiveNext(); // ����ȯ �ݵ�� �������
            hp = (int)_stream.ReceiveNext();
            transform.position = (Vector3)_stream.ReceiveNext();
        }
    }
}
