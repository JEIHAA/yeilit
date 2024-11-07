#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define MAX_LEN 5

void InitArrayWithRandom(int* _pArr, int _len);
void PrintArray(int* _pArr, int _len);
void PrintArrayRange(int* _pArr, int _startIdx, int _endIdx);

// 얘가 재귀
void QuickSort(int* _pArr, int _len, int _startIdx, int _endIdx);
// 반환값: 피봇인덱스
int Partition(int* _pArr, int _len, int _startIdx, int _endIdx);

int main()
{
	srand(time(NULL));
	int arr[MAX_LEN] = { 0 };
	InitArrayWithRandom(arr, MAX_LEN);
	PrintArray(arr, MAX_LEN);

	QuickSort(arr, MAX_LEN, 0, MAX_LEN - 1);

	PrintArray(arr, MAX_LEN);

	return 0;
}

void InitArrayWithRandom(int* _pArr, int _len)
{
	for (int i = 0; i < _len; ++i)
	{
		_pArr[i] = rand() % 50;
	}
}

void PrintArray(int* _pArr, int _len)
{
	for (int i = 0; i < _len; ++i)
	{
		printf("%d - ", _pArr[i]);
	}
	printf("(%d)\n", _len);
}

void PrintArrayRange(
	int* _pArr, int _startIdx, int _endIdx) {
	// 예외처리 주의

	for (int i = _startIdx; i <= _endIdx; ++i)
	{
		printf("%d - ", _pArr[i]);
	}
	printf("(%d)\n", _endIdx - _startIdx + 1);
}

void QuickSort(int* _pArr, int _len, int _startIdx, int _endIdx)
{
	if (_pArr == NULL || _len <= 0) return;
	// 탈출문
	if (_startIdx >= _endIdx) return;

	int pivotIdx = Partition(_pArr, _len, _startIdx, _endIdx);
	printf("파티션 끝남 pivotIdx: %d startIdx: %d endIdx : %d\n", pivotIdx, _startIdx, _endIdx);

	// 왼쪽
	QuickSort(_pArr, _len, _startIdx, pivotIdx - 1);
	printf("왼쪽 끝남 pivotIdx: %d startIdx: %d endIdx : %d\n", pivotIdx, _startIdx, _endIdx);
	// 오른쪽
	QuickSort(_pArr, _len, pivotIdx + 1, _endIdx);
	printf("오른쪽 끝남 pivotIdx: %d startIdx: %d endIdx : %d\n", pivotIdx, _startIdx, _endIdx);
}

int Partition(	int* _pArr, int _len,	int _startIdx, int _endIdx) {
	if (_pArr == NULL || _len <= 0) return -1;

	int pivotIdx = _startIdx;
	int leftIdx = _startIdx + 1;
	int rightIdx = _endIdx;
	const int leftLimit = leftIdx;
	const int rightLimit = rightIdx;

	while (leftIdx < rightIdx) {
		// leftIdx를 오른쪽으로 이동
		while ((leftIdx < rightLimit) && (_pArr[leftIdx] <= _pArr[pivotIdx]))
			++leftIdx;
		printf("leftIdx: %d (%d)\n", leftIdx, _pArr[leftIdx]);

		// rightIdx를 왼쪽으로 이동
		while ((rightIdx > leftLimit) && (_pArr[rightIdx] >= _pArr[pivotIdx]))
			--rightIdx;
		printf("rightIdx: %d (%d)\n", rightIdx, _pArr[rightIdx]);

		if (leftIdx >= rightIdx) break;

		// Swap
		int tmp = _pArr[leftIdx];
		_pArr[leftIdx] = _pArr[rightIdx];
		_pArr[rightIdx] = tmp;

		PrintArray(_pArr, _len);
	}

	// 피봇 위치 이동
	if (_pArr[pivotIdx] > _pArr[rightIdx])
	{
		int tmp = _pArr[pivotIdx];
		_pArr[pivotIdx] = _pArr[rightIdx];
		_pArr[rightIdx] = tmp;

		printf("Pivot Move: %d\n", rightIdx);
		PrintArray(_pArr, _len);
		return rightIdx;
	}

	return pivotIdx;
}