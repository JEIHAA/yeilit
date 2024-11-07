using System;
using System.Collections.Generic;

public class Program {
    public static void Main(string _args) {
        // Generic(일반화) - Template
        // 배열
        // 크기를 알면 배열을. 모르면 아래와 같이
        List<int> list = new List<int>(); // int형으로 일반화
        list.Add(1);
        list.Add(2);
        //list.Add(3.14); //box, unboxing이 발생하지 않음. 빠름
        Console.WriteLine(list[1]);

        // 스택
        Stack<float> stack = new Stack<float>();
        stack.Push(3.1f);
        stack.Push(5.6f);
        Console.WriteLine(stack.Pop());

        // 큐
        Queue<double> queue = new Queue<double>();
        queue.Enqueue(3.14);
        queue.Enqueue(89.34);
        Console.WriteLine(queue.Dequeue());

        // 해쉬 - 딕셔너리(Dictionary)
        // C# - Collections.Generic, C++ - STL(Standard Template Library)
        // Map
        Dictionary<string, int> dic = new Dictionary<string, int>();
        dic.Add("First", 1234);
        dic.Add("Second", 5678);
        if(dic.ContainsKey("First"))
            Console.WriteLine(dic["First"]);

    }
}