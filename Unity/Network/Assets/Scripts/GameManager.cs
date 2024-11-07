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

    // 각 클라이언트마다 생성된 플레이어 게임 오브젝트를 배열로 관리
    private GameObject[] playerGoList = new GameObject[4];
    // 미리 만들어놓지말고 Awake에서 photonNetwork에서 확인 가능한 현재 방의 최대 인원수만큼 동적할당 
    // CurrentRoom, CurrentLobby 등

    private void Start()
    {
        if (playerPrefab != null) {
            // PhotonNetwork.Instantiate를 사용하면 모두 동시에 생성됨
            // 각 컴퓨터마다 리소스 위치가 다르기 때문에 파일 명을 던져줘서 생성함
            GameObject go = PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f)), Quaternion.identity, 0);
            go.GetComponentInChildren<PlayerCtrl>().SetMaterial(PhotonNetwork.CurrentRoom.PlayerCount);
            // 1과제
            // 생성 자체는 Photon으로 동시에 생성하지만 그 이후에 세팅은 동기화되지 않음
            // 다른 플레이어의 색상도 보이도록 세팅하기
        }
    }


    // PhotonNetwork.LeaveRoom 함수가 호출되면 호출
    public override void OnLeftRoom()
    {
        Debug.Log("Left Room");

        SceneManager.LoadScene("Launcher");
    }

    // 플레이어가 입장할 때 호출되는 함수
    // 플레이어가 입장하면 방 안의 모두가 호출함
    public override void OnPlayerEnteredRoom(Player otherPlayer) 
        // photon에 있는 Player. 겹치지 않게 조심. using Photon.Pun;를 했기 때문에 네임스페이스 분리되어 있어도 player있으면 겹쳐버림
    {
        Debug.LogFormat("Player Entered Room: {0}", otherPlayer.NickName);

        // 누군가 접속하면 전체 클라이언트에서 함수 호출
        //ApplyPlayerList(); 하면 누군가 들어왔을 때 자동으로 해당 함수가 실행됨
        photonView.RPC("ApplyPlayerList", RpcTarget.All);
        // Remote Procedure Call
        // 누군가 새로 왔으니 갱신해라 라고 알림
        // photonView.RPC("함수명", RpcTarget.대상);
        // enum RpcTarget { All, Others, MasterClient, AllBuffered, OthersBuffered, AllViaServer, AllBufferedViaServer }
        // 모두가 갱신해라 서로 알림
        // 한명만 알리도록 해야함
    }

    [PunRPC] // 따로 저장
    public void ApplyPlayerList()
    {
        // 현재 방에 접속해 있는 플레이어의 수
        Debug.LogError("CurrentRoom PlayerCount : " + PhotonNetwork.CurrentRoom.PlayerCount);

        // 현재 생성되어 있는 모든 포톤뷰 가져오기
        PhotonView[] photonViews = FindObjectsOfType<PhotonView>();
        // 새로 누군가 들어올 때마다 모든 PhotonView 찾아서 가져옴

        // 매번 재정렬을 하는게 좋으므로 플레이어 게임오브젝트 리스트를 초기화
        System.Array.Clear(playerGoList, 0, playerGoList.Length);

        // 현재 생성되어 있는 포톤뷰 전체와
        // 접속중인 플레이어들의 액터넘버를 비교해,
        // 액터넘버를 기준으로 플레이어 게임오브젝트 배열을 채움
        for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; ++i)
        {
            // 키는 0이 아닌 1부터 시작
            int key = i + 1;
            for (int j = 0; j < photonViews.Length; ++j)
            {
                // 만약 PhotonNetwork.Instantiate를 통해서 생성된 포톤뷰가 아니라면 넘김
                // Photon은 PhotonView가 붙은 오브젝트를 계속 관리함 1초에 10번정도 통신함
                // 현재 Photon과 네트워크 상에서 관리되고 있는 PhotonView인지를 검사함
                if (photonViews[j].isRuntimeInstantiated == false) continue;
                // 만약 현재 키 값이 딕셔너리 내에 존재하지 않는다면 넘김
                if (PhotonNetwork.CurrentRoom.Players.ContainsKey(key) == false) continue;

                // 포톤뷰의 액터넘버
                int viewNum = photonViews[j].Owner.ActorNumber;
                // 접속중인 플레이어의 액터넘버. 이 서버에서 몇번째 앤지
                int playerNum = PhotonNetwork.CurrentRoom.Players[key].ActorNumber;

                // 액터넘버가 같은 오브젝트가 있다면,
                if (viewNum == playerNum)
                {
                    // 실제 게임오브젝트를 배열에 추가
                    playerGoList[playerNum - 1] = photonViews[j].gameObject;
                    // 게임오브젝트 이름도 알아보기 쉽게 변경
                    playerGoList[playerNum - 1].name = "Player_" + photonViews[j].Owner.NickName;
                }
            }
        }

        // 디버그용
        PrintPlayerList();
    }

    private void PrintPlayerList()
    {
        foreach (GameObject go in playerGoList)
        {
            if (go != null)
            {
                Debug.LogError(go.name);
                // 빌드 로그에는 에러로그만 떠서 보기 편하게 에러 로그로 해놨음
            }
        }
    }

    // PhotonNetwork.Instantiate로 만들어진 애들은 직접 관리해야하는 경우는 거의 없음
    // 연결하고 끊고 등은 알아서 해줌

    // 플레이어가 나갈 때 호출되는 함수
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player Left Room: {0}", otherPlayer.NickName);
    }

    public void LeaveRoom() {
        Debug.Log("Leave Room");

        PhotonNetwork.LeaveRoom();
    }

}
