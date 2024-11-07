using Photon.Pun;
using Photon.Realtime; // PhotonView ����ϱ� ����. ��ġ ����ȭ�ϴ� ��
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PhotonLauncher : MonoBehaviourPunCallbacks // ���� �׳� MonoBehaviourPun���� ��
{
    [SerializeField] private string gameVersion = "0.0.1";
    [SerializeField] private byte maxPlayerPerRoom = 4;
    [SerializeField] private string nickName = string.Empty;
    [SerializeField] private Button connectButton = null;

    private void Awake()
    {
        // ����Ƽ�� LoadScene�� ����ϸ� �ȵ�.
        // �����Ͱ� PhotonNetwork.LoadLevel()�� ȣ���ϸ�
        // ��� �÷��̾ ������ ������ �ڵ����� �ε�
        // �����Ͻð� �ʹ� �� ���� ���� ����
        // �ε����� ����� �ٸ� ����� ��� ���� �ε�Ǿ����� Ȯ�� �� ȭ�� ��ȯ�������
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        connectButton.interactable = true;
    }

    // ConnectButton�� �������� ȣ��
    public void Connect()
    {
        // null�� Empty�� ���ÿ� �˻��ϴ°� ���� �ϴ� �ͺ��� ����
        // string == ""���� isEmpty�� �� ����
        // ���ڿ��� ������ �޼ҵ� ���°� ����
        if (string.IsNullOrEmpty(nickName))
        {
            Debug.Log("NickName is empty");
            return;
        }

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom(); // ���� �� �ִ� ��� �߿� �� �� �ִ� �ƹ� ������ ��
            //PhotonNetwork.JoinLobby(); // �κ�
            //PhotonNetwork.JoinRoom(string RoomName); // �ش� �濡 ��
        }
        else {
            Debug.LogFormat("Connect: {0}", gameVersion);

            PhotonNetwork.GameVersion = gameVersion; // �� ������ ���� ������ ���ƾ���
            // ���� ���� �˻縦 ���� �ؾ���

            // ���� Ŭ���忡 ������ �����ϴ� ����
            // ���ӿ� �����ϸ� OnConnectedToMaster �޼��� ȣ��
            PhotonNetwork.ConnectUsingSettings();
            // ��Ʈ��ũ�� ����� �ٷ� ������ �ʱ� ������ callback���� ó����
            // �װ� ������ MonoBehaviourPunCallbacks�� ������ ��
        }
    }

    // InputField_NickName�� ������ �г����� ������
    public void OnValueChangedNickName(string _nickName) {
        nickName = _nickName;

        // ���� �̸� ����
        PhotonNetwork.NickName = nickName;
        // ���� �˻��� �� �ٷ� �г��ӹ޾��൵ ��
    }

    public override void OnConnectedToMaster() { // ������ ���� �ߴ��� ���ߴ��� �˻�
        Debug.LogFormat("Connected to Master: {0}", nickName);

        // �����ϱ� ��ư�� ������ ������ �����ϰų� �����Ҷ����� ��ư ��Ȱ��ȭ
        // ���ϸ� ��ư ����
        connectButton.interactable = false;

        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause) {
        Debug.LogWarningFormat("Disconnected: {0}", cause);

        connectButton.interactable = true;

        // ���� �����ϸ� OnJoinedRoom ȣ��
        Debug.Log("Create Room");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayerPerRoom });
        // CreateRoom (�� �̸�, �� �ɼ�, �κ� Ÿ�� ��)
    }

    public override void OnJoinedRoom() {
        Debug.Log("Joined Room");

        // �����Ͱ� ���ÿ� ������ �����ϰ� �ϴ� ������ �ƴϱ� ������ ���� ���� �θ��� ��
        // PhotonNetwork.LoadLevel("Room");
        // �����Ͱ� �����ϰ� �ϴ� ��� ȣ��Ʈ�� ȣ���ϸ� ��
        SceneManager.LoadScene("Room");
        // ���� ���� �ҷ��� PhotonNetwork �ȿ� �� ������ ����ȭ ����
    }

    public override void OnJoinRandomFailed(short returnCode, string message) {
        Debug.LogErrorFormat("JoinRandomFailed({0}): {1}", returnCode, message);

        connectButton.interactable = true;

        Debug.Log("Create Room");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayerPerRoom });
    }


}
