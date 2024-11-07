#include <stdio.h>

int g_cnt = 0;

void StaticFunc() {
	int cnt = 0;
	printf("cnt: %d  ", ++cnt);
	printf("g_cnt: %d  ", ++g_cnt);

	// 정적변수(Static Variables)
	// 컴파일할 때 메모리에 올라감 static class도 객체를 만들기 전에 이미 메모리에 있기 때문에 접근이 가능하다
	// 전역변수와 같이 프로그램이 종료될 때까지 유지되기 때문에 사용에 유의
	static int s_cnt = 0; // 값은 유지되지만 지역 안에서만 접근이 가능하다
	printf("s_cnt: %d\n", ++s_cnt);
}


int main() {
	for (int i = 0; i < 10; ++i) {
		StaticFunc();
	}

	return 0;
}