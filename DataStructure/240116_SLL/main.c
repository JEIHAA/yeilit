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

//����Լ�(Recursive)
void RemoveRecursive(SNode* _pCurNode);

SNode* GetNode(const SNode** const _pHead, int _data);//getnode�� �ش絥���͸� �������ִ� ��带 ��ȯ

void Remove(const SNode** _pHead, SNode* _node); //����ٰ� getnode�� ������ �����ǰ�

void PrintAll(const SNode* const _pHead);




int main()
{
	// ���� ���� ���
	// Single Linked List
	// �ѹ������θ� ����Ű������
	// ���Ͱ� ������ ����(�޸� ����ȭ)�� ������ ���̴� ������ ���ȿ� ����ϴ�.
	// �ּ� ���� ������尡 �߻��ϴµ� �迭���� �����ϴ°� ���� ������.

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

SNode* CreateNode(int _data)//����� �ּҸ� ���;��ϱ⶧���� ����ü �����ͻ�� �־���� �����Ͱ�
{
	SNode* _pNewNode = (SNode*)malloc(sizeof(SNode)); //����ü �����Ҵ�

	_pNewNode->data = _data;//�����Ҵ� ������ ����� �����ϴ� ���
	_pNewNode->pNext = NULL; // ������ ��� ���������� ->
	//�����Ҵ� �߱⶧���� �޸� ���� Heap������ �ֱ⶧���� �̷������ ����Ѵ�.

	/*SNode tmp;
	tmp.data = _data;*/ //�����Ҵ� �������� �̷�������� �����Ҽ�����. ��� ���������� .
}

void AddBack(const SNode** _pHead, int _data)
{
	if (*_pHead == NULL)//��� �ּҿ� NULL���� ����ִٸ�
	{
		*_pHead = CreateNode(_data); //pHead�� �����Ͱ��� �־ ��带 ����
		return;
	}

	// Interator �ݺ���
	SNode* pCurNode = *_pHead;
	while (pCurNode->pNext != NULL)//pCur�� ����Ű�� ���� NULL�̸� while ����
	{
		pCurNode = pCurNode->pNext;//pCur�� ���� ��� �ּҰ��� ����
	}

	SNode* pNewNode = CreateNode(_data);//�������� ���� �ּҷ� �����ϱ� ���ο� ��忡 �־���� �����͸� �־ ������
	pCurNode->pNext = pNewNode; //pCur����� pNext�� ���ο� ������� �ּҸ� �־���
}
void AddBackWithNode(const SNode* _pHead, const SNode* const _pNewNode)
{
	if (_pHead == NULL)//��� �ּҿ� NULL���� ����ִٸ�
	{
		printf("Insert : Head is NULL!\n");
		return;
	}

}

void AddFront(const SNode** _pHead, int _data)
{
	if (*_pHead == NULL)//��� �ּҿ� NULL���� ����ִٸ�
	{
		*_pHead = CreateNode(_data); //pHead�� �����Ͱ��� �־ ��带 ����
		return;
	}

	SNode* pNewHead = CreateNode(_data);//���ο� ��带 �������

	pNewHead->pNext = *_pHead; //���ο� ��尡 ����Ű�� ���� �ּҸ� ������ ��� �ּҸ� �ִ´�.

	*_pHead = pNewHead; //*_pHead�� �������ִ� �ּҸ� ���ο� ����ּҷ� �ٲ���
}

void Insert(const SNode** _pHead, int _idx, int _data)
{
	if (*_pHead == NULL)//��� �ּҿ� NULL���� ����ִٸ�
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
	//Ż�⹮
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
	// ������ ����� ���� ������ �̵�
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
			printf("������\n");
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
	if (_pHead == NULL) //��忡 NULL���� ����ִٸ� ����ִ� ���̱� ������ Empty���
	{
		printf("Empty!\n");
		return;
	}
	SNode* pCurNode = _pHead;
	while (pCurNode != NULL) //����� ���� �ּ� ����Ű�� pNext���� Null���϶� Ż���ϸ� �������� ���θ�������� ��带 ������� �ʱ� ������ pCur�� ���� Null�̸� ���ο� ��带 ����� ����ϰ� Ż����
	{
		printf("%d - ", pCurNode->data);
		pCurNode = pCurNode->pNext;
		count++;
	}
	printf("\ncount : %d\n", count);
}