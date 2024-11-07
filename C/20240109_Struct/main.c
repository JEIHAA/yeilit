#include <stdio.h>

typedef int HP;

typedef struct _SStatus1 {
	double hp;
	int exp;
	char mp;
	char name;
} SStatus1;

typedef struct _SStatus {
	// 구조체 멤버 변수(Member Variables)
	// 구조체 패딩(padding)
	// 배열과 달리 건너 뛸 값이 일정하지 않아서 차라리 빈 메모리를 더해 4byte씩 맞춰서 받아온다. 근데 제일 큰 애 기준으로 패딩함 빠름
	// char과 char은 1byte라 연달아 있으면 한 칸에 같이 들어있어서 4byte씩 같이 읽어온다. double이 있으면 8byte로 맞춘다
	// 따라서 구조체를 만들 때는 4byte씩 나눠서 같이 정리하는 것이 아주 효율적이다
	// 구조체 안에 구조체 가능 안에 구조체 안에 구조체 안에 구조체안에구조체안에구조체안에구조체안에구조체 건축무한육면각체
	// 구조체 안에 구조체 들어있을 경우 해당 구조체의 가장 큰 자료형을 기준으로 패딩된다
	int hp;
	int exp;
	char mp;
	SStatus1 kkkk;
	char name;
	
} SStatus;
//typedef struct _SStatus SStatus;

int main() {
	// 구조체 Structures, Struct
	// 사용자 정의 자료형
	// .: 구조체 멤버 접근 지정자

	struct _SStatus player1 = {5, 3, 10};
	/*player1.hp = 10;
	player1.mp = 5;
	player1.exp = 100;*/

	printf("SStatus Size: %d Byte\n", sizeof(SStatus));

	printf("player1 Address: %p\n", player1);
	printf("player1.hp: %d (%p)\n", player1.hp, &player1.hp);
	printf("player1.mp: %d (%p)\n", player1.mp, &player1.mp);
	printf("player1.name: %d (%p)\n", player1.name, &player1.name);
	printf("player1.exp: %d (%p)\n", player1.exp, &player1.exp);

	HP myHP = 10;

	return 0;
}