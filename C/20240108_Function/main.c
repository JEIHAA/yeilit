#include <stdio.h> //정적 라이브러리
// dll 동적 라이브러리
//다이렉트x 그래픽 라이브러리


//함수 선언(Declaration) : .h 선언부를 모아둔 게 헤더파일
//컴파일 속도를 줄이기 위해 선언부와 정의부를 따로 저장한다
//컴파일 시간에는 헤더 파일만 포함됨
//현재는 프리 컴파일(코딩 중 백그라운드에서 컴파일 진행되고 있음)로 속도 문제는 없음


void PrintHello();

// int Sum(매개 변수(Parameter));
// 보통 외부에서 들어온 값이 매개변수 일 때 _를 붙임
// 함수 정의부 내부에서 만들어져서 쓰이는 경우에는 _를 안붙임
// 선언부에서 const int _lhs 했으면 정의부에서도 const 붙여줘야한다
// 선언부에서 중요한건 리턴 타입, 함수명, 매개변수 타입과 개수
// 변수명은 안써도 문법적으로는 괜찮지만 써 주는 것이 좋다
int Sum(const int _lhs, const int _rhs);

int main() {

	// 함수 호출(Function Call)
	PrintHello();
	//인자(Arguments)
	int arg = 1;
	printf("Sum: %d\n", Sum(arg, 3));

	return 0;
}

//함수 정의(Definition) : .c
void PrintHello() {
	printf("Hello\n");
}

int Sum(const int _lhs, const int _rhs) { // 정의부에서 const int _lhs 했으면 선언부에서도 const 붙여줘야한다
	// _lhs = 100;
	// 입력된 매개변수로 오롯이 연산을 해야하는데 내부에서 값이 변경하도록 수정하는 사람이 있을 수 있다
	// 해서 값이 변하지 않도록 보장하고 싶다면 const 붙여준다
	int lhs = 0;
	return _lhs + _rhs;
}