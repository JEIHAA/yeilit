#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define MAX_LEN 10

typedef struct _SNode
{
	int data;
	struct _SNode* pNext;
}SNode;

//데이터가 겹치지않게 랜덤으로 값 채우기
//TODO: 싱글 링크드 리스트로 선택정렬 구현하기 노드를 떼서 노드를 교환 형태로 만들기

SNode* CreateNode(int _data);
void AddBack(SNode** _pHead, int _data);
int Swap(int* _pArr,int _len);

int main()
{
	// 정렬 알고리즘
	// 선택 정렬(Selection Sort)
	// Big-O Notation(빅오 표기법)
	// O(n^2)

	// 1. 제일 작은 값 찾기
	srand(time(NULL));
	SNode* pHead = NULL;
	int arr[MAX_LEN] = { 0 };
	for (int i = 0; i < MAX_LEN; ++i) //배열에 값 넣기
	{
		arr[i] = rand() % 100;
	}
	
	for (int i = 0; i < MAX_LEN; ++i) // 배열 값 출력
	{
		printf("%d - ", arr[i]);
	}
	printf("(%d)\n", MAX_LEN);

	for (int i = 0; i < MAX_LEN-1; ++i)
	{
		int minIdx = i;
		for (int j = i+1; j < MAX_LEN ; ++j)
		{
			if (arr[minIdx] > arr[j])
			{
				printf("minIdx : %d (%d/%d)\n",arr[j], i ,j);
				minIdx = j;
			}
			
		}
		// 2. 첫 번째 자리와 값 교환
		// // TODO : Swap함수 만들기
		int tmp = arr[minIdx];
		arr[minIdx] = arr[i];
		arr[i] = tmp;
		printf("%d <- %d\n",i,minIdx);
	}
	for(int i = 0; i < MAX_LEN ; ++i)
	{
		printf("%d - ", arr[i]);
	}
	printf("(%d)\n", MAX_LEN);
	


	return 0;
}

SNode* CreateNode(int _data)
{
	SNode* pNewNode = (SNode*)malloc(sizeof(SNode));

	if (pNewNode == NULL)
	{
		pNewNode->data = _data;
		pNewNode->pNext = NULL;
	}
}

void AddBack(SNode** _pHead, int _data)
{
	if (*_pHead == NULL) {
		*_pHead = CreateNode(_data);
		return;
	}
	SNode* pCurNode = *_pHead;
	while (pCurNode->pNext != NULL) {
		pCurNode = pCurNode->pNext;
	}
	SNode* pNewNode = CreateNode(_data);
	pCurNode->pNext = pNewNode;
}
