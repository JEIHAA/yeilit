#include <stdio.h>
#include <malloc.h>

typedef struct _SNode {
	int data;
	struct _SNode* pNext;

} SNode;

SNode* CreateNode( int _data);
void AddBack(const SNode** const _pHead, int _data);
void AddBackWithNode(const SNode* const _pHead, SNode* _pNewNode); // 만들어보기
void AddFront(const SNode** _pHead, int _data);
void Insert(const SNode** _pHead, int _idx, int _data);
void PrintAll(const SNode* const _pHead);

int main() {
	// 단일 연결 목록
	// Single Linked List
	// Momory Pool
	// Head -> Node -> nextNode -> nextnextNode ... 중간에 뭘 삭제해도 그냥 바로 그 다음 노드를 가리키면 됨
	// malloc이나 new 연산자 같은 기능들은 다양한 블록사이즈 때문에 단편화를 유발시키고, 파편화된 메모리들은 퍼포먼스 때문에 실시간 시스템에서 사용할 수 없게 된다.
	// 좀 더 효율적인 방법은 memory pool이라고 불리는 동일한 사이즈의 메모리 블록들을 미리 할당해 놓는 것이다.
	// 그러면 응용 프로그램들은 실행 시간에 핸들에 의해서 표현되는 블록들을 할당하고, 접근하고, 해제할 수 있다. - 위키백과

	//SNode* node = (SNode*)malloc(sizeof(SNode));
	//node->data = 10;
	//node->pNext = NULL; // 포인터 멤버 접근 지정자 Heap

	//SNode tmp;
	//tmp.data = 10; // 멤버 접근 지정자 Stack

	//SNode* pHead = NULL;
	//pHead = CreateNode(10, NULL);
	//
	//SNode* pNew = CreateNode(20, NULL);
	//pHead->pNext = pNew; // pHead가 가리킬 다음 노드(pNext) = pNew

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

SNode* CreateNode(int _data) { // 동적 할당 후 만든 애들 초기화 해주는 함수
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

	// Iterator 반복자
	SNode* pCurNode = *_pHead;
	while (pCurNode->pNext != NULL) {
		pCurNode = pCurNode->pNext;
	}
	SNode* pNewNode = CreateNode(_data);
	pCurNode->pNext = pNewNode;
}

void AddBackWithNode(const SNode* const _pHead, const SNode* const _pNewNode) {
	// 만들어보기
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