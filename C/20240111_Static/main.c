#include <stdio.h>

int g_cnt = 0;

void StaticFunc() {
	int cnt = 0;
	printf("cnt: %d  ", ++cnt);
	printf("g_cnt: %d  ", ++g_cnt);

	// ��������(Static Variables)
	// �������� �� �޸𸮿� �ö� static class�� ��ü�� ����� ���� �̹� �޸𸮿� �ֱ� ������ ������ �����ϴ�
	// ���������� ���� ���α׷��� ����� ������ �����Ǳ� ������ ��뿡 ����
	static int s_cnt = 0; // ���� ���������� ���� �ȿ����� ������ �����ϴ�
	printf("s_cnt: %d\n", ++s_cnt);
}


int main() {
	for (int i = 0; i < 10; ++i) {
		StaticFunc();
	}

	return 0;
}