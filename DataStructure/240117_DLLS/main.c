#include <stdio.h>
#include <malloc.h>

#define SAFE_FREE(p) if(p) { free(p); p = NULL;}

typedef struct _SNode
{
	int data;

	struct _SNode* pNext;
	struct _SNode* pPrev;
}SNode;

SNode* CreateNode(const int _data);

void Push(SNode* const _pHead,const int _data);

int Pop(SNode* const _pHead);

void PrintAll(const SNode* const _pHead);

int main()
{
	SNode head = { 0 };
	SNode tail = { 0 };

	head.pNext = &tail;
	tail.pPrev = &head;

	for (int i = 0; i < 10; i++)
	{
		Push(&head, (i + 1) * 5);
	}
	PrintAll(&head);

	printf("%d\n",Pop(&head));

	PrintAll(&head);

	for (int i = 0; i < 4; i++)
	{
		printf("%d\n", Pop(&head));
	}
	PrintAll(&head);


	return 0;
}


SNode* CreateNode(const int _data)
{
	SNode* pNewNode = (SNode*)malloc(sizeof(SNode));

	if (pNewNode)
	{
		pNewNode->data = _data;
		pNewNode->pNext = NULL;
		pNewNode->pPrev = NULL;
	}
	return pNewNode;
}

void Push(SNode* const _pHead,const int _data)
{
	if (!_pHead)
	{
		printf("ERROR] Push Parameter is NULL\n");
		return;
	}
	// 새로운 노드 생성
	SNode* pNewNode = CreateNode(_data);

	// 포인터 조정하여 노드 추가
	pNewNode->pNext = _pHead->pNext;
	pNewNode->pPrev = _pHead;
	_pHead->pNext = pNewNode;
	pNewNode->pNext->pPrev = pNewNode;
}

int Pop(SNode* const _pHead)
{
	if (!_pHead)
	{
		printf("ERROR] Pop Parameter is NULL!\n");
	}
	if (!_pHead->pNext->pNext)
	{
		printf("Empty!\n");
		return;
	}
	SNode* pPopNode = _pHead->pNext;
	int data = pPopNode->data;
	
	_pHead->pNext = pPopNode->pNext;
	pPopNode->pNext->pPrev = _pHead;

	SAFE_FREE(pPopNode);

	return data;
}

void PrintAll(const SNode* const _pHead)
{
	if (!_pHead)
	{
		printf("ERROR] PrintAll Parameter is NULL\n");
		return;
	}
	if (!_pHead->pNext->pNext)
	{
		printf("Empty!\n");
		return;
	}
	SNode* pCurNode = _pHead->pNext;
	int cnt = 0;
	while (pCurNode->pNext)
	{
		printf("%d -", pCurNode->data);
		pCurNode = pCurNode->pNext;
		cnt++;
	}
	printf("\nCount : %d\n", cnt);
}