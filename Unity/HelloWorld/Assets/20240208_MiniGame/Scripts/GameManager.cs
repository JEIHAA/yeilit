using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player = null;
    [SerializeField] private Button reButton = null;
    [SerializeField] private WallHoler wall = null;

    private int score = 0;

/*    public delegate int GetScoreDelegate();
    private GetScoreDelegate getScoreCallback = null;
    public GetScoreDelegate GetScoreCallback { get { return getScoreCallback; } set { getScoreCallback = value; } }*/
    
    public int Score { get { return score; } set { score = value; } }

    private void Start()
    {
        player.CollisionCallback = OnCollisionAtWall; // Delegate�� �Լ� ������ �����Ŷ� �Լ��� ȣ���ϴ°� �ƴ϶� �Լ��� �ּҸ� �־���
        player.TriggerCallback = OnTriggerAtGate;
    }

    private void OnCollisionAtWall() {
        //Debug.Break();
        player.gameObject.SetActive(false);
        reButton.gameObject.SetActive(true);
        Debug.Log("YOU DIE");
        wall.gameObject.SetActive(false);
    }

    private void OnTriggerAtGate() {
        ++score;
        Debug.Log("Score : " + score);
    }
}
