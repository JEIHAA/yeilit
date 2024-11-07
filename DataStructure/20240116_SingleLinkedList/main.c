#include <stdio.h>
#include <malloc.h>

typedef struct _SNode {
	int data;
	struct _SNode* pNext;

} SNode;

SNode* CreateNode( int _data);
void AddBack(const SNode** const _pHead, int _data);
void AddBackWithNode(const SNode* const _pHead, SNode* _pNewNode); // ������
void AddFront(const SNode** _pHead, int _data);
void Insert(const SNode** _pHead, int _idx, int _data);
void PrintAll(const SNode* const _pHead);

int main() {
	// ���� ���� ���
	// Single Linked List
	// Momory Pool
	// Head -> Node -> nextNode -> nextnextNode ... �߰��� �� �����ص� �׳� �ٷ� �� ���� ��带 ����Ű�� ��
	// malloc�̳� new ������ ���� ��ɵ��� �پ��� ��ϻ����� ������ ����ȭ�� ���߽�Ű��, ����ȭ�� �޸𸮵��� �����ս� ������ �ǽð� �ý��ۿ��� ����� �� ���� �ȴ�.
	// �� �� ȿ������ ����� memory pool�̶�� �Ҹ��� ������ �������� �޸� ��ϵ��� �̸� �Ҵ��� ���� ���̴�.
	// �׷��� ���� ���α׷����� ���� �ð��� �ڵ鿡 ���ؼ� ǥ���Ǵ� ��ϵ��� �Ҵ��ϰ�, �����ϰ�, ������ �� �ִ�. - ��Ű���

	//SNode* node = (SNode*)malloc(sizeof(SNode));
	//node->data = 10;
	//node->pNext = NULL; // ������ ��� ���� ������ Heap

	//SNode tmp;
	//tmp.data = 10; // ��� ���� ������ Stack

	//SNode* pHead = NULL;
	//pHead = CreateNode(10, NULL);
	//
	//SNode* pNew = CreateNode(20, NULL);
	//pHead->pNext = pNew; // pHead�� ����ų ���� ���(pNext) = pNew

	SNode* pHead = NULL;

	for (int i = 0; i < 5; ++i) {
		AddBack(&pHead, i);
	}

	PrintAll(pHead);

	AddFront(&pHead, 100);
	AddFront(&pHead, 200);
	PrintAll(pHead);

	Insert(&pHead, 3, -5);
	PrintAll(pHead);

	return 0;
}

SNode* CreateNode(int _data) { // ���� �Ҵ� �� ���� �ֵ� �ʱ�ȭ ���ִ� �Լ�
	SNode* pNewNode = (SNode*)malloc(sizeof(SNode));
	pNewNode->data = _data;
	pNewNode->pNext = NULL;

	return pNewNode;
}

void AddBack(const SNode** _pHead, int _data) {
	if (*_pHead == NULL){
		*_pHead = CreateNode(_data);
		return;
	}

	// Iterator �ݺ���
	SNode* pCurNode = *_pHead;
	while (pCurNode->pNext != NULL) {
		pCurNode = pCurNode->pNext;
	}
	SNode* pNewNode = CreateNode(_data);
	pCurNode->pNext = pNewNode;
}

void AddBackWithNode(const SNode* const _pHead, const SNode* const _pNewNode) {
	// ������
}

void AddFront(const SNode** _pHead, int _data) {
	if (*_pHead == NULL) {
		*_pHead = CreateNode(_data);
		return 0;
	}

	SNode* pNewNode = CreateNode(_data);
	pNewNode->pNext = *_pHead;
	*_pHead = pNewNode;

}

void Insert(const SNode** _pHead, int _idx, int _data) {
	if (*_pHead == NULL) {
		printf("ERROR] Insert: pHead is NULL\n");
		//*_pHead = CreateNode(_data);
		return;
	}
	if (_idx < 0) {
		printf("ERROR] Insert: Out of Index\n");
		return;
	}

	SNode* pCurNode = *_pHead;

	for (int i = 0; i < _idx-1; ++i) {
		if (pCurNode->pNext ==NULL) {

		}
		pCurNode = pCurNode->pNext;
	}

	if (_idx == 0) {
		AddFront(_pHead, _data);
		return;
	}
	SNode* pNewNode = CreateNode(_data);
	pNewNode->pNext = pCurNode->pNext;
	pCurNode->pNext = pNewNode;
	

}

void PrintAll(const SNode* const _pHead) {
	if (_pHead == NULL) {
		printf("Empty!\n");
		return;
	}

	SNode* pCurNode = _pHead;
	int cnt = 0;

	while (pCurNode != NULL) {
		printf("%d - ", pCurNode->data);
		pCurNode = pCurNode->pNext;
		++cnt;
	}
	printf("(%d)\n", cnt);
	return;
}