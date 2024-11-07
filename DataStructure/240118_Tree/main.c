#include <stdio.h>
#include <malloc.h>
#include <stdlib.h>
#include <time.h>

#define SAFE_FREE(p)\
do {\
if(p) { free(p); p = NULL; }\
} while(0)

typedef struct _SNode {
	int data;
	struct SNode* pLeft;
	struct SNode* pRight;
} SNode;


SNode* CreateNode(int _data);

void BuildTree(SNode** const _pRoot, const int* const _pDataSet, int _dataCnt);

void AddNodeRecursive(SNode* const _pNode, int _data);

void PrintAll(const SNode* const _pRoot);

int PrintAllRecursive(const SNode* const _pNode);

// TODO: 만들어 보자! 레벨별로 출력!
int PrintAllWithLevel(const SNode* const _pRoot,int _cnt);

void RemoveAll(SNode** const _pRoot);

void RemoveAllRecursive(SNode** const _pNode);

// TODO: 만들어 보자! 데이터 찾기!
SNode* Search(const SNode* const _pRoot, int _data);


int main()
{
	// 이진 탐색 나무(트리)
	// Binary Search Tree
	// Random Seed
	srand(time(NULL));

	int dataSet[10] = { 0 };
	for (int i = 0; i < 10; ++i) 
	{
		// Random
		int rnd = (rand() % 50) + 5;
		printf("%d - ", rnd);
		dataSet[i] = rnd;
	}
	
	printf("(10)\n\n");

	SNode* pRoot = NULL;
	BuildTree(&pRoot, dataSet, 10);
	PrintAll(pRoot);

	SNode* saveNode = Search(pRoot, 50);
	
	//RemoveAll(&pRoot);
	//PrintAll(pRoot);
	
	if (saveNode == NULL) {
		printf("love world");
	}
	else if (saveNode != NULL) {
		printf("world suck");
	}

	

	return 0;
}


SNode* CreateNode(int _data) { 
	SNode* pNewNode = (SNode*)malloc(sizeof(SNode));
	if (pNewNode)
	{
		pNewNode->data = _data;
		pNewNode->pLeft = NULL;
		pNewNode->pRight = NULL;
	}
	return pNewNode;
}

void BuildTree(SNode** const _pRoot, const int* const _pDataSet, int _dataCnt) {
	if (_pRoot) {
		
	}

	if (!_pDataSet) 
	{
		printf("_pNode is NULL!\n");
		return;
	}

	*_pRoot = CreateNode(_pDataSet[0]);
	printf("{R:%d}\n", (*_pRoot)->data);
	for (int i = 1; i < _dataCnt; ++i)
	{
		AddNodeRecursive(*_pRoot, _pDataSet[i]);
	}
}

void AddNodeRecursive(SNode* const _pNode, int _data) {
	if (!_pNode)
	{
		printf("_pNode is NULL!\n");
		return;
	}

	// 탈출조건
	// 왼쪽으로 가는 조건
	if (_data < _pNode->data) {
		// 노드가 있는 경우
		if (_pNode->pLeft != NULL) {
			printf("[L] - ");
			AddNodeRecursive(_pNode->pLeft, _data);
		}
		else {
			printf("<L:%d>\n", _data);
			SNode* pNewNode = CreateNode(_data);
			_pNode->pLeft = pNewNode;
			return;
		}
	}
	// 오른쪽으로 가는 조건
	else {
		if (_pNode->pRight != NULL) {
			printf("[R] - ");
			AddNodeRecursive(_pNode->pRight,_data);
		}
		else {
			printf("<R:%d>\n", _data);
			SNode* pNewNode = CreateNode(_data);
			_pNode->pRight = pNewNode;
			return;
		}
	}
}

void PrintAll(const SNode* const _pRoot) {
	if (!_pRoot) 
	{
		printf("ERROR] (PrintAll) Parameter is NULL\n");
		return;
	}
	int cnt = 0;
	cnt = PrintAllRecursive(_pRoot);
	// 완료~
	printf("\ncount : %d\n",cnt);
}

int PrintAllRecursive(const SNode* const _pNode)
{
	int static cnt = 0;
	if (!_pNode)
	{
		printf("ERROR] (PrintRecursive) Parameter is NULL\n");
		return;
	}
	
	if (_pNode->pLeft)
	{
		PrintAllRecursive(_pNode->pLeft);
	}
	

	printf("%d - ", _pNode->data);
	cnt++;

	if (_pNode->pRight)
	{
		PrintAllRecursive(_pNode->pRight);
	}
	return cnt;
}

int PrintAllWithLevel(const SNode* const _pRoot, int cnt)
{
	if (!_pRoot)
	{
		printf("ERROR] PrintAllWithLevel Parameter is NULL!\n");
	}

	
	/*if (_pRoot->pLeft)
	{
		if(
	}*/

}

void RemoveAll(SNode** const _pRoot) {
	if (!_pRoot)
	{
		printf("ERROR] (RemoveAll) Parameter is NULL\n");
		return;
	}
	RemoveAllRecursive(_pRoot);
	printf("RemoveAll %s\n", (*_pRoot) == NULL ? "Done" : "Failed");
}

void RemoveAllRecursive(SNode** const _pNode) {
	if (!(*_pNode))
	{
		printf("ERROR] (RemoveRecursive) Parameter is NULL\n");
		return;
	}

	if ((*_pNode)->pLeft)
	{
		RemoveAllRecursive(&((*_pNode)->pLeft));
	}

	if ((*_pNode)->pRight)
	{
		RemoveAllRecursive(&((*_pNode)->pRight));
	}
		

	printf("(%d) - ", (*_pNode)->data);
	SAFE_FREE((*_pNode));
}

SNode* Search(const SNode* const _pRoot, int _data)
{
	if (!_pRoot)
	{
		printf("ERROR] (Search) Parameter is NULL\n");
		return;
	}
	SNode* saveNode = NULL;
	if (_pRoot->data == _data)
	{
		saveNode = _pRoot;
		return saveNode;
	}
	if (_data < _pRoot->data)
	{
		saveNode = Search(_pRoot->pLeft, _data);
	}
	if (_data > _pRoot->data)
	{
		saveNode = Search(_pRoot->pRight, _data);
	}
	return saveNode;
}