using System;


// C: 절차지향(Procedure Oriented Programming)
// C#: 객체지향(Object Oriented Programming)
// OOP
// 접근 지정자 (Access Modifier)
// 캡슐화 (Encapsulation)
// String 클래스 내부에서 어떻게 돌아가는지, 뭐가 있는지 모르지만
// 문자열을 관리하는 클래스라는 것을 알고 문자열 관리에 관련된 것들만 있다는 것도 앎. 잘 만든 클래스의 예시
// 이미 만들어져있는 클래스들을 보고 공부하자

class ClassExample
{
    // 클래스 멤버 변수
    // 필드(Field) 변수들을 담아두는 곳
    // 전역변수, 지역변수, 멤버변수, 매개변수

    // 클래스 내부의 멤버변수들에도 패딩이 발생한다.
    // 메소드는 해당 사항이 없다 -> 멤버변수와 메소드는 저장공간이 다르다.
    // 클래스 객체를 여러개 만들어도 변수는 여러개 생겨 저장공간을 잡아먹지만 메소드는 또 만들어지지 않는다

    private int intValue = 10; // 모든 정보는 보호되는게 이상적. 클래스 내의 모든 변수는 private으로 만든다는 수준
    // int mIntValue;
    // int m_intValue;
    // int m_iValue;

    // 정말 특별한 경우에 public 사용하는데
    // 벡터 값, 위치 값 같은 경우 Getter Setter를 만들어서 사용할때 발생하는
    // Function Call Overhead가 더 손해이기 때문에 public를 사용할 수 있다.

    // 멤버 변수에 바로 접근이 가능한건 좋지 않음
    // 함수로 감싸줌. 메소드 제공
    // 함수를 통하면 예외처리가 가능함
    // 터무니 없는 값이나 문제의 여지가 있는 값을 막아줄 수 있음
    // 안정적인 코드!
    // 게임같은 경우 체력을 실수로 관리하지만 외부에서 보여줄때는 정수로 보여지는 경우
    // getter함수에서 정수로 리턴해주는 식으로 활용가능

    // Properties
    public int IntValue // intValue에 접근하기 위해 IntValue라는 Propertie를 만들어줌
    {
        get { return intValue; }
        set { intValue = value; }
    }

    public int GetterSetter { get; }  // 변수에 바로 Getter, Setter함수를 만들어줌! 예외처리나 다른 처리가 필요 없는 경우 사용할 수 있음

    // Getter / Setter (C++ 문법)
    public void SetIntValue(int _intValue) {
        intValue = _intValue;
    }
    public int GetIntValue() {
        return intValue;
    }

    // 클래스의 정적 변수는 일반 정적변수와 다름
    public static int staticVariable = 0;
    // 해당 클래스에서 파생된 1000개의 멤버 변수들이 같은 값을 가질 때 static으로 만들지 않으면 같은 값을 가진 변수가 1000개 생기는 것!!

    // 클래스 멤버 함수. 메소드(Method) 필드의 변수들을 가지고 실제 처리
    private void ChangeValue(int _intValue) { } // private 이 클래스 내에서만 사용할 함수 내가 쓸거. 클래스 밖에서는 사용하지 않을 거

    // 생성자(Constructor) 반환형 X 클래스 명이랑 같음 생성할때 자동 호출
    // 기본 생성자(Default Constructor)
    // 클래스 멤버 접근 지정자
    // 붙이지 않으면 보호레벨때문에 생성자에 접근할 수 없어서 오류가 남. 아무것도 붙이지 않으면 기본적으로 private이기 때문 그래도 명시해두자
    // public, private, protected, internal
    // 객체가 만들어진 이후의 접근은 외부
    // public 내부, 외부 아무데서나 접근 가능
    // private 내부에서는 접근 가능, 외부에서는 접근 불가능
    // protected 내부에서는 접근 사능, 상속받은 애는 접근 가능, 외부에서는 접근 불가능
    // internal 같은 어셈블리 내에서만 접근 가능
    // 정보 은닉
    public ClassExample(){ 
        Console.WriteLine("ClossExample Constructor Call");
    }

    // 오버로딩 생성자(Overloading Constructor)
    // 매개변수를 받지 않는 생성자를 따로 만들지 않으면 디폴트 생성자가 만들어짐. (따로 만들어 둔 생성자가 하나도 없을 때 디폴트 생성자가 만들어짐)
    // 그런데 오버로딩 생성자를 만들어 놨을 경우 디폴트 생성자가 만들어지지 않고
    // 오버로딩 생성자가 호출됨. 객체를 생성할 때 매개변수도 필수가 됨
    // 클래스 내에 멤버 변수를 바로 초기화 해둘 수 있음
    public ClassExample(int _intValue){
        intValue = _intValue;
        Console.WriteLine($"ClossExample Constructor ({_intValue}) Call");
    }

    public ClassExample(float _floatValue) {
        intValue = (int) _floatValue;
        Console.WriteLine($"ClossExample Constructor ({_floatValue}) Call");
    }

    // 소멸자(Destructor) 메모리에서 없어질 때 자동호출
    // 사용자가 임의로 호출 불가능. 오버로딩도 불가능
    // Life Cycle
    ~ClassExample() {
        Console.WriteLine("ClassExample Destructor call");
    }

    public static void StaticMethod() {
        /*intValue = 100; // 객체가 만들어지기 전에는 메모리에 올라가 있지 않기 때문에 접근이 안됨 
        staticVariable = 100; // static 메소드와 변수는 객체가 만들어지기 전에 메모리에 올라가 있어서 사용이 됨
        NormalMethod();*/
        Console.WriteLine("StaticMethod Call");
    }

    public void NormalMethod() {
        staticVariable = 100; // static 변수와 함수는 객체가 만들어지기 전에 메모리에 올라가 있어서 이 함수가 사용될 시점에는
        StaticMethod(); // 이미 메모리에 올라가 있음. 접근과 사용하는데 문제없음
        Console.WriteLine("NormalMethod");
    }
}

