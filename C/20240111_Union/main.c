#include <stdio.h>

union UMem{ char c; int i; double d; }; // �޸� ���� ū �� �������� �� ���� ����,.�ӽ� ���� ������ �̷��� ��. �����̳� os ���� �����Ҷ� �޸𸮸� �������� �Ƴ��� ��. ����ġ��...�Ƹ�.................
// �ʹ� ū Ÿ������ ����� ������ ��ȿ����

int main() {
	//����ü(Union)
	union UMem mem;
	printf("mem Size: %d Byte\n", sizeof(mem));
	mem.c = 'g';
	printf("mem.c: %c (%p)\n", mem.c, &mem.c);
	mem.i = 23;
	printf("mem.i: %d (%p)\n", mem.i, &mem.i);
	mem.d = 3.14;
	printf("mem.d: %lf (%p)\n", mem.d, &mem.d);

	return 0;
}