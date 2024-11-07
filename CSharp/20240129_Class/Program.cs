using System;

class Program {

    // C에서 static - 정적 변수. 지역 변수지만 지역을 벗어나도 값을 저장, 접근은 지역 내에서만 가능. 저장 공간이 전역변수와 같은 곳이기 때문
    static void Test() {
        ClassExample ce = new ClassExample();
    }

    static void Main(string[] _args) {
        // Object, Instance
        int intValue = 50;
        //ClassExample example = new ClassExample(intValue);
        ClassExample example = new ClassExample(); // ClassExample의 객체 생성. 인스턴스화 하다. 동적할당

        //example.intValue = 100; // 정보 은닉에 위배됨
        example.IntValue = 100; // Properties에는 접근 가능

        /*Test();
        GC.Collect();
        Console.Read();*/


        ClassExample.StaticMethod(); // static으로 만들면 객체를 만들지 않아도 접근이 됨

        ClassExample ce = new ClassExample(); // 객체를 만드려고 했는데? 메모리 공간을 할당 안해줌. 못씀
        //ce.staticVariable = 100; // staticVariable에 접근 안됨
        ClassExample.staticVariable = 100; // 접근 됨

        // 객체를 만든다 - ClassExample이라는 폼으로 여러개의 변수를 만든다
        // 값이 다 다르다
        // static 변수는 해당 클래스로 여러개를 만들어도 값이 딱 하나.
        // 그래서 객체로 접근이 안됨. 클래스 자체로 접근
    }

}