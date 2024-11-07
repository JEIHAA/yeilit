#include <stdio.h>

int main() {

	//// i(Index)
	//int i = 0, j = 0;
	//// for(초기문; 조건문; 증감문)
	//for ( i = 0, j = 7; i < 5, j > 6; ++i, j-=2 ) { // 시작과 끝나는 조건이 명확할 때 주로 사용. 조건이 여러개일 경우 하나만 충족해도 루프가 끝난다
	//	printf("i: %d j: %d\n", i, j);
	//}

	//for (i = 0; i < 3; ++i) {
	//	for (j = 0; j < 2; ++j) {
	//		printf("(%d %d)\n", i, j);
	//	}
	//}

	////while
	int i=0;
	//while (i < 5) { i가 5보다 작을 때 동안
	while(1){
		printf("while i : %d\n", i);
		++i;
		if (i>5) break; //i가 5보다 클 때 5까지 출력
	}

	i = 0;
	do {
		printf("do~while i: %d\n", i++);
	} while (i > 1);

	return 0;
}