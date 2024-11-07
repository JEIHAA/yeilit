#include <stdio.h>
#include <stdlib.h>

#define SAFE_FREE(p) if(p){ free(p); p = NULL; }

// 노드 구조체 정의
typedef struct _SNode
{
    int _data;               // 노드의 데이터
    struct _SNode* pPrev;    // 이전 노드를 가리키는 포인터
    struct _SNode* pNext;    // 다음 노드를 가리키는 포인터
} SNode;

// 노드 생성 함수
SNode* CreateNode(const int _data);

// 리스트의 맨 앞에 노드 추가 함수
void AddFront(SNode* const _pHead, int _data);

// 리스트의 맨 뒤에 노드 추가 함수
void AddBack(SNode* const _pTail, int _data);

//특정 위치에 노드 삽입
void Insert(SNode* const _pHead, int _idx, int _data);

// 특정노드 삭제하기
void RemoveAt(SNode* const _pHead, int _idx);

// 노드 전부 삭제
void RemoveAll(SNode* const _pHead, SNode* const _pTail);

// 리스트 전체 출력 함수
void PrintAll(const SNode* const _pHead, const SNode* const _pTail);

// 더블 링크드 리스트의 모든 노드를 역순으로 출력하는 함수
void PrintAllReverse(const SNode* const _pHead, const SNode* const _pTail);

int main()
{
    // 양방향 연결 목록 / 더블 링크드 리스트
    // Double Linked List
    SNode head = { 0 };     // 헤드 노드 초기화
    SNode tail = { 0 };     // 테일 노드 초기화

    // 헤드의 다음 노드는 tail 주소를 가리키도록 설정
    head.pNext = &tail;
    // tail의 이전 노드는 head 주소를 가리키도록 설정
    tail.pPrev = &head;

    // 리스트 맨 앞에 노드 추가
    printf("\nAddFront\n");
    for (int i = 0; i < 5; i++)
    {
        AddFront(&head, i * 10);
    }
    PrintAll(&head, &tail);

    // 리스트 맨 뒤에 노드 추가
    printf("\nAddBack\n");
    AddBack(&tail, 100);
    PrintAll(&head, &tail);

    // 리스트 맨 뒤에 여러 노드 추가
    printf("\nAddBack\n");
    for (int i = 0; i < 5; i++)
    {
        AddBack(&tail, (i +1) * 100);
    }
    PrintAll(&head, &tail);

    //사이 값 추가
    printf("\nInsert at Index 12 (2000)\n");
    Insert(&head, 12, 500);
    printf("-------------\n");
    PrintAll(&head, &tail);

    //사이 값 추가
    printf("\nInsert at Index 5 (2000)\n");
    Insert(&head, 5, 2000);
    printf("-------------\n");
    PrintAll(&head, &tail);

    //특정 인덱스 노드 삭제
    printf("\nRemove at Index 5 (2000)\n");
    RemoveAt(&head, 5);
    PrintAll(&head, &tail);

    //역순으로 출력
    printf("\nReverse\n");
    PrintAllReverse(&head ,&tail);

 
    //노드 전부 삭제
    RemoveAll(&head, &tail);
    PrintAllReverse(&head, &tail);

    // 메모리 해제
    return 0;
}

// 데이터를 갖는 새로운 노드 생성 함수
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

// 리스트 맨 앞에 노드 추가 함수
void AddFront(SNode* const _pHead, int _data)
{
    if (!_pHead)
    {
        printf("ERROR] _pHead is NULL!\n");
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

// 리스트 맨 뒤에 노드 추가 함수
void AddBack(SNode* const _pTail, int _data)
{
    if (!_pTail)
    {
        printf("ERROR] Parameter is NULL\n");
        return;
    }

    // 새로운 노드 생성
    SNode* pNewNode = CreateNode(_data);

    // 포인터 조정하여 노드 추가
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

    if (!pCurNode->pNext)//pCur의 다음값이 Null이면 pCur은 Tail이라는 뜻이니까 다음 넣을 노드가 없기때문에 넣어줘야할 Index값이 리스트에서 벗어났기 때문에 함수에서 탈출
    {
        printf("Ourt of Index!\n");
        return;
    }

    pNewNode->pNext = pCurNode->pNext;
    pNewNode->pPrev = pCurNode;
    pCurNode->pNext = pNewNode;
    pNewNode->pNext->pPrev = pNewNode;
}

// 특정노드 삭제하기
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

// 노드 전부 삭제
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
        SNode* pNextNode = pCurNode->pNext;//앞에 노드를 지워버리면 다음 노드를 가르키는 노드가 사라지기때문에 다음 것을 가르키는 것을 만들어줌
        printf("DEL : %d \n",pCurNode->_data);
        SAFE_FREE(pCurNode);
        pCurNode = pNextNode;
    }
    _pHead->pNext = _pTail;
    _pTail->pPrev = _pHead;
}

// 리스트 전체 출력 함수
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

// 리스트 역순 출력
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