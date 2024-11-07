#include <stdio.h>

typedef enum _EOptions {
	Clean = 0, //op_Clean 옵션용 Clean이라는 의미로 op_ 를 붙이기도 함
	FullScreen = 1,
	Minimize = 2,
	ScrollH = 4,
	ScrollV = 8,
	BtnExit = 16,
	Menu = 32
} EOptions;

void ApplyOption(char* const _pOp, EOptions _applyOp) { // 옵션 켜기
	(*_pOp) |= _applyOp;
	
	/*
	int i = 10;
	_pOp = &i; // 큰일남
	// 그래서 char* const _pOp 해야함

	char* const _pOp - _pOp의 주소 보호
	const char* _pOp - _pOp의 값 보호
	*/

}

void OffOption(char* const _pOp, EOptions _applyOp) { // 옵션 끄기
	(*_pOp) ^= _applyOp;
}

void PrintOptions(const char _op) { // 옵션 확인
	printf("\n=== OPTION ===\n\n");
	printf("FullScreen: %c\n", (_op & FullScreen) > 0 ? 'C' : 'E');
	printf("Minimize  : %c\n", (_op & Minimize) > 0 ? 'C' : 'E');
	printf("ScrollH   : %c\n", (_op & ScrollH) > 0 ? 'C' : 'E');
	printf("ScrollV   : %c\n", (_op & ScrollV) > 0 ? 'C' : 'E');
	printf("BtnExit   : %c\n", (_op & BtnExit) > 0 ? 'C' : 'E');
	printf("Menu      : %c\n", (_op & Menu) > 0 ? 'C' : 'E');
	printf("\n==============\n");
}

int main() {
	// 비트단위 연산자(Bitwise Operator)
	int lhs = 3, rhs = 5;
	// 3 = 011, 5 = 101

	// & (AND)
	printf("lhs & rhs: %d\n", lhs&rhs);
	// 011 & 101 = 001 = 1
	// 0&1 = 0, 1&0=0, 1&1=1 = 001 = 0

	// | (OR)
	printf("lhs | rhs: %d\n", lhs | rhs);
	// 011 | 101 = 111 = 7
	// 0|1 = 1, 1|0 = 1, 1|1 = 1 = 111 = 7

	// ^ (XOR)
	printf("lhs ^ rhs: %d\n", lhs ^ rhs);
	// 011 ^ 101 = 110 = 6
	// 0^1 = 1, 1^0 = 1, 1^1 = 0 = 110 = 6

	// ~ (NOT)
	printf("   ~lhs: %d\n", ~lhs);
	// ~11 = ~0(MSB)0000011 = 4
	// 1111 1100 = ~3
	// NOT을 하고 저장이 됨
	// 1111 1100은 MSB가 1이기 때문에 우리한테 보여주기 위해 2의 보수를 취함
	// 1000 0100 = -4
	// 결론적으로 ~0(MSB)0000011이 되는 것이 맞지만
	// 화면에 출력하기 위해 값을 읽어올 때 부호비트가 1이라 2의 보수를 취한 뒤에 보여준다

	// shift Operator
	printf("lhs << 1 : %d\n", lhs << 1);
	// 011 << 1 = 110 = 6
	// 101 << 1 = 1010 = 10

	printf("lhs >> 1 : %d\n", lhs >> 1);
	// 011 >> 1 = 001 = 1
	// 101 >> 1 = 010 = 2

	// Bit Flags 비트 껐다켰다로 옵션 관리 8bit 하나별로 껐다켰다 옵션 껐다켰다
	// enum으로 menu 만들어놓고 128 64 32 16(menu) 8 4 2 1 enum.menu = 16하면 menu로 16 부분 비트 껐다켰다 가능
	// 해당 bit가 0이면 꺼진거 1이면 켜진거
	// 0 넣으면 다 꺼지는거 255 넣으면 다 켜지는거

	unsigned char option = Clean;

	// 옵션 켜기 | (OR)
	option |= ScrollV; // 00000000 | 00000100 = 00000100
	option |= ScrollH; // 00000100 | 00001000 = 00001100
	option |= Menu | Minimize; // 00001100 | 00100000 | 00000010 = 00101110

	// 욥션 켜져있는지 확인하기 & (AND)
	printf("Check Menu: %c\n", (option & Menu) > 0 ? 'C' : 'E'); // 00101110 & 00000100 = 00000100 = 00000100 > 0 = 8 > 0 = C(True)

	// 특정 옵션만 끄기
	option ^= Menu; // 00101110 ^ 00100000 = 00001110
	printf("option: %d\n", option);


	// 함수로 관리하기 (옵션 켜기, 끄기, 확인하기는 각각 기능이니까 함수로 빼서 관리하는게 좋음)
	ApplyOption(&option, BtnExit);
	OffOption(&option, Minimize);
	OffOption(&option, Minimize);
	PrintOptions(option);


	return 0;
}