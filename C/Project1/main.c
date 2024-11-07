#include <stdio.h>

void PrintArray(int _arr[5], int _len);

int main() {
	int arr[5] = { 0 };

	printf("arr Size: %d Byte\n", sizeof(arr));

	int len = sizeof(arr) / sizeof(arr[0]);

	//PrintArray(arr, len);
	for (int i = 0; i < len; ++i) {
		printf("arr[%d]: %d (%p)\n", i, arr[i], &arr[i]);
	}

	printf("arr Address: %p\n", arr + 1); 
	
	int tmpArr[3] = { 10, 20, 30 };
	PrintArray(tmpArr, 3);

	return 0;
}

int PrintArray(int _arr[5], int _len) {
	int len = sizeof(_arr) / sizeof(_arr[0]);
	
	printf("_arr Size: %d Byte\n", sizeof(_arr));
	
	for (int i = 0; i < len; ++i) {
		printf("_arr[%d]: %d\n", i, _arr[i]);
	}

	return 0;
}