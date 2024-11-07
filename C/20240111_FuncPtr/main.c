#include <stdio.h>

void PrintHello() {
	printf("Hello\n");
}
void PrintWorld() {
	printf("World\n");
};

void (*pFunc)(); // �Լ� �������� ����

int main() {
	// �Լ� ������(Function Pointer)
	// Function Call Overhead �Լ� ȣ�� ���
	pFunc = PrintHello; // �Լ� �����Ϳ� �Լ��� �ּҸ� ����. �Լ��� �Լ� �������� ��ȯ��, �Ű����� Ÿ�԰� ������ ���������
	(*pFunc)();
	pFunc = PrintWorld; // �Լ��� �̸��� �� �Լ��� �ּҸ� ��� ����
	(*pFunc)();
	// ������ Ű ������ �� �� �Լ� �����Ͱ� ���̴°Ŵ� �߻�ȭ Ŭ���� �� ��


	//inline Funciton �Լ��� ������ �������� ������ �ʰ� ���� �ڵ忡 �����ھƴ޶�� ��û. �Լ��� inline���� ����� ȣ�� ����� ���δ� �ӵ� ���, ������ �ʹ� ��� ����ȭ, ��ǻ�Ͱ� �˾Ƽ� ���Ҽ�����
	return 0;
}