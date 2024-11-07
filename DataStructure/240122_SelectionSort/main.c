#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define MAX_LEN 10

typedef struct _SNode
{
	int data;
	struct _SNode* pNext;
}SNode;

//�����Ͱ� ��ġ���ʰ� �������� �� ä���
//TODO: �̱� ��ũ�� ����Ʈ�� �������� �����ϱ� ��带 ���� ��带 ��ȯ ���·� �����

SNode* CreateNode(int _data);
void AddBack(SNode** _pHead, int _data);
int Swap(int* _pArr,int _len);

int main()
{
	// ���� �˰���
	// ���� ����(Selection Sort)
	// Big-O Notation(��� ǥ���)
	// O(n^2)

	// 1. ���� ���� �� ã��
	srand(time(NULL));
	SNode* pHead = NULL;
	int arr[MAX_LEN] = { 0 };
	for (int i = 0; i < MAX_LEN; ++i) //�迭�� �� �ֱ�
	{
		arr[i] = rand() % 100;
	}
	
	for (int i = 0; i < MAX_LEN; ++i) // �迭 �� ���
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
		// 2. ù ��° �ڸ��� �� ��ȯ
		// // TODO : Swap�Լ� �����
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
