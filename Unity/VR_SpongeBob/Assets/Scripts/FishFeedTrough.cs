using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class FishFeedTrough : MonoBehaviour
{
    [SerializeField] private GameObject feedPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int numberOfFeeds = 100;
    [SerializeField] private float spawnHeight = 10.0f; // ���� ����
    [SerializeField] InputActionProperty BButton;

    public void ClickBButton(InputAction.CallbackContext obj)
    {
        SpawnFeed();
        
    }

    private void Update()
    {
        BButton.action.performed += ClickBButton;
    }

    void SpawnFeed()
    {
        for (int i = 0; i < numberOfFeeds; i++)
        {
            Vector3 spawnPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y + spawnHeight, spawnPoint.position.z);
            GameObject fishFeedObj = Instantiate(feedPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
//����� /�ĵ� /���� /�ٴ尡 ������ ÷���Ҹ�