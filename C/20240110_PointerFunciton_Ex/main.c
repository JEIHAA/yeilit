#include <stdio.h>

void ChangeValue(int* _pArr) {
	*(_pArr + 1) = 10;
	free(_pArr);
}

int main() {
	float* pArr = (float*)malloc(sizeof(float) * 5);
	float* pArr2 = pArr;

	ChangeValue(pArr); // ChangeValue 내에서 _pArr를 해제해버린다. pArr2에서도 pArr를 참조중이기 때문에 문제가 생긴다.
	// 그래서 참조 카운터가 필요한데 C에서는 안되고 생성자와 소멸자가 있는 C++에서 만들 수 있다.
	if (pArr != NULL) {
		free(pArr);
		pArr = NULL;
	}

	return 0;
}