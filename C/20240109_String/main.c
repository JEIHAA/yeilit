#include <stdio.h>

void SizeOfArray(char _arr[]) {
	printf("_arr Size: %d Byte", sizeof(_arr));
}

void PrintString(char _arr[]) {
	int i = 0;
	while (_arr[i] != '\0')
		printf("%c", _arr[i++]);
	printf("\n");
}

int main() {
	// ���ڿ�(String)
	// '\0': ��(NULL) ����
	// ���ڿ��� ���� �˸�
	char strArr[4] = { 'A', 'B', 'C', '\0' };
	for (int i = 0; i < 3; ++i) {
		printf("%c", strArr[i]);
	}
	printf("\n");

	printf("strArr Size: %d Byte\n", sizeof(strArr));

	char abc[] = "ABC";
	printf("abc Size: %d Byte\n", sizeof(abc)); // �� Ŀ��!	�� ���������ؼ� 4byte
	
	printf("%s\n", strArr);

	SizeOfArray(strArr);

	PrintString("Hello, World!");

	return 0;
}