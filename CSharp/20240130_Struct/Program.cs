class Program {
    class ClassExample {
        public int x = 0;
        public int y = 0;

        // Member Initializer
        public const int constant = 0;
        private readonly int readonlyVal = 0;

        public ClassExample(int _x, int _y, int _constant = 5) {

            x = _x;
            y = _y;
            //constant = 100; // 생성자에서 초기화가 안됨 = 생성자가 호출되기 전에 이미 초기화가 됨
            // 클래스 내부의 상수를 매개변수로 받아서 초기화 하고 싶을 때 readonly 키워드를 사용
            readonlyVal = _constant;
            readonlyVal = 100;
            readonlyVal = 124;
        }

        public void Print()
        {
            //readonlyVal = 123; // readonly는 생성자에서는 초기화 가능, 그 이후에 값 변경 불가능
            Console.WriteLine($"{x}, {y}");
        }

        // 함수 오버로딩 매개변수 개수, 유무가 다른 같은 함수. 반환형은 같아야함
        public void Print(int _x, int _y = 5 ) { // Default Argument 디폴트 매개변수. 매개변수를 넣지 않았을 경우 자동으로 들어가는 값
            // 생략한 값이 x인지 y인지 알 수 없기 때문에 디폴트 매개변수는 뒤쪽부터 넣어줘야함
            Console.WriteLine($"Class Overload Defaul: ({_x}, {_y})");
        }

        public void Print(int _x)
        { 
            // 디폴트 매개변수를 넣은 오버로딩함수와 원래 하나만 받는 오버로딩함수를 둘 다 만들면 하나만 받는 함수가 우선됨
            Console.WriteLine($"Class Overload: ({_x})");
        }

        public ClassExample GetThis() { // this (C++ : thisPointer) 클래스 내부에서만 접근이 됨. 만들어진 객체의 첫번째 주소(이름)
            // this는 만들어진 그 객체 각각의 주소이기 때문에 객체마다 다른 값을 가짐.
            // this. 을 사용하면 만들어진 각 객체 자기 자신의 것을 사용하는 것
            return this; // 자기 자신의 참조

            // 참조를 내보내지만 값을 보호하고 싶을 경우 const를 붙여서 반환하는데
            // 받는 쪽에서도 const를 붙여줘야함
            // 값이 변하지 않는다는 보장이 됨
        }

        // 복사 생성자(Copy Constructor)
        public ClassExample(ClassExample _classExam) {
            this.x = _classExam.x;
            this.y = _classExam.y;
            Console.WriteLine($"Copy Constructor{this.x}, {this.y}");
        }
        // 사용자 정의 자료형 간의 비교 연산, 대입 연산, 산술 연산 등을 재정의 할 수 있음
        // C++은 연산자 오버로딩이 자유로움 다 됨 C#은 되는 것도 있고 안되는 것도 있음


        // 연산자 오버로딩
        // a.operator+(a+b);
        public static ClassExample operator + (ClassExample _lhs, ClassExample _rhs) {
            return new ClassExample(_lhs.x + _rhs.x, _rhs.y + _rhs.y) ;

        }

        // Arrow Function으로 만들어두면
        // Inline Function이 될 확률이 높음
        public int Sum(int _lhs, int _rhs) => _lhs + _rhs;

        /*public float Sum() {
            // Lambda Exapressions(람다식)이 Arrow Function된거임
            () => // 함수포인터 
            {
                return x + y;
            };
            return 0;
        }*/
    }

    //main을 static으로 만드는 이유 객체 만들어서 호출하고 하면 번거로움
    // 정적함수에서는 정적함수만 호출가능 객체 만들기 전이니까..
    static void Main(string[] _args) {
        //StructExample.Structure structure; // 생성자 호출 안됨
        // class로 변수를 만들면 이름. 주소는 stack에 저장됨 (지역을 벗어나면 사라짐)
        // new로 동적 할당을 하면 그 안의 값들은 Heap에 저장됨
        // C# 구조체는 new를 사용해서 동적할당을 해도 이름과 값 기타 등등이 전부 stack에 저장됨
        // 근데 클래스 안에서 구조체 객체를 생성하는 경우 클래스는 heap에 들어감 -> 해당 구조체 데이터도 heap에 들어감
        StructExample.Structure structure = new StructExample.Structure(5, 7); // (C# 특) 생성자 호출하려면 new를 써야함
        structure.IntX = 10;
        Console.WriteLine($"private structure Get {structure.IntX}");

        //structure.x = 100;
        //structure.y = 100;
        structure.Print(); // 생성자가 호출되면 초기화하지 않아도 사용됨
        //Console.WriteLine(structure.y); C#에서 구조체를 사용할 때에는 멤버변수를 어떤 값으로든 초기화해줘야 사용할 수 있음

        ClassExample classExam = new ClassExample(5, 7);
        classExam.x = 100;
        classExam.Print(654); // 디폴트 매개변수를 넣어서 x만 입력해도 y가 미리 입력된 값이 출력됨

        /*ClassExample cpyExam = classExam; // 동적할당. 참조복사(얕은복사)
        cpyExam.x = 150; // 원본 값 바뀜
        classExam.Print();

        StructExample.Structure cpyStructure = structure; // 동적할당인데도 깊은 복사. class는 참조 형식, 구조체는 값 형식이라서. 태생의 차이다
        // 아마 구조체는 사용자 정의 '자료형'이기 때문에 기본 자료형과 작동 방식이 비슷한듯
        cpyStructure.x = 150;
        structure.Print();*/

        ////
        //상수성 보장 const 값을 반환하면 받는 애도 const 붙여줘야 함
        // const ClassExample thisExam = classExam.GetThis(); 

        ClassExample a = new ClassExample(2, 5);
        ClassExample b = new ClassExample(4, 1);
        ClassExample c = a + b; // +가 무슨 의미인지 알 수 없어서 에러가 남, 이럴 때를 위해서 연산자 오버로딩이 가능
        c.Print();
    }
}
