using System;

class StructExample {
    // 구조체를 쓸 일이 있으면 보통 따로 파일을 만드는데 해당 클래스에서만 쓸 때는 해당 클래스 안에 만들기도 한다
    // 또 해당 클래스를 사용할 일이 있을 때 구조체 파일이 나눠져있으면 클래스 파일과 구조체 파일 둘 다 들고 와야함
    public struct Structure {
       private int x = 0; // Structure가 public이여도 멤버변수가 public이 아니면 바깥에서 변수에 접근할 수 없음
       private int y = 0; // public으로 멤버변수를 만들거나 Getter/Setter를 만들어줘야함

        public Structure(int _x, int _y) { // 생성자
            x = _x;
            y = _y;
            Console.WriteLine("Structure Constructor Call");
        }

        public void Print() {
            Console.WriteLine($"Struct: {x}, {y}");
        }

        public int IntX
        {
            get { return x; }
            set { x = value; }
        }

        public int IntY
        {
            get { return y; }
            set { y = value; }
        }
    }

    // Structure가 public이 아닐 경우 해당 Structure를 매개변수로 받는 함수도 public으로 사용할 수 없음.
    // 당연함. 밖에서는 Structure가 뭔지 알 수 없음
    // private으로 클래스 내부에서만 쓰면 괜찮음 내부에서는 뭔지 앎
    public void SetStructure(Structure structure) { } 
}