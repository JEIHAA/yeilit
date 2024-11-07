using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab = null;

    // �� Ŭ���̾�Ʈ���� ������ �÷��̾� ���� ������Ʈ�� �迭�� ����
    private GameObject[] playerGoList = new GameObject[4];
    // �̸� ������������ Awake���� photonNetwork���� Ȯ�� ������ ���� ���� �ִ� �ο�����ŭ �����Ҵ� 
    // CurrentRoom, CurrentLobby ��

    private void Start()
    {
        if (playerPrefab != null) {
            // PhotonNetwork.Instantiate�� ����ϸ� ��� ���ÿ� ������
            // �� ��ǻ�͸��� ���ҽ� ��ġ�� �ٸ��� ������ ���� ���� �����༭ ������
            GameObject go = PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f)), Quaternion.identity, 0);
            go.GetComponentInChildren<PlayerCtrl>().SetMaterial(PhotonNetwork.CurrentRoom.PlayerCount);
            // 1����
            // ���� ��ü�� Photon���� ���ÿ� ���������� �� ���Ŀ� ������ ����ȭ���� ����
            // �ٸ� �÷��̾��� ���� ���̵��� �����ϱ�
        }
    }


    // PhotonNetwork.LeaveRoom �Լ��� ȣ��Ǹ� ȣ��
    public override void OnLeftRoom()
    {
        Debug.Log("Left Room");

        SceneManager.LoadScene("Launcher");
    }

    // �÷��̾ ������ �� ȣ��Ǵ� �Լ�
    // �÷��̾ �����ϸ� �� ���� ��ΰ� ȣ����
    public override void OnPlayerEnteredRoom(Player otherPlayer) 
        // photon�� �ִ� Player. ��ġ�� �ʰ� ����. using Photon.Pun;�� �߱� ������ ���ӽ����̽� �и��Ǿ� �־ player������ ���Ĺ���
    {
        Debug.LogFormat("Player Entered Room: {0}", otherPlayer.NickName);

        // ������ �����ϸ� ��ü Ŭ���̾�Ʈ���� �Լ� ȣ��
        //ApplyPlayerList(); �ϸ� ������ ������ �� �ڵ����� �ش� �Լ��� �����
        photonView.RPC("ApplyPlayerList", RpcTarget.All);
        // Remote Procedure Call
        // ������ ���� ������ �����ض� ��� �˸�
        // photonView.RPC("�Լ���", RpcTarget.���);
        // enum RpcTarget { All, Others, MasterClient, AllBuffered, OthersBuffered, AllViaServer, AllBufferedViaServer }
        // ��ΰ� �����ض� ���� �˸�
        // �Ѹ� �˸����� �ؾ���
    }

    [PunRPC] // ���� ����
    public void ApplyPlayerList()
    {
        // ���� �濡 ������ �ִ� �÷��̾��� ��
        Debug.LogError("CurrentRoom PlayerCount : " + PhotonNetwork.CurrentRoom.PlayerCount);

        // ���� �����Ǿ� �ִ� ��� ����� ��������
        PhotonView[] photonViews = FindObjectsOfType<PhotonView>();
        // ���� ������ ���� ������ ��� PhotonView ã�Ƽ� ������

        // �Ź� �������� �ϴ°� �����Ƿ� �÷��̾� ���ӿ�����Ʈ ����Ʈ�� �ʱ�ȭ
        System.Array.Clear(playerGoList, 0, playerGoList.Length);

        // ���� �����Ǿ� �ִ� ����� ��ü��
        // �������� �÷��̾���� ���ͳѹ��� ����,
        // ���ͳѹ��� �������� �÷��̾� ���ӿ�����Ʈ �迭�� ä��
        for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; ++i)
        {
            // Ű�� 0�� �ƴ� 1���� ����
            int key = i + 1;
            for (int j = 0; j < photonViews.Length; ++j)
            {
                // ���� PhotonNetwork.Instantiate�� ���ؼ� ������ ����䰡 �ƴ϶�� �ѱ�
                // Photon�� PhotonView�� ���� ������Ʈ�� ��� ������ 1�ʿ� 10������ �����
                // ���� Photon�� ��Ʈ��ũ �󿡼� �����ǰ� �ִ� PhotonView������ �˻���
                if (photonViews[j].isRuntimeInstantiated == false) continue;
                // ���� ���� Ű ���� ��ųʸ� ���� �������� �ʴ´ٸ� �ѱ�
                if (PhotonNetwork.CurrentRoom.Players.ContainsKey(key) == false) continue;

                // ������� ���ͳѹ�
                int viewNum = photonViews[j].Owner.ActorNumber;
                // �������� �÷��̾��� ���ͳѹ�. �� �������� ���° ����
                int playerNum = PhotonNetwork.CurrentRoom.Players[key].ActorNumber;

                // ���ͳѹ��� ���� ������Ʈ�� �ִٸ�,
                if (viewNum == playerNum)
                {
                    // ���� ���ӿ�����Ʈ�� �迭�� �߰�
                    playerGoList[playerNum - 1] = photonViews[j].gameObject;
                    // ���ӿ�����Ʈ �̸��� �˾ƺ��� ���� ����
                    playerGoList[playerNum - 1].name = "Player_" + photonViews[j].Owner.NickName;
                }
            }
        }

        // ����׿�
        PrintPlayerList();
    }

    private void PrintPlayerList()
    {
        foreach (GameObject go in playerGoList)
        {
            if (go != null)
            {
                Debug.LogError(go.name);
                // ���� �α׿��� �����α׸� ���� ���� ���ϰ� ���� �α׷� �س���
            }
        }
    }

    // PhotonNetwork.Instantiate�� ������� �ֵ��� ���� �����ؾ��ϴ� ���� ���� ����
    // �����ϰ� ���� ���� �˾Ƽ� ����

    // �÷��̾ ���� �� ȣ��Ǵ� �Լ�
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player Left Room: {0}", otherPlayer.NickName);
    }

    public void LeaveRoom() {
        Debug.Log("Leave Room");

        PhotonNetwork.LeaveRoom();
    }

}
