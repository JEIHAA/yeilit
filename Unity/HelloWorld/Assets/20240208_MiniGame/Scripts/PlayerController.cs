using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*[SerializeField] private GameObject playerGo = null;
    // GameObject���� ��� �͵��� ���� ī�޶� �����͵� ��
    // Player��� ������Ʈ�� ������ ���� ������ GetComponent���� �� NULL�� ����*/

    [SerializeField] private Player player = null;
    // Player playeró�� ������Ʈ�� �̸����� ������ ����� �ش� ������Ʈ�� ���� ������Ʈ�� ���� �� ����

    private void Update()
    {
        float axisH = Input.GetAxis("Horizontal");
        /*Player playerComp = playerGo.GetComponent<Player>(); // <Player>: ���ø�
        // GetComponent ����. Update���� ���� �ȵ�
        // Player ������Ʈ�� ������ ����� GetComponent�� �� �ʿ䰡 ����
        playerComp.MoveHorizontal(axisH);*/
        player.MoveHorizontal(axisH);
    }
}
