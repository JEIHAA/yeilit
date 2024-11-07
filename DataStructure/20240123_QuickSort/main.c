#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define MAX_LEN 5

void InitArrayWithRandom(int* _pArr, int _len);
void PrintArray(int* _pArr, int _len);
void PrintArrayRange(int* _pArr, int _startIdx, int _endIdx);

// �갡 ���
void QuickSort(int* _pArr, int _len, int _startIdx, int _endIdx);
// ��ȯ��: �Ǻ��ε���
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
	// ����ó�� ����

	for (int i = _startIdx; i <= _endIdx; ++i)
	{
		printf("%d - ", _pArr[i]);
	}
	printf("(%d)\n", _endIdx - _startIdx + 1);
}

void QuickSort(int* _pArr, int _len, int _startIdx, int _endIdx)
{
	if (_pArr == NULL || _len <= 0) return;
	// Ż�⹮
	if (_startIdx >= _endIdx) return;

	int pivotIdx = Partition(_pArr, _len, _startIdx, _endIdx);
	printf("��Ƽ�� ���� pivotIdx: %d startIdx: %d endIdx : %d\n", pivotIdx, _startIdx, _endIdx);

	// ����
	QuickSort(_pArr, _len, _startIdx, pivotIdx - 1);
	printf("���� ���� pivotIdx: %d startIdx: %d endIdx : %d\n", pivotIdx, _startIdx, _endIdx);
	// ������
	QuickSort(_pArr, _len, pivotIdx + 1, _endIdx);
	printf("������ ���� pivotIdx: %d startIdx: %d endIdx : %d\n", pivotIdx, _startIdx, _endIdx);
}

int Partition(	int* _pArr, int _len,	int _startIdx, int _endIdx) {
	if (_pArr == NULL || _len <= 0) return -1;

	int pivotIdx = _startIdx;
	int leftIdx = _startIdx + 1;
	int rightIdx = _endIdx;
	const int leftLimit = leftIdx;
	const int rightLimit = rightIdx;

	while (leftIdx < rightIdx) {
		// leftIdx�� ���������� �̵�
		while ((leftIdx < rightLimit) && (_pArr[leftIdx] <= _pArr[pivotIdx]))
			++leftIdx;
		printf("leftIdx: %d (%d)\n", leftIdx, _pArr[leftIdx]);

		// rightIdx�� �������� �̵�
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

	// �Ǻ� ��ġ �̵�
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