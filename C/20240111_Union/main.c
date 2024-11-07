#include <stdio.h>

union UMem{ char c; int i; double d; }; // 메모리 제일 큰 애 기준으로 그 공간 공유,.임시 변수 같은거 이렇게 씀. 엔진이나 os 같은 개발할때 메모리를 극한으로 아낄때 씀. 스위치도...아마.................
// 너무 큰 타입으로 만들면 오히려 비효율적

int main() {
	//공용체(Union)
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