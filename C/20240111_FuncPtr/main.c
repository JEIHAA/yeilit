#include <stdio.h>

void PrintHello() {
	printf("Hello\n");
}
void PrintWorld() {
	printf("World\n");
};

void (*pFunc)(); // 함수 포인터의 원형

int main() {
	// 함수 포인터(Function Pointer)
	// Function Call Overhead 함수 호출 비용
	pFunc = PrintHello; // 함수 포인터에 함수의 주소를 저장. 함수와 함수 포인터의 반환형, 매개변수 타입과 개수를 맞춰줘야함
	(*pFunc)();
	pFunc = PrintWorld; // 함수의 이름은 그 함수의 주소를 담고 있음
	(*pFunc)();
	// 게임의 키 변경을 할 때 함수 포인터가 쓰이는거다 추상화 클래스 쓸 때


	//inline Funciton 함수를 별개의 지역으로 만들지 않고 메인 코드에 때려박아달라고 요청. 함수를 inline으로 만들면 호출 비용을 줄인다 속도 상승, 하지만 너무 길면 과부화, 컴퓨터가 알아서 컷할수있음
	return 0;
}