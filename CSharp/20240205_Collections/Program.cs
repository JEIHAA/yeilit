using System;
using System.Collections;

public class Program {
    public static void Main(string[] _args) {
        // 배열
        //Array arr = new Array();
        int[] arr = new int[5];
        ArrayList arrList = new ArrayList(); // 동적 벡터
        arrList.Add(0);
        arrList.Add(3.14);
        arrList.Add("Hello");
        arrList.Add('A');

        Console.WriteLine(arrList[1]);
        Console.WriteLine((string)arrList[2]);


        // Boxing 데이터를 object형으로 감쌈 , Unboxing 데이터를 사용할 때 object형에서 꺼냄
        object objInt = 10;
        object objChar = 'A';
        object objStr = "World!";

        // 스택
        Stack stack = new Stack();
        stack.Push(5);
        stack.Push(1);
        stack.Push("Hello");
        Console.WriteLine(stack.Pop()); // 반환형이 object형, boxing, unboxing 과정이 있음

        // 큐
        Queue queue = new Queue();
        queue.Enqueue(3.14);
        queue.Enqueue("World!");
        Console.WriteLine(queue.Dequeue()); // object

        // 해쉬(Hash)
        // 키(Key) - 값(Value)
        Hashtable hash = new Hashtable(); // HashCode로 Table 만듦
        hash.Add("H", "Hello");
        hash.Add("W", "World!");
        hash.Add(3, "Hash");
        Console.WriteLine(hash["H"]);

    }
}
