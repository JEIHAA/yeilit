#include <stdio.h>

int main() {
	/*int a, b, c, d, e, f;

	scanf("%d %d %d", &a, &b, &c);
	scanf("%d %d %d", &d, &e, &f);

	printf("�Էµ� ����: %d %d %d\n", a, b, c);
	printf("�Էµ� ����: %d %d %d\n", d, e, f);*/

	/*int a, b;

	printf("a: ");
	scanf("%d", &a);
	printf("b: ");
	scanf("%d", &b);
	
	printf("�Է� �� a = %d, b = %d\n", a, b);
	
	if (a > b) {
		b = a;
		printf("a = %d, b = %d\n", a, b);
	}
	else {
		printf("a = %d, b = %d\n", a, b);
	}

	if (a > 10) {
		if (b >= 0) {
			b = 1;
		}
		else {
			b = -1;
		}
	}
	printf("a = %d, b = %d", a, b);*/

	/*int age = 25, chest = 95;
	char size;
	if (age < 20) {
		if (chest > 95) {
			size = 'L';
		}
		else if (chest >= 85) {
			size = 'M';
		}
		else {
			size = 'S';
		}
	}
	else {
		if (chest > 100) {
			size = 'L';
		}
		else if (chest >= 90) {
			size = 'M';
		}
		else {
			size = 'S';
		}
	}
	printf("������� %c�Դϴ�.\n", size);*/

	float num1, num2;
	char oper;

	while (1)
	{
		printf("��Ģ���� �Է� : ");
		scanf("%f %c %f", &num1, &oper, &num2); //�Է��� 3���� �Ѿ ��� �ٽ� �Է��ϼ��� ��� �� �ٽ� �Է� �޾ƾ��ϴµ� �Է� ���� �ʰ� �ٷ� �ٽ� �Է��ϼ��� ���, ���� �ݺ���

		/*������ ���ۿ� �����ִ� ���� ����('\n') ������ �߻��� �� �ֽ��ϴ�. 
		scanf �Լ��� �Է��� ���� �Ŀ� ���� ���ڸ� ó������ �ʰ� ���ܵӴϴ�. 
		�̷� ���� ����ڰ� �Է��� ��ġ�� ���� Ű�� ���� ��, ���� ���ڰ� ���ۿ� ���� �ǰ�, 
		���� scanf ȣ�⿡�� �� ���� ���ڸ� ó���Ͽ� �߰����� �Է��� ���� �ʰ� �Ѿ�� ������ �߻��� �� �ֽ��ϴ�.*/
		/* �ذ���
		1. scanf�� ����� �Ŀ� ���۸� ����ִ� ����Դϴ�. scanf ���Ŀ� getchar �Լ��� ȣ���Ͽ� ���� ���ڸ� �Һ��ϵ��� �ϴ� ��� 
		2. scanf ��ſ� fgets �Լ��� ����Ͽ� �� �� ��ü�� �о���̰�, �� �Ŀ� ���ڿ��� �Ľ��ϴ� ���*/

		if (oper == '+') {
			printf("%.2f %c %.2f = %.2f\n\n", num1, oper, num2, num1+num2);
			while ((oper = getchar()) != '\n' && oper != EOF);
			break;
		}
		else if (oper == '-') {
			printf("%.2f %c %.2f = %.2f\n\n", num1, oper, num2, num1-num2);
			while ((oper = getchar()) != '\n' && oper != EOF);
			break;
		}
		else if (oper == '*') {
			printf("%.2f %c %.2f = %.2f\n\n", num1, oper, num2, num1*num2);
			while ((oper = getchar()) != '\n' && oper != EOF);
			break;
		}
		else if (oper == '/') {
			printf("%.2f %c %.2f = %.2f\n\n", num1, oper, num2, num1/num2);
			while ((oper = getchar()) != '\n' && oper != EOF);
			break;
		}
		else {
			printf("�ٽ� �Է��ϼ���.\n\n");
			while ((oper = getchar()) != '\n' && oper!= EOF);
		}
	}	


	return 0;
}