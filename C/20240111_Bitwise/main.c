#include <stdio.h>

typedef enum _EOptions {
	Clean = 0, //op_Clean �ɼǿ� Clean�̶�� �ǹ̷� op_ �� ���̱⵵ ��
	FullScreen = 1,
	Minimize = 2,
	ScrollH = 4,
	ScrollV = 8,
	BtnExit = 16,
	Menu = 32
} EOptions;

void ApplyOption(char* const _pOp, EOptions _applyOp) { // �ɼ� �ѱ�
	(*_pOp) |= _applyOp;
	
	/*
	int i = 10;
	_pOp = &i; // ū�ϳ�
	// �׷��� char* const _pOp �ؾ���

	char* const _pOp - _pOp�� �ּ� ��ȣ
	const char* _pOp - _pOp�� �� ��ȣ
	*/

}

void OffOption(char* const _pOp, EOptions _applyOp) { // �ɼ� ����
	(*_pOp) ^= _applyOp;
}

void PrintOptions(const char _op) { // �ɼ� Ȯ��
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
	// ��Ʈ���� ������(Bitwise Operator)
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
	// NOT�� �ϰ� ������ ��
	// 1111 1100�� MSB�� 1�̱� ������ �츮���� �����ֱ� ���� 2�� ������ ����
	// 1000 0100 = -4
	// ��������� ~0(MSB)0000011�� �Ǵ� ���� ������
	// ȭ�鿡 ����ϱ� ���� ���� �о�� �� ��ȣ��Ʈ�� 1�̶� 2�� ������ ���� �ڿ� �����ش�

	// shift Operator
	printf("lhs << 1 : %d\n", lhs << 1);
	// 011 << 1 = 110 = 6
	// 101 << 1 = 1010 = 10

	printf("lhs >> 1 : %d\n", lhs >> 1);
	// 011 >> 1 = 001 = 1
	// 101 >> 1 = 010 = 2

	// Bit Flags ��Ʈ �����״ٷ� �ɼ� ���� 8bit �ϳ����� �����״� �ɼ� �����״�
	// enum���� menu �������� 128 64 32 16(menu) 8 4 2 1 enum.menu = 16�ϸ� menu�� 16 �κ� ��Ʈ �����״� ����
	// �ش� bit�� 0�̸� ������ 1�̸� ������
	// 0 ������ �� �����°� 255 ������ �� �����°�

	unsigned char option = Clean;

	// �ɼ� �ѱ� | (OR)
	option |= ScrollV; // 00000000 | 00000100 = 00000100
	option |= ScrollH; // 00000100 | 00001000 = 00001100
	option |= Menu | Minimize; // 00001100 | 00100000 | 00000010 = 00101110

	// ��� �����ִ��� Ȯ���ϱ� & (AND)
	printf("Check Menu: %c\n", (option & Menu) > 0 ? 'C' : 'E'); // 00101110 & 00000100 = 00000100 = 00000100 > 0 = 8 > 0 = C(True)

	// Ư�� �ɼǸ� ����
	option ^= Menu; // 00101110 ^ 00100000 = 00001110
	printf("option: %d\n", option);


	// �Լ��� �����ϱ� (�ɼ� �ѱ�, ����, Ȯ���ϱ�� ���� ����̴ϱ� �Լ��� ���� �����ϴ°� ����)
	ApplyOption(&option, BtnExit);
	OffOption(&option, Minimize);
	OffOption(&option, Minimize);
	PrintOptions(option);


	return 0;
}