using System;
internal class Program
{
    // 템플릿(Template)
    //  제네릭(Generic) 일반화
    // 일반화 프로그래밍
    /*public static int Sum(int _lhs, int _rhs) {
        return _lhs + _rhs;
    }
    public static float Sum(float _lhs, float _rhs)
    {
        return _lhs + _rhs;
    }*/

    // Function Template / Method Template
    public static void PrintType<T1, T2>(T1 _val1) { // PrintType<T1, T2>(T1 _val1, T2 _val2) 식으로 여러개 쓸 수도 있고 G1, T2, A처럼 T말고 다른거 써도 됨
        Console.WriteLine(_val1.GetType()); // NULL 들어올까봐 워닝
    }

    // Class Template
    public class Template<T, F> // 타입이 다른 클래스 객체를 만들 경우 클래스가 메모리에 만드는 대로 다 생김 게임에 못씀 자료구조에 좋음 평소에 특별히    좋진 않음
    {
        public T _tVal; 
        public F _fVal;
    }
    // 템플릿 특수화: 같은 기능인데 특정 자료형이 들어오면 다르게 처리해야할 때 원하는 대로 기능하도록 특수화
    // C#은없음 C++은 있음 C#이 또

    public static void Main(string[] _args)
    {
        //Console.WriteLine(Sum(5,4));
        PrintType<int, float>(100);
        PrintType<float, double>(3.14f);
        PrintType<decimal, float>(3.12345m);

        Template<short, byte> temp = new Template<short, byte>();
    }
}