using System;

class Program {


    // ref: Reference, 참조 함수 내부에서 외부의 값을 바꿈 안바꿔도 문제 없음
    // 포인터: 주소를 저장하는 공간이 새로 생김
    // Reference: 같은 변수에 이름이 하나 더 생김 intVal = _val
    // ref int _val로 받으면 그 변수는 참조해서 사용하겠다

    /// <summary>
    /// 함수 위에 /// 치면 함수 설명을 적을 수 있다
    /// 함수 위에 마우스 오버하면 보임
    /// </summary>
    /// <param name="_val">매개변수 설명 함수에 넣은 값 설명을 볼 수 있음</param>
    private static void ChangeValue(ref int _val) {
        _val = 100;
    }

    // ref과 다르게 out은 함수 외부에서 들어온 변수의 값을 무조건 바꿔야 함(대입 연산을 반드시 한번 이상 해줘야 함)
    private static void ChangeValueOut(out int _val) {
        _val = 200;
    }

    public static void Main(string[] _args) {
        int intVal = 0;
        System.Console.WriteLine("intVal: {0}", intVal);

        ChangeValue(ref intVal);
        System.Console.WriteLine("Change Value: {0}", intVal);

        ChangeValueOut(out intVal);
        System.Console.WriteLine("Change Value Out: {0}", intVal);

        ref int refVal = ref intVal;
        refVal = 100;
        /*out int outVal = out intVal;
        outVal = 200;*/ // 값이 변한다는 보장이 있어야하기 때문에 함수 내부에서만 쓰인다고 생각하면 편함

        // 동적할당(Dynamic Memory Allocate
        // 'new'
        int intAlloc = new int();
        intAlloc = 0;
        int cpyAlloc = intAlloc;
        cpyAlloc = 100;
        System.Console.WriteLine("intAlloc: {0}", intAlloc);
        // 기본 자료형은 동적할당을 해도 일반 변수처럼 사용한다

        // Garbage Collector
        // C#은 메모리를 알아서 관리해주기 때문에 할당한 메모리를 따로 해제해 줄 필요 없다
        // 근데 느려!
        // Reference Count

        // int arr[5] = {1,2,3};

        void ChangeArray(int[] _arr) // 지역함수, 만들어진 지역에서맍 접이 가능함
        {
            _arr[1] = 100;        
        }
        int[] arr = { 1, 2, 3, 4 ,5 }; // 동적할당임 new가 생략된 것
        int len = 0;
        int[] arrAlloc = new int[5] { 1, 2, 3, 4, 5}; // 초기화할 때 자동으로 0으로 채워주는거 없음
        ChangeArray(arr);
        System.Console.WriteLine("arr[1]: {0}", arr[1]);

        // 정적 배열은 배열의 길이를 리터럴 상수로만 지정할 수 있음
        // 동적 배열은 변수로 배열의 길이를 정할 수 있음
        // c#의 배열은 동적 할당이기 때문에 변수로 줄 수 있음

        void PrintArray(int[] _arr) {
            for (int i = 0; i < _arr.Length; ++i)
            {
                System.Console.Write("{0} -", arr[i]);
            }
            System.Console.WriteLine("({0})", _arr.Length);
        }
        PrintArray(arr);
        Console.WriteLine("arr Type: {0}", arr.GetType());
        Console.WriteLine("arr Base Type: {0}", arr.GetType().BaseType);

        // 얕은 복사(Shallow Copy) 참조
        // 깊은 복사(Deep Copy) 리얼 복사본 하나 더 생김
        int[] cpyArr = arr; //참조 복사
        cpyArr[0] = 123; 
        Console.WriteLine("arr[0]: {0}", arr[0]);

        // 범위 기반 반복문(for문)
        // Range Based For
        foreach (int val in cpyArr)
            Console.Write("{0} - ", val);
        Console.WriteLine("({0})", cpyArr.Length);

        int[,] arr2d = { { 11, 12 },{ 21, 22 } }; // new int[2,2]{{ }};

        //Console.WriteLine("arr2d[0][2]: {0}", arr2d[0][2]); 접근 안됨

        // Jagged Array 
        // 줄 수만 정해주고 나머지는 동적할당 해줘야함 접근은 일반 배열과 똑같이
        // 3차원도 마찬가지 맨 앞만 정해준다
        int[][] arr2dAlloc = new int[2][] {
            new int[3] { 11, 12, 13 },
            new int [2] { 21, 22 }
        };
        Console.WriteLine("arr2d: {0}", arr2d.Length);
        Console.WriteLine("arr2dAlloc: {0}", arr2dAlloc.Length);

        foreach (int val in arr2d)
            Console.Write("{0} - ", val);
        Console.WriteLine("({0})", arr2d.Length);

        foreach (int[] valArr in arr2dAlloc) // arr2dAlloc의 요소는 int가 아니라 int[]
            foreach(int val in valArr)
                Console.Write("{0} - ", val);
        Console.WriteLine("({0})", arr2dAlloc.Length);

        Console.WriteLine("arr2d Type: {0}", arr2d.GetType().BaseType);
        Console.WriteLine("arr2dAlloc Type: {0}", arr2dAlloc.GetType().BaseType);
    }
}