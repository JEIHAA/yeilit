#include <stdio.h>

typedef int HP;

typedef struct _SStatus1 {
	double hp;
	int exp;
	char mp;
	char name;
} SStatus1;

typedef struct _SStatus {
	// ����ü ��� ����(Member Variables)
	// ����ü �е�(padding)
	// �迭�� �޸� �ǳ� �� ���� �������� �ʾƼ� ���� �� �޸𸮸� ���� 4byte�� ���缭 �޾ƿ´�. �ٵ� ���� ū �� �������� �е��� ����
	// char�� char�� 1byte�� ���޾� ������ �� ĭ�� ���� ����־ 4byte�� ���� �о�´�. double�� ������ 8byte�� �����
	// ���� ����ü�� ���� ���� 4byte�� ������ ���� �����ϴ� ���� ���� ȿ�����̴�
	// ����ü �ȿ� ����ü ���� �ȿ� ����ü �ȿ� ����ü �ȿ� ����ü�ȿ�����ü�ȿ�����ü�ȿ�����ü�ȿ�����ü ���๫�����鰢ü
	// ����ü �ȿ� ����ü ������� ��� �ش� ����ü�� ���� ū �ڷ����� �������� �е��ȴ�
	int hp;
	int exp;
	char mp;
	SStatus1 kkkk;
	char name;
	
} SStatus;
//typedef struct _SStatus SStatus;

int main() {
	// ����ü Structures, Struct
	// ����� ���� �ڷ���
	// .: ����ü ��� ���� ������

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