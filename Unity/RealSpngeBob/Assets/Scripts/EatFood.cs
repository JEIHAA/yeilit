using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFood : MonoBehaviour
{
    [SerializeField] private FishFeed fishEatFood;
    [SerializeField] private float moveSpeed = 5f;
    private float arrivalDistance = 0.5f;
    private float rotationSpeed = 5f;
    private GameObject closestFishFeed = null;

    private void Update()
    {
        MoveToPoint();
        MoveToPoint();
    }
    private void MoveToPoint()
    {
        GameObject[] fishFeeds = GameObject.FindGameObjectsWithTag("FishFeed");
        if (fishFeeds.Length == 0) return;

        
        float closestDistance = Mathf.Infinity;

        foreach (GameObject fishFeed in fishFeeds)
        {
            float distance = Vector3.Distance(transform.position, fishFeed.transform.position);
            if (distance < closestDistance)
            {
                closestFishFeed = fishFeed;
                closestDistance = distance;
            }
        }

        if (closestFishFeed != null)
        {
            Vector3 targetPosition = closestFishFeed.transform.position;
            Vector3 directionToTarget = targetPosition - transform.position;
            float distanceToTarget = directionToTarget.magnitude;
            directionToTarget.Normalize();

            if (distanceToTarget <= arrivalDistance)
            {
                return;
            }

            // 현재 방향에서 목표 방향까지 90도 회전한 쿼터니언 계산
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget) * Quaternion.Euler(0, 90, 0);

            // 현재 회전을 목표 회전으로 부드럽게 보간
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // 도착하기 전까지 이동
            transform.position += directionToTarget * moveSpeed * Time.deltaTime;
        }
    }





}