using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI; // NavMeshAgent를 사용하려면 추가해줘야함

public class AgentController : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Vector3 destination = Vector3.zero;
    private Vector3[] waypointRay = new Vector3[5];
    private bool isMoving = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0)&&Input.GetKeyDown(KeyCode.LeftShift) )*/
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Shift");
            Debug.Log("Click");
            if (RaycastProcess(ref destination))
            {
                //SetDestinationArray();
            }
        }
        /*else if (Input.GetMouseButtonDown(0))
        {
            if (RaycastProcess(ref destination))
            {
                agent.SetDestination(destination);
            }
        }*/
        /*if (isMoving)
        {
            agent.SetDestination(destination);
        }*/
    }


    private bool RaycastProcess(ref Vector3 _point) {
        /*Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 dir = mousePos - Camera.main.transform.position;
        dir.Normalize();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        NavMeshHit hit;
        if (NavMesh.Raycast(ray.origin, ray.direction * 100f, out hit, NavMesh.AllAreas)) {  // ray.origin: ray의 시작위치, ray.direction: ray 방향
        }

        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);*/
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            _point = hit.point;
            return true;
        }
        return false;
    }

/*    private bool ArrayRaycastProcess(Vector3[] _point)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit)) {
            Debug.Log("hit"+hit.point);
            _point = hit.point;
        }        
        return true;
    }*/

    // 클

    private void SetDestinationArray(Vector3 _point) {
        for (int i = 0; i < waypointRay.Length; ++i)
        {
            Debug.Log(waypointRay[i]);
            if (!isMoving) { 
                isMoving = true;
                agent.SetDestination(waypointRay[i]);
                
            }
            isMoving = false;
        }
    }
    /*
        private void AgentRaycast()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit){
                NavMeshHit navHit;
                if (agent.Raycast(hit.point, out navHit)) {
                    Debug.Log(navHit.position);
                }
            }
        }*/
}
