#include <stdio.h>

#define MAX_VAL 100
// 100이라는 숫자를 MAX_VAL이라는 이름으로도 사용할 수 있도록 '선언'
// 치환
// 디버깅할때 안보임 그냥 숫자로 보임 그냥 const 변수 만들어서 쓰는게 나을 수도 있다 그런데 얘는 리터럴 상수라서 case에 쓸 수 있다

// 전역변수(Global Variables)
// C나 C++에서만 유효
int g_var;
// main 밖에 만들었기 때문에 다른 함수에서도 접근 가능
// 프로그램 시작될 때 메모리에 올라가고 끝날 때 내려간다

void ChangeVariavle() {
	//var = 100;
	g_var = 100;
}

int main() {


	// f9 브레이킹포인트 f10 한줄한줄 디버그 진행
	// 변수(Variables)
	// 변수 선언(Declaration)

	// 초기화(Initicalzation)
	// 쓰레기 값(Garbage Value)
	// 변수가 할당받은 메모리에 어떤 값이 들어있을지 모름. 초기화 안되어있음 => 쓰레기값 들어있음
	// int var = 0; <- 초기화 제일빠름
	// int var;
	// var = 0; <- 초기화x 0 대입
	int var = 10;
	printf("1. var: %d (%p)\n", var, &var);

	// 변수의 지역성 변수의 사용 범위 {} 중괄호로 기준
	//
	{
		int var = 5;
		printf("2. var: %d (%p)\n", var, &var);
	}
	printf("3. var: %d (%p)\n", var, &var);
	

	// 상수(Constant)
	const int constVar = 0; // 초기화 필수 나중에는 못바꾸니까.. '상수화 변수'
	//constVar = 10; 변경 안됨
	// 리터럴 상수(Literal Constant)
	//100 = 9; '상수'
	// enum도 리터럴 상수
	// l-value(Locator Value) 지역성을 가진 값. 변수
	// r-value(Value of an expression) 식에 의해서 만들어진 값. 내가 정의하지 않았는데 발생하는 값, 저장 위치를 지정하지 않은 값		
	int val1 = 4, val2 = 10;
	//val1 + val2 = 100;

	//switch case에 case에는 리터럴 상수만 사용 가능 '상수화 변수' 안됨
	return 0;
}