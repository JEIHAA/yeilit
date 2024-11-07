using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineCounter : MonoBehaviour
{
    /*    private void Start()
        {
            StartCoroutine(CounterCoroutine());
        }*/

    private void OnEnable() { // ��ũ��Ʈ�� ���� �� ȣ���. ���� �����ؼ� �־��� ���� ȣ���
        Debug.Log("On Enable");
    }
    private void OnDisable() // ��ũ��Ʈ�� ���� �� ȣ���. ������ ���� ȣ���
    {
        Debug.Log("On Disable");
    }

    private IEnumerator Start() // Update�� �ڷ�ƾ���� ������
    {
        gameObject.SetActive(true); // �ش� ���� ������Ʈ�� ��Ƽ�긦 ��
        bool isActive = gameObject.activeSelf; // getter�� ����. �����ִ��� �����ִ��� Ȯ�θ� ����
        this.enabled = true; // �ش� ��ũ��Ʈ�� ����
        // ������Ʈ�� ��Ƽ�갡 ������ ������ �ȵ�
        // ���� �߿� ������ ������ �ٽ� ���� �ȵ�
        // ������Ʈ�� ��ũ��Ʈ�� �����°� �ڷ�ƾ�� ���࿡ ������ ��ġ�� ����
        yield return new WaitForSeconds(1f);
    }

    private void Update()
    {
        Debug.Log("Counter"); // Update�� ������Ʈ�� ������ ��ũ��Ʈ�� ������ ��� ��������� �ٽ� �Ѹ� �ٽ� �����
    }

    private void OnMouseDown()
    {
        Debug.Log("On Mouse Down");
    }
    private void OnMouseDrag()
    {
        Debug.Log("On Mouse Drag");
    }

    public void CounterStart() {
        StartCoroutine(CounterCoroutine());
    }

    private IEnumerator CounterCoroutine() {
        int cnt = 0;
        while (true) {
            Debug.Log("cnt: " + cnt++);
            yield return new WaitForSeconds(1f);
        }
    }
}
