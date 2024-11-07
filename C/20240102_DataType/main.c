#include <stdio.h>

void main(void){
	int i = 10; //변수 생성, 초기화
	i = 7; // 변수 값 변경
	printf(" i: %d (%p)\n", i, &i);
	printf(" int size: %d Byte\n\n", sizeof(int)); // sizeof를 %d로 출력해서 워닝 발생

	float f = 3.14f;
	printf(" f: %f (%p)\n", f, &f);
	printf(" f size: %d Byte\n\n", sizeof(f));

	int  ftoi = 3.14f;
	printf(" ftoi: %d / %f\n", ftoi, ftoi); //int형 변수는 %f로 정상적으로 출력할 수 없음

	float itof = 10;
	printf(" itof: %d / %f\n\n", itof, itof); //float형 변수는 %d로 정상적으로 출력할 수 없음

	float x = i + f;
	float x1 = f + i;
	printf(" i+f: %d, %f\n", x, x);
	printf(" f+i: %d, %f\n\n", x1, x1);

	char c1 = 'a'; // 기본적으로 사용되는 char는 signed char, '부호가 붙은' char 부호 비트를 사용하고 싶지 않을 때는 unsigned char 명시
	unsigned char c2;
	printf(" c1: %c ", c1);
	printf(" c1: %c\n", 65); // A의 아스키코드 65, 65를 문자형으로 출력하면 A
	
	c1 = 128;
	printf(" c1: %d ", c1); // -128로 출력됨. 8bit중 첫번째자리, 128 자리는 부호 비트임. 0이 되면 양수 1이 되면 음수가 되므로 표현 가능한 수는 최대 +-127

	c2 = 200;
	printf(" c2: %d\n", c2); //c2는 unsigned char이기 때문에 정상적으로 출력, signed는 부호 비트 검사를 하지만 unsigned는 건너뛰기 때문에 훨씬 빠름
	

	printf(" char Size: %d Byte\n", sizeof(char));

	short s = 5; //풀네임 signed short int, unsigned short int 가능
	printf(" short Size: %d Byte\n", sizeof(short)); //int의 절반 크기. 속도는 int가 가장 빠르지만 메모리를 아끼기 위해서 unsigned short int와 unsigned char 등을 사용  닌텐도는 unsigned가 필수구나!

	long l = 100; // 풀네임 signed long int
	printf(" long Size: %d Byte\n", sizeof(long));

	long long ll = 1000; //signed long long int
	printf(" long long Size: %d Byte\n", sizeof(long long));

	//Double Precision Floationg-Point 두배 정밀한 부동 소수점. 실수는 부호를 뗄 수 없어서 unsigned가 없음 연산속도는 float과 같음, 메모리는 두배 먹음
	//게임 코딩에서는 int가 연산 속도가 가장 빠르기 때문에 실수를 정수로 바꿔서 int 연산을 한 뒤에 다시 실수로 변환하는 방식을 사용하기도 함
	double d = 123.456;
	printf(" double Size: %d Byte\n\n", sizeof(double));

	//컴퓨터가 음수를 구하고 0을 구하는 방법.            1의 보수법을 취한 뒤 1을 더한다 -> 2의 보수


	//Type Casting. Type Conversion
	i = f; // 묵시적 형 변환
	i = (int)f; //명시적 형 변환은 내가 인지하고 사용한 것이기 때문에 워닝이 발생하지 않음 빌드 다시 하면 사라짐	
	printf("(float)i: %f\n", (float)i); //명시적 형 변환 i의 태생은 int형인데 출력하는 순간에 (float)을 넣어서 그 순간에만 float로 바뀜.(강제 )

	float result = (float)5 / 2; // 그냥 5/2는 int형 연산이라 2.000으로 저장됨
	//협업할 때 한눈에 보고 알 수 있도록 모든 것을 명확히 표시하는게 좋다 괜히 한번 더 생각할 필요 없게한다. 깔끔담백
	// 쓸데 없는 형 변환이 발생하지 않도록 자료형을 최대한 맞춘다. 메모리와 속도 낭비. 스위치는 연약하니까
	//(float)5/2나 5.0/2.0하면 정상적으로 동작됨 하나만 형 변환해도 정상작동 되는 이유는 자료형이 섞여있을 때에는 더 정밀도가 높은 자료형으로 계산됨. '자료형의 승격'
	printf("result: %f\n", result);


	char t1 = -128;
	unsigned char t2 = t1;
	printf("%d %d", t1, t2);
}