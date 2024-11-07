using System;
using System.Runtime.CompilerServices;

class Program {
    // 추상 함수 전용 추상 클래스
    interface IInterface { // interface는 다중상속이 가능함
        //int ival = 100; // interface는 값을 가질 수 없음
        public void Foo(); // Overriding 해야하는 함수는 반드시 private일 수 없음
        protected void Bar(); // interface는 접근지정자를 안적어두면 기본으로 public이 됨
        // Foo, Bar 함수를 임시로 만들어 쓸 때 주로 사용되는 이름
    }
    // 상속(Inheritance)
    // 부모 - 자식
    // Parent - Child
    // Base - Derived
    // Super - Sub

    // 추상 함수가 하나라도 포함되어 있는 경우 클래스에도 abstract를 넣어줘야함. 추상 클래스가 됨
    public abstract class Base {

        protected int parentVal = 0; // 자식에게만 접근 허용

        public Base() { //생성자
            //Console.WriteLine("Base Constructor Call!");
        }

        public Base(int _val) {
            //Console.WriteLine("Base Constructor(int) Call!");
        }

        public void  ParentFunc()
        {
            Console.WriteLine("Base Constructor Call!");
        }

        /*// 가상함수 Virtual Function / Method
        public virtual void CommonFunc() {
            Console.WriteLine("Base CommonFunc Call!");
        }*/

        // 추상함수 (C++에서는 퓨어 버츄얼함수)
        public abstract void CommonFunc();

    }


    // 단일상속
    // 다중상속. (여러개 상속받는 것) C#은 지원안함
    // interface는 다중상속 됨
    public class Derived : Base, IInterface { // 상속받으면 메모리 공간도 붙어서 만들어짐, interface는 ,로 추가

        private int childVal = 0;
        private int parentVal = 0; // 부모의 parentVal이 자식의 parentVal에 가려짐 
        //parentVal = 0; // 자식이여도 private 변수는 접근할 수 없다. 자식에게만 허용하는게 protected

        public Derived() {
            base.parentVal = 100; // Base의 parentVal
            this.parentVal = 100; // Derived의 parentVal. 명확하도록 this. 붙여줌
            //Console.WriteLine("Derived Constructor Call!");
        }

        public Derived(int _val) : base(_val) { // Derived를 동적할당 할때 인수를 하나만 넣으면 Derived의 int 생성자만 호출됨, 부모의 생성자도 int받는 생성자로 부르고 싶을 때 : base(_val) 추가
            //Console.WriteLine("Derived Constructor(int) Call!");
        }
        public void ChiledFunc() {
            Console.WriteLine("Derived ChildFunc Call!");
        }

        public override void CommonFunc()
        {
            Console.WriteLine("Derived CommonFunc Call!");
        }

        public void Foo() { }
        public void Bar() { } // interface의 함수를 가져와서 쓸 때는 override를 쓰지 않음
    }

    // sealed 키워드: 해당 클래스를 상속받지 못하게 막음 (C++에는 그런거 없음)
    // ***상속되었을 때 지켜야하는 것, 재정의해야하는 것, 그대로 쓸 것 등을 접근 지정자와 키워드들로 잘 정해줘야함***
    // 상속받으면 접근 수준을 바꿀 수도 있음 (C++이 또) C#은 안됨
    public sealed class Child : Base {
        public void ChildFunc() {
            Console.WriteLine("Child ChildFunc Call!");
        }

        public override void CommonFunc()
        {
            Console.WriteLine("Child CommonFunc Call!");
        }
    }


    static void Main(string[] _args) {
        //Base based = new Base();
        //based.ParentFunc();

        Derived derived1 = new Derived(10); // 상속받으면 동적할당 시 부모의 생성자가 먼저 호출되고 자식의 생성자가 나중에 호출된다. 소멸자는 반대
        derived1.ChiledFunc();
        derived1.ParentFunc();

        Base baseDerived = new Derived(); // 자식은 부모를 포함하기 때문에 Derived는 Base의 정보를 앎
        //Derived derivedBase = new Bsae(); // 부모는 자식을 모르기 때문에 Base가 Derived의 정보를 모름, 생성 불가능
        //baseDerived.ParentFunc();
        //baseDerived.ChildFunc(); // Derived의 공간을 생성했기 때문에 메모리 공간은 Base와 Derived를 합친 만큼 할당되어 있어 Derived의 정보를 가지고는 있음
        // 그런데 Base형으로 만들었기 때문에 Derived가 가진 정보에 접근할 방법이 없음
        ((Derived)baseDerived).ChiledFunc(); // Derived형으로 형 변환해주면 Derived가 가진 정보를 가져올 수 있음

        baseDerived = new Child(); // 원래 할당 받았던 공간은 참조가 사라져서 가비지컬렉터가 청소해줌 C++이면 직접 해제해줘야함
        ((Child)baseDerived).ChildFunc();
        // 같은 Base에 어떤 자식이 들어가냐에 따라 기능이 달라짐.
        // Base를 상속받는 새 클래스가 추가되어도 Base형으로 만들고 Base를 상속받은 자식들 공간으로 다시 할당하여 형 변환해주면 해당 자식의 기능을 사용할 수 있음

        //Base based = new Base(); // Base가 추상 클래스가 되었기 때문에 Base로 객체를 만들 수 없게 됨
        //based.CommonFunc();
        Base based = new Derived(); // 추상 클래스로 선언은 가능, 자식을 담을 수는 있음
        based.CommonFunc();
        based = new Child();
        based.CommonFunc(); // Base based = new Base();는 Base형이기 때문에 Base의 정보만 읽을 수 있음, Base의 CommonFunc만 실행됨
        // 근데 또 형변환 안하고 자동으로 됐으면 좋겠다!! 해서 virtual - override라는 키워드를 만듦
        // Method Overriding, Function Overriding ******** Overloading이 아님!!!!!!!!! ********
        // Base CommonFunc에 virtual 키워드를 넣고 파생 클래스들의 CommonFunc에 override 키워드를 넣으면
        // 형 변환 없이 할당받은 공간의 함수를 사용할 수 있음

        // Overloading: 같은 함수의 매개 변수의 개수를 다르게 해서 재정의
        // Overriding: 부모 클래스가 가진 함수를 자식 클래스에서 원하는 기능으로 재정의해서 사용 ( 반환형, 매개변수 개수 등의 형태가 같아야함! 다르면 Overloading임 )
        // Virtual Function 가상 함수: 자식 클래스에서 해당 함수를 재정의 했을 경우 재정의된 함수를 사용, 재정의된게 없을 경우 해당 함수를 호출
        // virtual 키워드를 사용할 경우 대신 호출할 함수들을 저장해두는 virtual table을 만듦. 키워드를 만나면 테이블이 반드시 생성되기 때문에 퍼포먼스가 떨어질 수 있음
        // 함수가 호출될 경우 virtual 함수를 읽음, virtual table에 대신 호출될 재정의된 함수가 있는지 확인 후 있다면 그 함수를 호출하는 방식. 없으면 그냥 virtual 함수 호출

        // abstract 키워드: 부모 클래스의 함수를 자식 클래스에서 반드시 재정의하도록 강제 (override 필수)


        // Type Casting(클래스 간의 형 변환) / Conversion (기본 자료형 간의 형 변환)
        Derived derived2 = new Derived();
        // Upcasting: 자식이 부모형에 들어가서 부모 클래스의 메모리만 읽을 수 있게 됨
        based = derived2;
        // Downcasting: 부모가 자식형이 되어서 자식 클래스의 메모리도 읽게 됨
        derived2 = (Derived)based; // 강제 형변환 based가 자식 클래스로 동적할당이 되어있어야 함

        if (derived2 is Base)
            Console.WriteLine("Derived is Base");
        derived2 = based as Derived; // 형 변환이 가능하면 하고 안되면 NULL이 됨. 더 안정적, 권장됨

        /////

        // Urility Class / Helper: static으로 만들어져서 기능만 사용할 수 있도록 만들어진 클래스
        Factory.Monster monster = Factory.Spawn(Factory.EMonsterType.Orc);


        // 다형성(Polymorphism): 자료형이 동적으로 정해짐
        // 챔피언 클래스가 동적할당이 어떻게 되느냐에 따라 메이지 챔프도 되고 탱커 챔프도 됨
    }

}
