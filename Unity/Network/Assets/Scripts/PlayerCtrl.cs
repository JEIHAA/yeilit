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
        // ��Ʈ��ũ�� ��� �ÿ� ������ ������ ���� �����ϰ� �������� ����ΰͰ����� ������ ��� Instantiate�� �����Ǵ� ����. �� �����Ҵ� �Ǿ �����ϴ� ����
        // ���̾��Ű���� ����. Ű �Է� ������ �ٸ� �ֵ鵵 �� ����ȴٴ� ��. MonoBehaviour�� �÷��̾� �� ��ŭ �� ���ư��� �ִٴ� ��

        // �� ȭ�鿡 �Ȱ��� ����(����)�� �ٸ� ����� �ƴ϶� ���� ��������� ��, ��¥ �� �϶� IsMine�� true�� ����
        // ��¥ �� �ڽſ� ���� ó���� �ؾ��ϱ� ������ IsMine�� ���� ���� ��
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

        // �� ���� �ٲٴ°� �ƴ϶� �ٸ� �ֵ����׵� �� ���� �ٲٶ�� ���ؾ���
        // �׷����� ���� �������� �ٸ� �ֵ��� �˾ƾ���
        // �װ� ��� �ϳİ� 1����
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

    [PunRPC] // �����Ͱ� �ִ� ������ �ƴϱ� ������ �ٸ� �ֵ����� ���� �� ������� ����
    public void ApplyHP(int _hp) {
        hp = _hp; // ü���� ��°� �ƴ϶� ��� �÷��̾ ���� �� ü���� �ٲ� ü������ �ٲ�ִ� ��
        Debug.LogErrorFormat("{0} Hp: {1}", PhotonNetwork.NickName, hp);

        if (hp <= 0) {
            Debug.LogErrorFormat("Destroy: {0}", PhotonNetwork.NickName);
            isDead = true;
            PhotonNetwork.Destroy(this.gameObject);
            // PhotonNetwork.Instantiate���� ������༭ Photon���� �����ϰ� ������ PhotonNetwork.Destroy���� Photon���� ���������
            // ����Ƽ Destroy�� ����ϸ� �� ȭ�鿡���� ������. ����Ʈ������ ó���Ҷ� ���
        }
    }

    // �¾����� �ٸ� ����鿡�� ü�� �����϶�� �˸�
    // Ŭ���̾�Ʈ ������ŭ �� ���� �÷��̾� ����ŭ���� �����°� �ƴ϶�
    // �ٸ� Ŭ���̾�Ʈ�� ������ ������ ����
    [PunRPC] 
    public void OnDamage(int _dmg) {
        hp -= _dmg; // ���� �̹� �����߱� ������ �� ���� �ٸ� �ֵ� �����ض�. RpcTarget.Others
        photonView.RPC("ApplyHp", RpcTarget.Others, hp);
        // RPC�� ������ ���� hp���� ���� �ؾ���.
        // Ŭ����ó�� �ּҰ��� �� ������ �ȵ�
        // ���� �Ҵ�޾� ������� �ּҿ� �ٸ� ��ǻ�Ϳ��� �Ҵ�Ǿ� �ִ� �ּҰ� �������� ����..
    }

}
