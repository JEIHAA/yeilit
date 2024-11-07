#include <stdio.h>

enum EAnim {IDLE, WALK, RUN, JUMP, Len}; // �� ������ ������ �������� �� �ں��� 1�� ����
//����ü�� #define? ���� ���ͷ� ����̱� ������ �� �빮�ڷ� ���� ��� ���� kRun ó�� ���⵵ ��

typedef enum _EBGM {
	Field, Battle, Len 
} EBGM;  //typedef ����

int main() {
	// ����ü(Enumerated Type) ������ ����
	printf("Idle: %d\n", IDLE);
	printf("Walk: %d\n", WALK);
	printf("Run: %d\n", RUN);
	printf("Jump: %d\n", JUMP); // �ٸ� ���� �־����� �ʾƵ� �ڵ����� 0,1,2,3��
	//EAnim.Idle;

	// enum EAnim anim; �ʱ�ȭ ���ϸ� ����

	enum EAnim anim = 50;
	printf("anim Size: %d Byte\n", sizeof(anim));
	printf("anim: %d\n", anim);

	int arrAnim[Len]; // �ڵ����� enum ��� ����ũ���� �迭�� ������� �̷� ������ enum�� ����ؼ� ����
	arrAnim[RUN]; // ������ ������ ���� ���� ����

	switch (anim) {  // �� ���ϴ�!
		case IDLE: break;
		case WALK: break;
		case RUN: break;
		case JUMP: break;
	}

	printf("Len: %d\n", Len); // C�� enum�� ���� �̸� ���� ģ���� ���� ��� ���� �߻�. C#, C++�� enum �̸��� ���� �ٿ����ϱ� ������(EAnim.Idle) ���� enum�ȿ� �Ȱ����� 2�� �ƴϸ� �׷��� ����

	return 0;
}