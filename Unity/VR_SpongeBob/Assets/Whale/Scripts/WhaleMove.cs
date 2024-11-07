using UnityEngine;

public class WhaleMove : MonoBehaviour
{
    public float moveSpeed = 5f; // ������� �̵� �ӵ�
    public float rotationSpeed = 2f; // ������� ȸ�� �ӵ�
    public float perceptionRadius = 5f; // �ֺ� ȯ���� �����ϴ� �ݰ�

    private Vector3 targetPosition; // ����Ⱑ ���� ��ǥ ��ġ

    void Start()
    {
        SetRandomTarget(); // �ʱ� ��ǥ ��ġ ����
    }

    void Update()
    {
        // ����Ⱑ ��ǥ ��ġ�� �̵�
        Vector3 horizontalDirection = (targetPosition - transform.position).normalized;
        Vector3 horizontalMovement = horizontalDirection * moveSpeed * Time.deltaTime;
        horizontalMovement.y = 0f; // y�� �̵� ����
        transform.position += horizontalMovement;

        // ����Ⱑ ��ǥ ������ ���� ȸ��
        Quaternion targetRotation = Quaternion.LookRotation(-horizontalDirection); // ���� �ݴ�� ����
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // �ֺ� ȯ���� �����Ͽ� �ൿ ����
        Collider[] colliders = Physics.OverlapSphere(transform.position, perceptionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Obstacle"))
            {
                // ��ֹ��� �����Ǹ� ���ο� ��ǥ ��ġ ����
                SetRandomTarget();
                break;
            }
        }

        // ��ǥ ��ġ�� �����ϸ� ���ο� ��ǥ ��ġ ����
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTarget();
        }
    }

    // ������� ���ο� ��ǥ ��ġ�� �����ϰ� �����ϴ� �Լ�
    void SetRandomTarget()
    {
        targetPosition = new Vector3(Random.Range(-10f, 10f), transform.position.y, Random.Range(-10f, 10f)); // y�� �̵� ����
    }
}