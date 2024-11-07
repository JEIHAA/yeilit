using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*[SerializeField] private GameObject playerGo = null;
    // GameObject에는 모든 것들이 들어가서 카메라 같은것도 들어감
    // Player라는 컴포넌트를 가지고 있지 않으면 GetComponent했을 때 NULL이 나옴*/

    [SerializeField] private Player player = null;
    // Player player처럼 컴포넌트의 이름으로 변수를 만들면 해당 컴포넌트를 가진 오브젝트만 넣을 수 있음

    private void Update()
    {
        float axisH = Input.GetAxis("Horizontal");
        /*Player playerComp = playerGo.GetComponent<Player>(); // <Player>: 템플릿
        // GetComponent 느림. Update에서 쓰면 안됨
        // Player 컴포넌트로 변수를 만들면 GetComponent도 할 필요가 없음
        playerComp.MoveHorizontal(axisH);*/
        player.MoveHorizontal(axisH);
    }
}
