#include <stdio.h>

int main() {

	// lhs: Left Hand Side
	// rhs: Right Hand Side
	int lhs = 5;
	int rhs = 2;

	printf("lhs + rhs: %d\n", lhs + rhs); // -보다 +가 빠름 -연산은 +연산으로 바꿔서 연산
	printf("lhs - rhs: %d\n", lhs - rhs);
	printf("lhs * rhs: %d\n", lhs * rhs); // /보다 *가 빠름 /연산은 *연산으로 바꿔서 연산
	printf("lhs / rhs: %d\n", lhs / rhs);
	printf("lhs %% srhs: %d\n\n", lhs % rhs);

	printf("1+((3*2)/2.0f) Result: %f\n\n", 1+((3*2)/2.0f));

	//복합 대입 연산자
	lhs += rhs; // lhs = lhs + rhs;
	lhs -= rhs;
	lhs *= rhs;
	lhs /= rhs;
	lhs %= rhs;

	lhs = lhs *= rhs / 2.0f * lhs;

	//단항 연산자
	lhs = 0;
	rhs = 0;
	//후증가 연산자
	printf("lhs++: %d\n", lhs++);
	//선증가 연산자 후증가보다 선증가 연산이 빠름
	printf("++lhs: %d\n", ++lhs);
	printf("rhs--: %d\n", rhs-- );
	printf("--rhs: %d\n\n", --rhs);

	// 삼항연산자   조건 ? 참 : 거짓
	lhs = 5;
	printf("lhs > 3: %c\n\n", lhs > 3 ? 'T' : 'F');
	int result = lhs > 3 ? 10 : 20;

	//비교 연산자
	// Comparison Operator
	int cmp = lhs >= 3;
	printf("cmp: %d\n", cmp);
	// 참, True, 1
	// 거짓 , False, 0
	// A < B, A <= B
	// A > B, A >= B
	// A == B
	// A != B

	// 논리 연산자 Logical Operator
	// AND A && B A 이면서 B
	// OR  A || B A 이거나 B. 이거나, A 이면서 B
	// NOT   !A   A 가 아니다
	
	// (A > B) && (C < D)

	// 논리 연산자는 여러 개의 조건을 비교할 경우 앞의 조건에서 참이나 거짓으로 결정날 경우 뒤의 조건은 검사하지 않는다. 실행되지 않기 때문에 c 와 e의 값은 변하지 않는다.
	int a = 9, b = 4, c = 7, d = 1, e = 3;
	while ((a=1)==1 && (b=2)==3 && (c=3)==3 || (d=4)==4 || (e=5)==7) { 
		printf("a = %d, b = %d, c = %d, d = %d, e = %d", a, b, c, d, e);
		break;
	}

	return 0;
}