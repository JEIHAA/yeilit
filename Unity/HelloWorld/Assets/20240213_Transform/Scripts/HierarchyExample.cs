using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HierarchyExample : MonoBehaviour
{
    private Transform testChild = null;

    private void Start() {
        Transform tr = GetComponent<Transform>();
        //transform. 모든 오브젝트가 가지고 있기 때문에 이미 만들어져있음. 가지고 오지 않아도 불러와서 쓸 수 있음 

        Transform childTr = GetComponentInChildren<Transform>(gameObject); // 자식들이 가지고 있는 컴포넌트 중에 가져오기
        Debug.Log("childTr: " + childTr.name); // 부모가 가진 컴포넌트도 포함해서 검사한 후 가장 첫번째를 가져옴(부모가 가지고 있으면 부모 것이 가져와짐)

        Child child = GetComponentInChildren<Child>(); // Child라는 요소를 가진 컴포넌트에서 가져옴
        Debug.Log("child: " + child.name);

        Transform[] childTrs = GetComponentsInChildren<Transform>();

        for (int i = 0; i < childTrs.Length; i++) {
            Debug.LogFormat("childTrs[{0}] : {1}", i, childTrs[i].name);
        }

        testChild = GetComponentInChildren<Child>().transform;

    }

    private void Update()
    {
        //TranslateChild();
        //RotateChild();
        ScaleChild();
    }

    private void TranslateChild() {
        // Mathf.Abs(Mathf.Sin); Sin값의 절대값으로 움직임 0~1에서 왔다갔다
        //testChild.position = Vector3.up * Mathf.Abs(Mathf.Sin(Time.time*5f));  // 월드 좌표에서 0~1 사이를 왔다갔다
        testChild.localPosition = Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 5f)); // 부모를 기준으로 상대값 0~1 사이를 왔다갔다
    }

    private void RotateChild()
    {
        // Quaternion 사원수
        //testChild.rotation
        // Pitch, Yaw, Roll : x축 회전, y축 회전, z축 회전
        // 유니티에서는 구분 안되어 있지만 언리얼에서는 함수 이름이 Pitch, Yaw, Roll임
        testChild.localRotation = Quaternion.Euler(0f, Time.time * 100f, 0f); // 값을 읽어올 때는 Euler로 해도 됨, 값을 넣어줄 때 Euler로 하면 안됨
    }

    private void ScaleChild() {
        // testChild.scale은 없음
        testChild.localScale = Vector3.one * Mathf.Sin(Time.time * 5f);   
    }



    private void OnDrawGizmos()
    {
        // RGB
        // XYZ
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, Vector3.right);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero, Vector3.up);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Vector3.zero, Vector3.left);

        Gizmos.color = Color.white;
    }
}
