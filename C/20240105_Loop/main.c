#include <stdio.h>

int main() {

	//// i(Index)
	//int i = 0, j = 0;
	//// for(�ʱ⹮; ���ǹ�; ������)
	//for ( i = 0, j = 7; i < 5, j > 6; ++i, j-=2 ) { // ���۰� ������ ������ ��Ȯ�� �� �ַ� ���. ������ �������� ��� �ϳ��� �����ص� ������ ������
	//	printf("i: %d j: %d\n", i, j);
	//}

	//for (i = 0; i < 3; ++i) {
	//	for (j = 0; j < 2; ++j) {
	//		printf("(%d %d)\n", i, j);
	//	}
	//}

	////while
	int i=0;
	//while (i < 5) { i�� 5���� ���� �� ����
	while(1){
		printf("while i : %d\n", i);
		++i;
		if (i>5) break; //i�� 5���� Ŭ �� 5���� ���
	}

	i = 0;
	do {
		printf("do~while i: %d\n", i++);
	} while (i > 1);

	return 0;
}