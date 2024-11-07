using System;
using System.Text;

internal class Program {
    public static void Main(string[] _args) {
        char c = 'a';
        char[] charStr = new char[] {
            'H', 'e', 'l', 'l', 'o'
        };

        // c의 동적 할당 malloc c#의 동적할당 new
        // new int();
        // 생성자(Constructor)
        // new를 사용하면 생성자가 자동으로 호출됨 new int 뒤에 괄호를 써야하는 이유. 생성자는 함수이기 때문에 매개변수가 들어가는 괄호를 넣어줘야함
        // 생성자 오버로딩(Constructor Overloading) 여러 생성자 중에서 어떤 것을 호출할 것인가
        // int의 경우 매개변수가 없고 문자열을 매개변수로 받는 string 생성자를 호출하여 new int(), new string("Hello") string에만 매개변수를 넣어준다
        // Instance, Instancing
        // 동적할당은 무조건 참조형식
        // 배열을 만들 때 new int 같은 동적할당 구문을 적지 않아도 그냥 생략되는 것일 뿐 직접 넣는 것과 동적할당 해서 넣는것은 동일한데
        // 문자열을 만들 때 동적할당 구문을 적어주는 것과 변수에 바로 넣는 것은 다른 것

        // new string("Hello") -> Heap
        // 만들 때마다 새로운 메모리 공간을 할당함
        String hello = new String("Hello"); // string과 String은 완전히 똑같다 String을 string으로 typedef한 것
        string hello1 = new string("Hello");
        string hello2 = new string("Hello");
        Console.WriteLine("hello1 == hello2: {0}", object.ReferenceEquals(hello1, hello2)); // 참조 비교, 주소를 비교함
        // 언어가 달라도 비트단위 검사해서 검사함 언어구분은 CompareTo써야한다
        hello1.CompareTo(hello2);

        // "World" -> String Constant Pool 문자열 상수들을 관리하는 공간(Heap에 들어있긴 함)
        string world1 = "World"; // 문자열 상수, 리터럴 상수임
        string world2 = "World";
        Console.WriteLine("world1 == world2: {0}", object.ReferenceEquals(world1, world2)); // 문자열의 문자 하나하나가 같은지, 같은 내용인지 비교함
        Console.WriteLine("Equals world1, world2: {0}", world1.Equals(world2));

        // 상수풀에 저장되는것이기 때문에 다른 변수에 똑같은 문자를 저장하려고하면 상수풀안에 같은 단어가있는지 검사하고 같은단어가 있다면
        // 그것의 주소를 주어서 바뀌지 않는 글자를 쓴다면 상수로 만드는 방식이 메모리를 아낄 수 있다

        ////

        int value = 10;
        string valueStr1 = "Value" + " is " + value; // 제일 느림 value.ToString(); ToString()이 생락된 것 value의 값을 string으로 바꿔줌
        string valueStr2 = string.Format("Value is {0}", value);
        // String Interpolation(문자열 보간)
        string valueStr3 = $"Value is {value}";
        Console.WriteLine(valueStr1 + "\n" + valueStr2 + "\n" + valueStr3);

        StringBuilder sb = new StringBuilder(); // 문자열을 관리할 때 가장 권장됨
        sb.Append("Value");
        sb.Append("is");
        sb.Append(value);
        Console.WriteLine(sb.ToString());

        string str = new string(charStr);
        char[] strToChar = str.ToCharArray(); // 문자열을 char 배열로 만들어줌
        Console.WriteLine($"str.Length: {str.Length}");

        string cloneStr = (string)str.Clone(); // 참조 복사를 하지만 읽기 전용으로 복사, 변수에 접근은 가능하지만 수정은 안됨. const가 붙어서 나옴. 정보 은닉
        for (int i = 0; i < cloneStr.Length; ++i)
            // 연산자 오버로딩(Operator Overloading)
            // 캡슐화(Encapulation)
            Console.Write(cloneStr[i]); 
        Console.WriteLine();

        Console.WriteLine("Contains: "+str.Contains('o')); // 해당 문자, 문자열이 있나 없나
        Console.WriteLine("IndexOf: " + str.IndexOf('l')); // 해당 문자, 문자열이 몇번째 인덱스에 있나
        Console.WriteLine("LastIndexOf: " + str.LastIndexOf('l')); // 마지막에 있는 해당 문자, 문자열이 몇번째 인덱스에 있나
        Console.WriteLine("Insert: " + str.Insert(2, "World")); // 문자열을 추가한 새로운 문자열을 만든다
        Console.WriteLine("Remove: " + str.Remove(1,2)); // 해당 인덱스의 문자를 제거한다
        Console.WriteLine("Replace: " + str.Replace("l","L,AA")); // 특정 문자, 문자열을 해당 문자, 문자열로 바꿈
        // Method Chaining
        string[] splits = str.Replace("l", "L,AA").Split(','); // , 단위로 자름
        foreach (string split in splits)
            Console.WriteLine(split);

        Console.WriteLine("ToLower: "+ str.ToLower());
        Console.WriteLine("ToUppoer: "+ str.ToUpper());
        // (): 양쪽 공백 제거
        // (문자): 양쪽 끝에 해당 문자가 있으면 제거, 공백있으면 제외
        // (문자열): 양쪽 끝에 해당 문자셋 중 하나가 있으면 문자셋에 있는 문자들을 제거
        Console.WriteLine("Trim: " + str.Replace("H", "       h").Trim());
        Console.WriteLine("C:\\user\\huieon");
        Console.WriteLine(@"C:\user\huieon"); // C나 C++에서는 유니코드 사용할 때 @ 붙임 보통은 그냥 \\ 사용
    }
}