#include <stdio.h>

void ChangeValue(int* _pArr) {
	*(_pArr + 1) = 10;
	free(_pArr);
}

int main() {
	float* pArr = (float*)malloc(sizeof(float) * 5);
	float* pArr2 = pArr;

	ChangeValue(pArr); // ChangeValue ������ _pArr�� �����ع�����. pArr2������ pArr�� �������̱� ������ ������ �����.
	// �׷��� ���� ī���Ͱ� �ʿ��ѵ� C������ �ȵǰ� �����ڿ� �Ҹ��ڰ� �ִ� C++���� ���� �� �ִ�.
	if (pArr != NULL) {
		free(pArr);
		pArr = NULL;
	}

	return 0;
}