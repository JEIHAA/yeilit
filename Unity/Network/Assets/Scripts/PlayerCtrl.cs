using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerCtrl : MonoBehaviourPun
{
    private Rigidbody rb = null;

    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] private Color[] colors = null;
    [SerializeField] private float speed = 3.0f;

    private int hp = 3;
    private bool isDead = false;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        isDead = false;
    }

    private void Update()
    {
        // 네트워크로 통신 시에 실제로 실행한 나만 존재하고 나머지는 허상인것같지만 실제로 모두 Instantiate로 생성되는 것임. 다 동적할당 되어서 존재하는 거임
        // 하이어라키에도 생김. 키 입력 받으면 다른 애들도 다 적용된다는 뜻. MonoBehaviour가 플레이어 수 만큼 다 돌아가고 있다는 뜻

        // 내 화면에 똑같이 생성(복사)된 다른 사람이 아니라 내가 만들어졌을 때, 진짜 나 일때 IsMine이 true가 들어옴
        // 진짜 나 자신에 대한 처리만 해야하기 때문에 IsMine을 많이 쓰게 됨
        if (!photonView.IsMine) return;
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.W))
            rb.AddForce(Vector3.forward * speed);
        if (Input.GetKeyDown(KeyCode.S))
            rb.AddForce(Vector3.back * speed);
        if (Input.GetKeyDown(KeyCode.A))
            rb.AddForce(Vector3.left * speed);
        if (Input.GetKeyDown(KeyCode.D))
            rb.AddForce(Vector3.right * speed);

        if (Input.GetMouseButtonDown(0)) ShootBullet();

        LookAtMouseCursor();
    }

    public void SetMaterial(int _playerNum)
    {
        Debug.LogError(_playerNum + " : " + colors.Length);
        if (_playerNum > colors.Length) return;

        this.GetComponent<MeshRenderer>().material.color = colors[_playerNum - 1];

        // 내 색만 바꾸는게 아니라 다른 애들한테도 내 색을 바꾸라고 말해야함
        // 그러러면 내가 누구인지 다른 애들이 알아야함
        // 그걸 어떻게 하냐가 1과제
    }

    private void ShootBullet()
    {
        if (bulletPrefab)
        {
            GameObject go = PhotonNetwork.Instantiate(bulletPrefab.name, this.transform.position, Quaternion.identity);
            go.GetComponentInChildren<Missile>().Shoot(this.gameObject, this.transform.forward);
        }
    }

    public void LookAtMouseCursor()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 dir = mousePos - playerPos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(-angle + 90.0f, Vector3.up);
    }

    [PunRPC] // 마스터가 있는 구조가 아니기 때문에 다른 애들한테 전부 피 깎으라고 보냄
    public void ApplyHP(int _hp) {
        hp = _hp; // 체력을 깎는게 아니라 모든 플레이어가 맞은 애 체력을 바뀐 체력으로 바꿔넣는 것
        Debug.LogErrorFormat("{0} Hp: {1}", PhotonNetwork.NickName, hp);

        if (hp <= 0) {
            Debug.LogErrorFormat("Destroy: {0}", PhotonNetwork.NickName);
            isDead = true;
            PhotonNetwork.Destroy(this.gameObject);
            // PhotonNetwork.Instantiate으로 만들어줘서 Photon에서 관리하고 있으니 PhotonNetwork.Destroy으로 Photon에서 없애줘야함
            // 유니티 Destroy를 사용하면 내 화면에서만 없어짐. 이펙트같은거 처리할때 사용
        }
    }

    // 맞았으니 다른 사람들에게 체력 갱신하라고 알림
    // 클라이언트 개수만큼 그 안의 플레이어 수만큼한테 보내는게 아니라
    // 다른 클라이언트의 나에게 보내는 것임
    [PunRPC] 
    public void OnDamage(int _dmg) {
        hp -= _dmg; // 나는 이미 갱신했기 때문에 나 빼고 다른 애들 갱신해라. RpcTarget.Others
        photonView.RPC("ApplyHp", RpcTarget.Others, hp);
        // RPC에 던지는 값은 hp같은 값만 해야함.
        // 클래스처럼 주소같은 걸 보내면 안됨
        // 내가 할당받아 사용중인 주소와 다른 컴퓨터에서 할당되어 있는 주소가 같을리가 없음..
    }

}
