#include <stdio.h>
#include <limits.h>

#define BUF_MAX 10

// put, Enqueue
int Put(int* const _pQueue, int* const _pCurIdx, int _value);

// Get, Dequeue
int Get(int* const _pQueue, int* const _pCurIdx);

void PrintQueue(const int* const _pQueue, int _pCurIdx);

int main() {
	// ť Queue FIFO
	int queue[BUF_MAX] = { 0 };
	int curIdx = 0;
	
	for(int i =0; i<20; ++i)
		Put(queue, &curIdx, i*5);
	PrintQueue(queue, curIdx);
	for (int i = 0; i < 20; ++i) {
		int get = Get(queue, &curIdx);
		printf("get: %d\n\n", get);
	}	
	PrintQueue(queue, curIdx);


	// ����ť(Circular Queue)
	// put index�� get index�� ���� ����� �� ȿ����������
	// �������� �����ϸ� �װ� �� �������� ���� �� ȿ����

	return 0;
}

int Put(int* const _pQueue, int* _pCurIdx, int _value) { // �����δ� ��ȯ�� ���� ������ ���� �ڵ带 ��ȯ�ϱ� ���ؼ� int ������ ����
	if (_pQueue == NULL || _pCurIdx == NULL) {
		printf("[ERROR] Argument(����) is NULL!\n");
		return INT_MIN;
	}
	if ((*_pCurIdx) >= BUF_MAX) {
		printf("[ERROR] Queue is Full!\n");
		return INT_MIN;
	}

	*(_pQueue + (*_pCurIdx)) = _value;
	++(*_pCurIdx);
}

int Get(int* const _pQueue, int* _pCurIdx) {
	if (_pQueue == NULL || _pCurIdx == NULL) {
		printf("[ERROR] Argument(����) is NULL!\n");
		return INT_MIN;
	}
	if ((*_pCurIdx) <= 0) {
		printf("[ERROR] Queue is Empty!\n");
		return INT_MIN;
	}

	int get = *(_pQueue + 0); // + ���ص� ������ �迭 �̸��� ���� ���� ù��° ����� �ּҶ� * �ٿ��� �� �������� �ε��� 0���� ���̴�
	--(*_pCurIdx);
	for (int i = 0; i < (*_pCurIdx); ++i) {
		printf("[%d:%d] <- [%d:%d] ", i, _pQueue[i], i+1, _pQueue[i + 1]);
		*(_pQueue + i) = *(_pQueue + (i + 1));
	}printf("\n");
	return get;
}

void PrintQueue(const int* const _pQueue, int _pCurIdx) {
	if (_pQueue == NULL || _pCurIdx == NULL) {
		printf("[ERROR] Argument(����) is NULL!\n");
		return INT_MIN;
	}
	if (_pCurIdx <= 0) {
		printf("[ERROR] Queue is Empty!\n");
		return INT_MIN;
	}
	for (int i = 0; i < _pCurIdx; ++i) {
		printf("%d - ", *(_pQueue+i));
	}
	printf("(%d/%d)\n", _pCurIdx, BUF_MAX);

}