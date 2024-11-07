#include <stdio.h>
#include <time.h>
#include <stdlib.h>

#define MAX_LEN 10000

void PrintArray(const int* const _pArr, const int const _len);

void Swap(int* _pArr, const int const _len);

//TODO: �̱� ��ũ�� ����Ʈ�� Ȱ���� ��������!

int main()
{
	// ���� ����(Insertion Sort)
	// O(n^2)
	srand(time(NULL));
	int arr[MAX_LEN] = { 0 };
	for (int i = 0; i < MAX_LEN; ++i)
	{
		arr[i] = rand() % 100;
	}

	int TIME = 0;

	/* Timer on */
	clock_t start = clock();

	/* ���� �ڵ� ���� �κ�*/

	PrintArray(arr, MAX_LEN);
	printf("Before Swap \n");
	Swap(arr, MAX_LEN);

	printf("Swap After \n");
	PrintArray(arr, MAX_LEN);

	/* Timer off */
	TIME += ((int)clock() - start) / (CLOCKS_PER_SEC / 1000);

	printf("TIME : %d ms\n", TIME); /* ms ������ ��� */


	return 0;
}

void PrintArray(const int* const _pArr, const int const _len)
{
	for (int i = 0; i < _len; ++i) // �迭 �� ���
	{
		printf("%d - ", _pArr[i]);
	}
	printf("(%d)\n", _len);
}

void Swap(int* _pArr, const int const _len)
{
	// 1. Ű �� ����
	// 1-1. for (key 1���� �����ϰ� MAX ����)
	for (int i = 1; i < MAX_LEN; ++i)
	{
		int keyIdx = i; //�׳� i������ �ص� ������� �߱����ϱ����� ������
		for (int j = i-1; j >= 0; --j)//Ű�� �������� ���� �� �˻�
		{
			if (_pArr[keyIdx] >= _pArr[j])// ���� keyIdx���� ���ʿ� �ִ°����� ũ�ٸ� ���� key �� �������� �Ѿ
			{
				break;
			}
			if (_pArr[keyIdx] < _pArr[j])
			{
				int tmp = _pArr[keyIdx];
				_pArr[keyIdx] = _pArr[j];
				_pArr[j] = tmp;
				--keyIdx;
			}
		}
	}
}