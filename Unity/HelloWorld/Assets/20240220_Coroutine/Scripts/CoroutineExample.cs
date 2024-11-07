using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    /*    public class MyWait : IEnumerator // ���� ���ϴ� ������� ���� ���� �� IEnumerator�� ��ӹ޾Ƽ� ���� ����
        {
            public object Current => throw new System.NotImplementedException();

            public bool MoveNext()
            {
                throw new System.NotImplementedException();
            }

            public void Reset()
            {
                throw new System.NotImplementedException();
            }
        }
    */

    [SerializeField] private CoroutineCounter counter = null;
    private Coroutine testCo = null;

    private void Start()
    {
        /*testCo = StartCoroutine(TestCoroutine()); // StratCoroutine�� ��ȯ���� Coroutine
        StartCoroutine("ExampleCoroutine", 1); // ���ڿ��� �����ų ������ �ڿ� �޸� ��� �Ű������� �־��ش�
        StartCoroutine("ExampleCoroutine", 2);
        StartCoroutine("ExampleCoroutine", 3);*/
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // ����Ű 1
            //StopCoroutine(TestCoroutine()); 
            //StopCoroutine("TestCoroutine"); // 1�� ������ ������� ����
            StopCoroutine(testCo);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            StopCoroutine("ExampleCoroutine"); // 2�� ������ �����

        if (Input.GetKeyDown(KeyCode.Alpha3))
            StopAllCoroutines(); // �ش� ��ũ��Ʈ���� �ۼ��� ��� �ڷ�ƾ�� �����Ŵ.

        if (Input.GetKeyDown(KeyCode.Space))
            counter.CounterStart();
        // ������Ʈ�� ��Ƽ�갡 ������ ������ �ȵ�
        // ���� �߿� ������ ������ �ٽ� ���� �ȵ�
        // ������Ʈ�� ��ũ��Ʈ�� �����°� �ڷ�ƾ�� ���࿡ ������ ��ġ�� ����
            
        
    }


    // �ڷ�ƾ
    // �������� ��ƾ�� ���� ���ư��°� (������� �����)
    // Co-op �����ؼ� ���ư�
    // ������� �ٸ��� ������ ������ ���ÿ� ���ư��� ���� �ƴ�

    WaitForSeconds wait1Sec = new WaitForSeconds(1f);


    // IEnumerable foreach�� ���� �� ���°��� ��������
    private IEnumerator TestCoroutine() {
        while (true)
        {
            Debug.Log("First");
            //yield return new WaitForSeconds(1f);
            yield return wait1Sec; // �����. �ݺ��� ������ ���� ��ü�� ����°� ������ ��ȿ����.
            // �ٽ� ����� �� ���ٺ��� �����
            Debug.Log("Second");
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator ExampleCoroutine(int _num) {
        while (true) { 
            Debug.Log(_num + "1");
            yield return new WaitForSeconds(0.5f);
            Debug.Log(_num + "2");
        }
    }
}
