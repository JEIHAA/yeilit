using UnityEngine;

public class WhaleMove : MonoBehaviour
{
    public float moveSpeed = 5f; // 물고기의 이동 속도
    public float rotationSpeed = 2f; // 물고기의 회전 속도
    public float perceptionRadius = 5f; // 주변 환경을 감지하는 반경

    private Vector3 targetPosition; // 물고기가 향할 목표 위치

    void Start()
    {
        SetRandomTarget(); // 초기 목표 위치 설정
    }

    void Update()
    {
        // 물고기가 목표 위치로 이동
        Vector3 horizontalDirection = (targetPosition - transform.position).normalized;
        Vector3 horizontalMovement = horizontalDirection * moveSpeed * Time.deltaTime;
        horizontalMovement.y = 0f; // y축 이동 제거
        transform.position += horizontalMovement;

        // 물고기가 목표 방향을 향해 회전
        Quaternion targetRotation = Quaternion.LookRotation(-horizontalDirection); // 방향 반대로 설정
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // 주변 환경을 감지하여 행동 결정
        Collider[] colliders = Physics.OverlapSphere(transform.position, perceptionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Obstacle"))
            {
                // 장애물이 감지되면 새로운 목표 위치 설정
                SetRandomTarget();
                break;
            }
        }

        // 목표 위치에 도달하면 새로운 목표 위치 설정
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTarget();
        }
    }

    // 물고기의 새로운 목표 위치를 랜덤하게 설정하는 함수
    void SetRandomTarget()
    {
        targetPosition = new Vector3(Random.Range(-10f, 10f), transform.position.y, Random.Range(-10f, 10f)); // y축 이동 제거
    }
}