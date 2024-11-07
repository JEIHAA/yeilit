#include <stdio.h>
#include <time.h>
#include <stdlib.h>

#define MAX_LEN 10000

void PrintArray(const int* const _pArr, const int const _len);

void Swap(int* _pArr, const int const _len);

//TODO: 싱글 링크드 리스트를 활용해 삽입정렬!

int main()
{
	// 삽입 정렬(Insertion Sort)
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

	/* 실행 코드 들어가는 부분*/

	PrintArray(arr, MAX_LEN);
	printf("Before Swap \n");
	Swap(arr, MAX_LEN);

	printf("Swap After \n");
	PrintArray(arr, MAX_LEN);

	/* Timer off */
	TIME += ((int)clock() - start) / (CLOCKS_PER_SEC / 1000);

	printf("TIME : %d ms\n", TIME); /* ms 단위로 출력 */


	return 0;
}

void PrintArray(const int* const _pArr, const int const _len)
{
	for (int i = 0; i < _len; ++i) // 배열 값 출력
	{
		printf("%d - ", _pArr[i]);
	}
	printf("(%d)\n", _len);
}

void Swap(int* _pArr, const int const _len)
{
	// 1. 키 값 선정
	// 1-1. for (key 1부터 시작하고 MAX 까지)
	for (int i = 1; i < MAX_LEN; ++i)
	{
		int keyIdx = i; //그냥 i값으로 해도 상관없음 잘구분하기위해 넣은것
		for (int j = i-1; j >= 0; --j)//키값 기준으로 왼쪽 값 검사
		{
			if (_pArr[keyIdx] >= _pArr[j])// 만약 keyIdx값이 왼쪽에 있는값보다 크다면 다음 key 값 연산으로 넘어감
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