#include <stdio.h>
#include <malloc.h>

//#define SAFE_FREE(p) if(p){free(p); p=NULL}

typedef struct _SNode
{
	int data;

	struct _SNode* pNext;
}SNode;

SNode* CreateNode(int _data);

void AddBack(const SNode** _pHead, int _data);

void AddBackWithNode(const SNode* const _pHead, const SNode* const _pNewNode);// AddBackWithNode(_pHead,CreateNode(10))

void AddFront(const SNode** _pHead, int _data);

void Insert(const SNode** _pHead, int _idx, int _data);

void RemoveAt(const SNode** _pHead, int _idx);

void RemoveAll(const SNode** _pHead);

//재귀함수(Recursive)
void RemoveRecursive(SNode* _pCurNode);

SNode* GetNode(const SNode** const _pHead, int _data);//getnode는 해당데이터를 가지고있는 노드를 반환

void Remove(const SNode** _pHead, SNode* _node); //여기다가 getnode를 넣으면 삭제되게

void PrintAll(const SNode* const _pHead);




int main()
{
	// 단일 연결 목록
	// Single Linked List
	// 한방향으로만 가르키고있음
	// 벡터가 가지는 단점(메모리 단편화)을 보완한 것이다 단점은 보안에 취약하다.
	// 주소 연산 오버헤드가 발생하는데 배열에서 접근하는것 보다 느리다.

	SNode* pHead = NULL;
	/*pHead = CreateNode(10, NULL);
	SNode* pNew = CreateNode(20, NULL);
	pHead->pNext = pNew;*/

	for (int i = 0; i < 5; i++)
	{
		AddBack(&pHead, i);
	}
	PrintAll(pHead);

	AddFront(&pHead, 200);

	AddFront(&pHead, 100);
	PrintAll(pHead);

	Insert(&pHead, 3, -5);
	PrintAll(pHead);

	RemoveAt(&pHead, 0);
	PrintAll(pHead);

	SNode* SaveNode= GetNode(&pHead, 2);
	Remove(&pHead, SaveNode);
	PrintAll(pHead);

	RemoveAll(&pHead);
	PrintAll(pHead);

	return 0;
}

SNode* CreateNode(int _data)//노드의 주소를 들고와야하기때문에 구조체 포인터사용 넣어야할 데이터값
{
	SNode* _pNewNode = (SNode*)malloc(sizeof(SNode)); //구조체 동적할당

	_pNewNode->data = _data;//동적할당 했을때 멤버에 접근하는 방식
	_pNewNode->pNext = NULL; // 포인터 멤버 접근지정자 ->
	//동적할당 했기때문에 메모리 구조 Heap영역에 있기때문에 이런방식을 사용한다.

	/*SNode tmp;
	tmp.data = _data;*/ //동적할당 했을때는 이런방식으로 접근할수없다. 멤버 접근지정자 .
}

void AddBack(const SNode** _pHead, int _data)
{
	if (*_pHead == NULL)//헤드 주소에 NULL값이 들어있다면
	{
		*_pHead = CreateNode(_data); //pHead에 데이터값을 넣어서 노드를 만듬
		return;
	}

	// Interator 반복자
	SNode* pCurNode = *_pHead;
	while (pCurNode->pNext != NULL)//pCur이 가르키는 값이 NULL이면 while 종료
	{
		pCurNode = pCurNode->pNext;//pCur에 다음 노드 주소값을 적용
	}

	SNode* pNewNode = CreateNode(_data);//마지막은 다음 주소로 못가니까 새로운 노드에 넣어야할 데이터를 넣어서 만들어옴
	pCurNode->pNext = pNewNode; //pCur멤버의 pNext에 새로운 만들어진 주소를 넣어줌
}
void AddBackWithNode(const SNode* _pHead, const SNode* const _pNewNode)
{
	if (_pHead == NULL)//헤드 주소에 NULL값이 들어있다면
	{
		printf("Insert : Head is NULL!\n");
		return;
	}

}

void AddFront(const SNode** _pHead, int _data)
{
	if (*_pHead == NULL)//헤드 주소에 NULL값이 들어있다면
	{
		*_pHead = CreateNode(_data); //pHead에 데이터값을 넣어서 노드를 만듬
		return;
	}

	SNode* pNewHead = CreateNode(_data);//새로운 헤드를 만들어줌

	pNewHead->pNext = *_pHead; //새로운 헤드가 가르키는 다음 주소를 기존의 헤드 주소를 넣는다.

	*_pHead = pNewHead; //*_pHead가 가지고있던 주소를 새로운 헤드주소로 바꿔줌
}

void Insert(const SNode** _pHead, int _idx, int _data)
{
	if (*_pHead == NULL)//헤드 주소에 NULL값이 들어있다면
	{
		printf("Insert : Head is NULL!\n");
		return;
	}
	if (_idx < 0) {
		printf("ERROR] Out of index!\n");
		return;
	}
	if (_idx == 0)
	{
		AddFront(_pHead, _data);
		return 0;
	}
	SNode* pCurNode = *_pHead;

	for (int i = 0; i < _idx - 1; i++) {
		pCurNode = pCurNode->pNext;
		if (pCurNode->pNext == NULL)
		{
			printf("Insert: Out of Index!\n");
			return;
		}
	}
	SNode* pNewNode = CreateNode(_data);
	pNewNode->pNext = pCurNode->pNext;
	pCurNode->pNext = pNewNode;
}

void RemoveAt(const SNode** _pHead, int _idx)
{
	if (_pHead == NULL)
	{
		return;
	}
	if (_idx < 0)
	{
		return;
	}

	if (_idx == 0)
	{
		SNode* pDelNode = *_pHead;
		*_pHead = (*_pHead)->pNext;
		if (pDelNode != NULL)
		{
			printf("pDelNode: %d\n", pDelNode->data);
			free(pDelNode);
			pDelNode = NULL;
		}
		return;
	}
	SNode* pCurNode = *_pHead;
	int i = 0;
	while (++i < _idx)
	{
		pCurNode = pCurNode->pNext;
		if (pCurNode == NULL)
		{
			return;
		}
	}
	SNode* pDelNode = pCurNode->pNext;
	pCurNode->pNext = pDelNode->pNext;
	if (pDelNode != NULL)
	{
		printf("pDelNode: %d\n", pDelNode->data);
		free(pDelNode);
		pDelNode = NULL;
	}

}

void RemoveAll(const SNode** _pHead)
{
	if (_pHead == NULL)
	{
		printf("ERROR] _pHead is NULL\n");
		return;
	}
	RemoveRecursive(*_pHead);
	*_pHead = NULL;

}

void RemoveRecursive(SNode* _pCurNode)
{
	//탈출문
	if (_pCurNode == NULL)
	{
		return;
	}
	RemoveRecursive(_pCurNode->pNext);

	printf("Del : %d\n", _pCurNode->data);
	if (_pCurNode)
	{
		free(_pCurNode);
		_pCurNode = NULL;
	}
}

SNode* GetNode(const SNode** const _pHead, int _data) {
	if (_pHead == NULL) 
	{
		return;
	}
	SNode* pCurNode = *_pHead;
	// 삭제할 노드의 이전 노드까지 이동
	while (pCurNode != NULL) 
	{
		SNode* SaveNode = pCurNode;
		if (pCurNode->data == _data) 
		{
			printf("SaveNode : %d \n",SaveNode->data);
			return SaveNode;
		}
		pCurNode = pCurNode->pNext;
	}
}

void Remove(const SNode** _pHead, SNode* _node)
{
	printf("Remove at Save : %d \n",_node->data);
	if (_pHead == NULL || _node ==NULL)
	{
		printf("ERROR] _pHead is NULL\n");
		return;
	}

	SNode* pCurNode = *_pHead;
	SNode* pDelNode = NULL;
	while (pCurNode != NULL)
	{
		if (_node == pCurNode->pNext)
		{
			pDelNode = pCurNode->pNext;
			pCurNode->pNext = pDelNode->pNext;
			printf("삭제됨\n");
			if (pDelNode != NULL)
			{
				free(pDelNode);
				pDelNode = NULL;
			}
		}
		pCurNode = pCurNode->pNext;
	}
}

void PrintAll(const SNode* const _pHead)
{
	int count = 0;
	if (_pHead == NULL) //헤드에 NULL값이 들어있다면 비어있는 것이기 때문에 Empty출력
	{
		printf("Empty!\n");
		return;
	}
	SNode* pCurNode = _pHead;
	while (pCurNode != NULL) //출력은 다음 주소 가르키는 pNext값이 Null값일때 탈출하면 마지막에 새로만들어지는 노드를 출력하지 않기 때문에 pCur의 값이 Null이면 새로운 노드를 만들고 출력하고 탈출함
	{
		printf("%d - ", pCurNode->data);
		pCurNode = pCurNode->pNext;
		count++;
	}
	printf("\ncount : %d\n", count);
}