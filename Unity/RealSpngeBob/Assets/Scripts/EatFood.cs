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

            // ���� ���⿡�� ��ǥ ������� 90�� ȸ���� ���ʹϾ� ���
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget) * Quaternion.Euler(0, 90, 0);

            // ���� ȸ���� ��ǥ ȸ������ �ε巴�� ����
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // �����ϱ� ������ �̵�
            transform.position += directionToTarget * moveSpeed * Time.deltaTime;
        }
    }





}