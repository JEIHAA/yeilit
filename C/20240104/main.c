#include <stdio.h>

int main() {
	/*int a, b, c, d, e, f;

	scanf("%d %d %d", &a, &b, &c);
	scanf("%d %d %d", &d, &e, &f);

	printf("입력된 값은: %d %d %d\n", a, b, c);
	printf("입력된 값은: %d %d %d\n", d, e, f);*/

	/*int a, b;

	printf("a: ");
	scanf("%d", &a);
	printf("b: ");
	scanf("%d", &b);
	
	printf("입력 값 a = %d, b = %d\n", a, b);
	
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
	printf("사이즈는 %c입니다.\n", size);*/

	float num1, num2;
	char oper;

	while (1)
	{
		printf("사칙연산 입력 : ");
		scanf("%f %c %f", &num1, &oper, &num2); //입력이 3개를 넘어갈 경우 다시 입력하세요 출력 후 다시 입력 받아야하는데 입력 받지 않고 바로 다시 입력하세요 출력, 무한 반복됨

		/*문제는 버퍼에 남아있는 개행 문자('\n') 때문에 발생할 수 있습니다. 
		scanf 함수는 입력을 받은 후에 개행 문자를 처리하지 않고 남겨둡니다. 
		이로 인해 사용자가 입력을 마치고 엔터 키를 누를 때, 개행 문자가 버퍼에 남게 되고, 
		다음 scanf 호출에서 이 개행 문자를 처리하여 추가적인 입력을 받지 않고 넘어가는 문제가 발생할 수 있습니다.*/
		/* 해결방법
		1. scanf를 사용한 후에 버퍼를 비워주는 방법입니다. scanf 이후에 getchar 함수를 호출하여 개행 문자를 소비하도록 하는 방법 
		2. scanf 대신에 fgets 함수를 사용하여 한 줄 전체를 읽어들이고, 그 후에 문자열을 파싱하는 방법*/

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
			printf("다시 입력하세요.\n\n");
			while ((oper = getchar()) != '\n' && oper!= EOF);
		}
	}	


	return 0;
}