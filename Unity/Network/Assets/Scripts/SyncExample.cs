using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

// #define, typedef
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class SyncExample : MonoBehaviour, IPunObservable // 포톤에서 옵저버 패턴
{
    // 동기화 하는 4가지 방법
    // Photon View, RPC, OnPhotonSerializeView, CustomProperties

    private string name = "SyncName";
    private int hp = 100;

    private void Start()
    {
        // 전역변수나 싱글톤처럼 값을 하나 저장해놓고 가져다 쓸 수 있음
        Hashtable ht = new Hashtable();

        ht.Add("HP", hp);
        ht.Add("Name", name);

        PhotonNetwork.LocalPlayer.SetCustomProperties(ht); // 플레이어한테 넣을 수도 있고 방에 넣을 수도 있음
        

        // 값 보기. 다른 클래스에서도 됨
        Hashtable receive = PhotonNetwork.LocalPlayer.CustomProperties;
        hp = (int)receive["HP"];
        name = (string)receive["Name"];
    }

    // 만들어두면 10프레임으로 계속 실행됨
    public void OnPhotonSerializeView(PhotonStream _stream, PhotonMessageInfo _msg) {
        if (_stream.IsWriting) // 보내는 쪽
        {
            _stream.SendNext(name);
            _stream.SendNext(hp);
            // transform 통채로 보내면 안됨 transform은 클래스임
            // 그래서 Vector가 구조체인것
        }
        else if (_stream.IsReading) // 받는 쪽
        {
            name = (string)_stream.ReceiveNext(); // 형변환 반드시 해줘야함
            hp = (int)_stream.ReceiveNext();
            transform.position = (Vector3)_stream.ReceiveNext();
        }
    }
}
