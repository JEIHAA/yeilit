#include <stdio.h>

enum EAnim {IDLE, WALK, RUN, JUMP, Len}; // 값 넣으면 넣은거 기준으로 그 뒤부터 1씩 증가
//구조체식 #define? 저장 리터럴 상수이기 때문에 다 대문자로 쓰는 경우 많음 kRun 처럼 쓰기도 함

typedef enum _EBGM {
	Field, Battle, Len 
} EBGM;  //typedef 가능

int main() {
	// 열거체(Enumerated Type) 정수를 저장
	printf("Idle: %d\n", IDLE);
	printf("Walk: %d\n", WALK);
	printf("Run: %d\n", RUN);
	printf("Jump: %d\n", JUMP); // 다른 값을 넣어주지 않아도 자동으로 0,1,2,3들어감
	//EAnim.Idle;

	// enum EAnim anim; 초기화 안하면 에러

	enum EAnim anim = 50;
	printf("anim Size: %d Byte\n", sizeof(anim));
	printf("anim: %d\n", anim);

	int arrAnim[Len]; // 자동으로 enum 요소 개수크기의 배열이 만들어짐 이런 식으로 enum을 사용해서 관리
	arrAnim[RUN]; // 가독성 직관성 좋음 관리 쉬움

	switch (anim) {  // 개 편하다!
		case IDLE: break;
		case WALK: break;
		case RUN: break;
		case JUMP: break;
	}

	printf("Len: %d\n", Len); // C는 enum에 같은 이름 쓰는 친구가 있을 경우 에러 발생. C#, C++은 enum 이름도 같이 붙여야하기 때문에(EAnim.Idle) 같은 enum안에 똑같은거 2개 아니면 그럴일 없음

	return 0;
}