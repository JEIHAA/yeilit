#include <stdio.h>

int main() {

	// lhs: Left Hand Side
	// rhs: Right Hand Side
	int lhs = 5;
	int rhs = 2;

	printf("lhs + rhs: %d\n", lhs + rhs); // -���� +�� ���� -������ +�������� �ٲ㼭 ����
	printf("lhs - rhs: %d\n", lhs - rhs);
	printf("lhs * rhs: %d\n", lhs * rhs); // /���� *�� ���� /������ *�������� �ٲ㼭 ����
	printf("lhs / rhs: %d\n", lhs / rhs);
	printf("lhs %% srhs: %d\n\n", lhs % rhs);

	printf("1+((3*2)/2.0f) Result: %f\n\n", 1+((3*2)/2.0f));

	//���� ���� ������
	lhs += rhs; // lhs = lhs + rhs;
	lhs -= rhs;
	lhs *= rhs;
	lhs /= rhs;
	lhs %= rhs;

	lhs = lhs *= rhs / 2.0f * lhs;

	//���� ������
	lhs = 0;
	rhs = 0;
	//������ ������
	printf("lhs++: %d\n", lhs++);
	//������ ������ ���������� ������ ������ ����
	printf("++lhs: %d\n", ++lhs);
	printf("rhs--: %d\n", rhs-- );
	printf("--rhs: %d\n\n", --rhs);

	// ���׿�����   ���� ? �� : ����
	lhs = 5;
	printf("lhs > 3: %c\n\n", lhs > 3 ? 'T' : 'F');
	int result = lhs > 3 ? 10 : 20;

	//�� ������
	// Comparison Operator
	int cmp = lhs >= 3;
	printf("cmp: %d\n", cmp);
	// ��, True, 1
	// ���� , False, 0
	// A < B, A <= B
	// A > B, A >= B
	// A == B
	// A != B

	// �� ������ Logical Operator
	// AND A && B A �̸鼭 B
	// OR  A || B A �̰ų� B. �̰ų�, A �̸鼭 B
	// NOT   !A   A �� �ƴϴ�
	
	// (A > B) && (C < D)

	// �� �����ڴ� ���� ���� ������ ���� ��� ���� ���ǿ��� ���̳� �������� ������ ��� ���� ������ �˻����� �ʴ´�. ������� �ʱ� ������ c �� e�� ���� ������ �ʴ´�.
	int a = 9, b = 4, c = 7, d = 1, e = 3;
	while ((a=1)==1 && (b=2)==3 && (c=3)==3 || (d=4)==4 || (e=5)==7) { 
		printf("a = %d, b = %d, c = %d, d = %d, e = %d", a, b, c, d, e);
		break;
	}

	return 0;
}