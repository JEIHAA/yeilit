#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define MAX_LEN 10

void InitArrayWithRandom(int* _pArr, int _len, int _min, int _max);
void PrintArray(int* _pArr, int _len);

void BubbleSort(int* _pArr, int _len); // 2차원 포인터 배열은 malloc 쓸때만 쓴다

int main() {
	// Bubble Sort
	int arr[MAX_LEN] = { 0 };
	srand(time(NULL));
	InitArrayWithRandom(arr, MAX_LEN, 5, 50);
	PrintArray(arr, MAX_LEN);

	BubbleSort(arr, MAX_LEN);
	PrintArray(arr, MAX_LEN);

	return 0;
}

void InitArrayWithRandom(int* _pArr, int _len, int _min, int _max) {
	int offset = (_max - _min) + 1;

	for (int i = 0; i < MAX_LEN; ++i) {
		*(_pArr + i) = (rand() % 10)+5;
	}

}

void PrintArray(int* _pArr, int _len) {
	for (int i = 0; i < _len; ++i) {
		printf("%d - ", *(_pArr + i));
	}
	printf("(%d)\n", _len);
}

void BubbleSort(int* _pArr, int _len) {
	int length = _len - 1;
	for (int i = 0; i < length - 1; ++i) {
		for (int j = 0; j < length - i; ++j) {
			if (*(_pArr + j) < *(_pArr + j + 1)) {
				int tmp = *(_pArr + j);
				*(_pArr + j) = *(_pArr + j + 1);
				*(_pArr + j + 1) = tmp;
			}
		}
	}
}