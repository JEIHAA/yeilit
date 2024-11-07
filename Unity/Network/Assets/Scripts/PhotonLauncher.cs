using Photon.Pun;
using Photon.Realtime; // PhotonView 사용하기 위함. 위치 동기화하는 거
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PhotonLauncher : MonoBehaviourPunCallbacks // 이제 그냥 MonoBehaviourPun쓰면 됨
{
    [SerializeField] private string gameVersion = "0.0.1";
    [SerializeField] private byte maxPlayerPerRoom = 4;
    [SerializeField] private string nickName = string.Empty;
    [SerializeField] private Button connectButton = null;

    private void Awake()
    {
        // 유니티의 LoadScene을 사용하면 안됨.
        // 마스터가 PhotonNetwork.LoadLevel()을 호출하면
        // 모든 플레이어가 동일한 레벨을 자동으로 로드
        // 레이턴시가 너무 길어서 별로 좋진 않음
        // 로딩씬도 만들고 다른 사람들 모두 씬이 로드되었는지 확인 후 화면 전환해줘야함
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        connectButton.interactable = true;
    }

    // ConnectButton이 눌러지면 호출
    public void Connect()
    {
        // null과 Empty를 동시에 검사하는게 따로 하는 것보다 빠름
        // string == ""보다 isEmpty가 더 빠름
        // 문자열은 무조건 메소드 쓰는게 빠름
        if (string.IsNullOrEmpty(nickName))
        {
            Debug.Log("NickName is empty");
            return;
        }

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom(); // 서버 상에 있는 방들 중에 들어갈 수 있는 아무 방으로 들어감
            //PhotonNetwork.JoinLobby(); // 로비
            //PhotonNetwork.JoinRoom(string RoomName); // 해당 방에 들어감
        }
        else {
            Debug.LogFormat("Connect: {0}", gameVersion);

            PhotonNetwork.GameVersion = gameVersion; // 내 버전과 서버 버전이 같아야함
            // 원래 버전 검사를 먼저 해야함

            // 포톤 클라우드에 접속을 시작하는 지점
            // 접속에 성공하면 OnConnectedToMaster 메서드 호출
            PhotonNetwork.ConnectUsingSettings();
            // 네트워크는 결과가 바로 나오지 않기 때문에 callback으로 처리됨
            // 그것 때문에 MonoBehaviourPunCallbacks을 가지고 옴
        }
    }

    // InputField_NickName과 연결해 닉네임을 가져옴
    public void OnValueChangedNickName(string _nickName) {
        nickName = _nickName;

        // 유저 이름 지정
        PhotonNetwork.NickName = nickName;
        // 버전 검사할 때 바로 닉네임받아줘도 됨
    }

    public override void OnConnectedToMaster() { // 서버에 접속 했는지 안했는지 검사
        Debug.LogFormat("Connected to Master: {0}", nickName);

        // 접속하기 버튼을 누르고 접속이 실패하거나 성공할때까지 버튼 비활성화
        // 안하면 버튼 갈김
        connectButton.interactable = false;

        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause) {
        Debug.LogWarningFormat("Disconnected: {0}", cause);

        connectButton.interactable = true;

        // 방을 생성하면 OnJoinedRoom 호출
        Debug.Log("Create Room");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayerPerRoom });
        // CreateRoom (방 이름, 방 옵션, 로비 타입 등)
    }

    public override void OnJoinedRoom() {
        Debug.Log("Joined Room");

        // 마스터가 동시에 게임을 시작하게 하는 구조가 아니기 때문에 각자 씬을 부르면 됨
        // PhotonNetwork.LoadLevel("Room");
        // 마스터가 시작하게 하는 경우 호스트만 호출하면 됨
        SceneManager.LoadScene("Room");
        // 각자 씬을 불러도 PhotonNetwork 안에 들어가 있으면 동기화 해줌
    }

    public override void OnJoinRandomFailed(short returnCode, string message) {
        Debug.LogErrorFormat("JoinRandomFailed({0}): {1}", returnCode, message);

        connectButton.interactable = true;

        Debug.Log("Create Room");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayerPerRoom });
    }


}
