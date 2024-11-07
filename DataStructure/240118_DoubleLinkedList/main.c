#include <stdio.h>
#include <stdlib.h>

#define SAFE_FREE(p) if(p){ free(p); p = NULL; }

// ��� ����ü ����
typedef struct _SNode
{
    int _data;               // ����� ������
    struct _SNode* pPrev;    // ���� ��带 ����Ű�� ������
    struct _SNode* pNext;    // ���� ��带 ����Ű�� ������
} SNode;

// ��� ���� �Լ�
SNode* CreateNode(const int _data);

// ����Ʈ�� �� �տ� ��� �߰� �Լ�
void AddFront(SNode* const _pHead, int _data);

// ����Ʈ�� �� �ڿ� ��� �߰� �Լ�
void AddBack(SNode* const _pTail, int _data);

//Ư�� ��ġ�� ��� ����
void Insert(SNode* const _pHead, int _idx, int _data);

// Ư����� �����ϱ�
void RemoveAt(SNode* const _pHead, int _idx);

// ��� ���� ����
void RemoveAll(SNode* const _pHead, SNode* const _pTail);

// ����Ʈ ��ü ��� �Լ�
void PrintAll(const SNode* const _pHead, const SNode* const _pTail);

// ���� ��ũ�� ����Ʈ�� ��� ��带 �������� ����ϴ� �Լ�
void PrintAllReverse(const SNode* const _pHead, const SNode* const _pTail);

int main()
{
    // ����� ���� ��� / ���� ��ũ�� ����Ʈ
    // Double Linked List
    SNode head = { 0 };     // ��� ��� �ʱ�ȭ
    SNode tail = { 0 };     // ���� ��� �ʱ�ȭ

    // ����� ���� ���� tail �ּҸ� ����Ű���� ����
    head.pNext = &tail;
    // tail�� ���� ���� head �ּҸ� ����Ű���� ����
    tail.pPrev = &head;

    // ����Ʈ �� �տ� ��� �߰�
    printf("\nAddFront\n");
    for (int i = 0; i < 5; i++)
    {
        AddFront(&head, i * 10);
    }
    PrintAll(&head, &tail);

    // ����Ʈ �� �ڿ� ��� �߰�
    printf("\nAddBack\n");
    AddBack(&tail, 100);
    PrintAll(&head, &tail);

    // ����Ʈ �� �ڿ� ���� ��� �߰�
    printf("\nAddBack\n");
    for (int i = 0; i < 5; i++)
    {
        AddBack(&tail, (i +1) * 100);
    }
    PrintAll(&head, &tail);

    //���� �� �߰�
    printf("\nInsert at Index 12 (2000)\n");
    Insert(&head, 12, 500);
    printf("-------------\n");
    PrintAll(&head, &tail);

    //���� �� �߰�
    printf("\nInsert at Index 5 (2000)\n");
    Insert(&head, 5, 2000);
    printf("-------------\n");
    PrintAll(&head, &tail);

    //Ư�� �ε��� ��� ����
    printf("\nRemove at Index 5 (2000)\n");
    RemoveAt(&head, 5);
    PrintAll(&head, &tail);

    //�������� ���
    printf("\nReverse\n");
    PrintAllReverse(&head ,&tail);

 
    //��� ���� ����
    RemoveAll(&head, &tail);
    PrintAllReverse(&head, &tail);

    // �޸� ����
    return 0;
}

// �����͸� ���� ���ο� ��� ���� �Լ�
SNode* CreateNode(const int _data)
{
    SNode* pNewNode = (SNode*)malloc(sizeof(SNode));
    if (pNewNode)
    {
        pNewNode->_data = _data;
        pNewNode->pPrev = NULL;
        pNewNode->pNext = NULL;
    }
    return pNewNode;
}

// ����Ʈ �� �տ� ��� �߰� �Լ�
void AddFront(SNode* const _pHead, int _data)
{
    if (!_pHead)
    {
        printf("ERROR] _pHead is NULL!\n");
        return;
    }

    // ���ο� ��� ����
    SNode* pNewNode = CreateNode(_data);

    // ������ �����Ͽ� ��� �߰�
    pNewNode->pNext = _pHead->pNext;
    pNewNode->pPrev = _pHead;
    _pHead->pNext = pNewNode;
    pNewNode->pNext->pPrev = pNewNode;
}

// ����Ʈ �� �ڿ� ��� �߰� �Լ�
void AddBack(SNode* const _pTail, int _data)
{
    if (!_pTail)
    {
        printf("ERROR] Parameter is NULL\n");
        return;
    }

    // ���ο� ��� ����
    SNode* pNewNode = CreateNode(_data);

    // ������ �����Ͽ� ��� �߰�
    pNewNode->pPrev = _pTail->pPrev;
    pNewNode->pNext = _pTail;
    _pTail->pPrev->pNext = pNewNode;
    _pTail->pPrev = pNewNode;
}

void Insert(SNode* const _pHead, int _idx, int _data)
{
    if (!_pHead)
    {
        printf("ERROR] Parameter is NULL!\n");
        return;
    }
    if (_idx < 0)
    {
        printf("ERROR] Parameter is LOW!\n");
        return;
    }
    SNode* pCurNode = _pHead;
    int idx = 0;
    SNode* pNewNode = CreateNode(_data);

    while (pCurNode->pNext != NULL )
    {
        if (idx == _idx)
        {
            break;
        }
        idx++;
        pCurNode = pCurNode->pNext;
    }

    if (!pCurNode->pNext)//pCur�� �������� Null�̸� pCur�� Tail�̶�� ���̴ϱ� ���� ���� ��尡 ���⶧���� �־������ Index���� ����Ʈ���� ����� ������ �Լ����� Ż��
    {
        printf("Ourt of Index!\n");
        return;
    }

    pNewNode->pNext = pCurNode->pNext;
    pNewNode->pPrev = pCurNode;
    pCurNode->pNext = pNewNode;
    pNewNode->pNext->pPrev = pNewNode;
}

// Ư����� �����ϱ�
void RemoveAt(SNode* const _pHead, int _idx)
{
    if (!_pHead || _idx < 0)
    {
        printf("ERROR] Parameter is NULL or LOW!\n");
        return;
    }
    if (!_pHead->pNext->pNext)
    {
        printf("Empty!");
        return;
    }

    SNode* pCurNode = _pHead->pNext;
    int idx = 0;

    while (pCurNode->pNext)
    {
        if (idx == _idx) break;
        pCurNode = pCurNode->pNext;
        idx++;
    }
    if (!pCurNode->pNext)
    {
        printf("Out of Indext!\n");
        return;
    }
    SNode* pPrevNode = pCurNode->pPrev;
    SNode* pNextNode = pCurNode->pNext;

    pPrevNode->pNext = pNextNode;
    pNextNode->pPrev = pPrevNode;

    printf("%d\n",pCurNode->_data);
    SAFE_FREE(pCurNode);
}

// ��� ���� ����
void RemoveAll(SNode* const _pHead, SNode* const _pTail)
{
    if (!_pHead || !_pTail)
    {
        printf("ERROR] Parameter is NULL!\n");
        return;
    }
    SNode* pCurNode = _pHead->pNext;
    if (pCurNode == _pTail)
    {
        printf("Empty\n");
        return;
    }
    

    while (pCurNode != _pTail)
    {
        SNode* pNextNode = pCurNode->pNext;//�տ� ��带 ���������� ���� ��带 ����Ű�� ��尡 ������⶧���� ���� ���� ����Ű�� ���� �������
        printf("DEL : %d \n",pCurNode->_data);
        SAFE_FREE(pCurNode);
        pCurNode = pNextNode;
    }
    _pHead->pNext = _pTail;
    _pTail->pPrev = _pHead;
}

// ����Ʈ ��ü ��� �Լ�
void PrintAll(const SNode* const _pHead, const SNode* const _pTail)
{
    if (!_pHead || !_pTail)
    {
        printf("ERROR] Parameter is NULL\n");
        return;
    }
    if (_pHead->pNext == _pTail)
    {
        printf("EMPTY\n");
        return;
    }
    int cnt = 0;
    SNode* pCurNode = _pHead->pNext;

    while (pCurNode != _pTail)
    {
        printf("%d - ", pCurNode->_data);
        pCurNode = pCurNode->pNext;
        cnt++;
    }

    printf("\ncount : %d\n", cnt);
}

// ����Ʈ ���� ���
void PrintAllReverse(const SNode* const _pHead, const SNode* const _pTail)
{
    if (!_pHead || !_pTail)
    {
        printf("ERROR] Parameter is NULL\n");
        return;
    }
    if (_pHead->pNext == _pTail)
    {
        printf("EMPTY\n");
        return;
    }

    int cnt = 0;
    SNode* pCurNode = _pTail->pPrev;

    while(pCurNode != _pHead)
    {
        printf("%d - ", pCurNode->_data);
        pCurNode = pCurNode->pPrev;
        cnt++;    
    }
    printf("\ncount : %d\n", cnt);
}