using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    /*    public class MyWait : IEnumerator // 내가 원하는 방식으로 쉬고 싶을 때 IEnumerator를 상속받아서 새로 만듦
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
        /*testCo = StartCoroutine(TestCoroutine()); // StratCoroutine은 반환형이 Coroutine
        StartCoroutine("ExampleCoroutine", 1); // 문자열로 실행시킬 때에는 뒤에 콤마 찍고 매개변수를 넣어준다
        StartCoroutine("ExampleCoroutine", 2);
        StartCoroutine("ExampleCoroutine", 3);*/
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 숫자키 1
            //StopCoroutine(TestCoroutine()); 
            //StopCoroutine("TestCoroutine"); // 1을 눌러도 종료되지 않음
            StopCoroutine(testCo);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            StopCoroutine("ExampleCoroutine"); // 2를 누르면 종료됨

        if (Input.GetKeyDown(KeyCode.Alpha3))
            StopAllCoroutines(); // 해당 스크립트에서 작성된 모든 코루틴을 종료시킴.

        if (Input.GetKeyDown(KeyCode.Space))
            counter.CounterStart();
        // 오브젝트의 액티브가 꺼지면 실행이 안됨
        // 실행 중에 꺼졌다 켜져도 다시 실행 안됨
        // 오브젝트의 스크립트가 꺼지는건 코루틴의 실행에 영향을 끼치지 않음
            
        
    }


    // 코루틴
    // 여러개의 루틴이 같이 돌아가는것 (쓰레드와 비슷함)
    // Co-op 협동해서 돌아감
    // 쓰레드와 다르게 실제로 완전히 동시에 돌아가는 것은 아님

    WaitForSeconds wait1Sec = new WaitForSeconds(1f);


    // IEnumerable foreach문 만들 때 쓰는거임 착각주의
    private IEnumerator TestCoroutine() {
        while (true)
        {
            Debug.Log("First");
            //yield return new WaitForSeconds(1f);
            yield return wait1Sec; // 권장됨. 반복할 때마다 새로 객체를 만드는건 굉장히 비효율적.
            // 다시 실행될 때 밑줄부터 실행됨
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
