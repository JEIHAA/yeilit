#include <stdio.h>

#define MAX_VAL 100
// 100�̶�� ���ڸ� MAX_VAL�̶�� �̸����ε� ����� �� �ֵ��� '����'
// ġȯ
// ������Ҷ� �Ⱥ��� �׳� ���ڷ� ���� �׳� const ���� ���� ���°� ���� ���� �ִ� �׷��� ��� ���ͷ� ����� case�� �� �� �ִ�

// ��������(Global Variables)
// C�� C++������ ��ȿ
int g_var;
// main �ۿ� ������� ������ �ٸ� �Լ������� ���� ����
// ���α׷� ���۵� �� �޸𸮿� �ö󰡰� ���� �� ��������

void ChangeVariavle() {
	//var = 100;
	g_var = 100;
}

int main() {


	// f9 �극��ŷ����Ʈ f10 �������� ����� ����
	// ����(Variables)
	// ���� ����(Declaration)

	// �ʱ�ȭ(Initicalzation)
	// ������ ��(Garbage Value)
	// ������ �Ҵ���� �޸𸮿� � ���� ��������� ��. �ʱ�ȭ �ȵǾ����� => �����Ⱚ �������
	// int var = 0; <- �ʱ�ȭ ���Ϻ���
	// int var;
	// var = 0; <- �ʱ�ȭx 0 ����
	int var = 10;
	printf("1. var: %d (%p)\n", var, &var);

	// ������ ������ ������ ��� ���� {} �߰�ȣ�� ����
	//
	{
		int var = 5;
		printf("2. var: %d (%p)\n", var, &var);
	}
	printf("3. var: %d (%p)\n", var, &var);
	

	// ���(Constant)
	const int constVar = 0; // �ʱ�ȭ �ʼ� ���߿��� ���ٲٴϱ�.. '���ȭ ����'
	//constVar = 10; ���� �ȵ�
	// ���ͷ� ���(Literal Constant)
	//100 = 9; '���'
	// enum�� ���ͷ� ���
	// l-value(Locator Value) �������� ���� ��. ����
	// r-value(Value of an expression) �Ŀ� ���ؼ� ������� ��. ���� �������� �ʾҴµ� �߻��ϴ� ��, ���� ��ġ�� �������� ���� ��		
	int val1 = 4, val2 = 10;
	//val1 + val2 = 100;

	//switch case�� case���� ���ͷ� ����� ��� ���� '���ȭ ����' �ȵ�
	return 0;
}