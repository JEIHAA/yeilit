#include <stdio.h>
#include <limits.h>

#define BUF_MAX 10

// put, Enqueue
int Put(int* const _pQueue, int* const _pCurIdx, int _value);

// Get, Dequeue
int Get(int* const _pQueue, int* const _pCurIdx);

void PrintQueue(const int* const _pQueue, int _pCurIdx);

int main() {
	// 큐 Queue FIFO
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


	// 원형큐(Circular Queue)
	// put index와 get index를 따로 만들면 더 효율적이지만
	// 원형으로 관리하면 그게 더 안정성이 높고 더 효율적

	return 0;
}

int Put(int* const _pQueue, int* _pCurIdx, int _value) { // 실제로는 반환할 값이 없지만 에러 코드를 반환하기 위해서 int 형으로 만듦
	if (_pQueue == NULL || _pCurIdx == NULL) {
		printf("[ERROR] Argument(인자) is NULL!\n");
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
		printf("[ERROR] Argument(인자) is NULL!\n");
		return INT_MIN;
	}
	if ((*_pCurIdx) <= 0) {
		printf("[ERROR] Queue is Empty!\n");
		return INT_MIN;
	}

	int get = *(_pQueue + 0); // + 안해도 어차피 배열 이름이 가진 값은 첫번째 요소의 주소라서 * 붙여서 값 가져오면 인덱스 0번의 값이다
	--(*_pCurIdx);
	for (int i = 0; i < (*_pCurIdx); ++i) {
		printf("[%d:%d] <- [%d:%d] ", i, _pQueue[i], i+1, _pQueue[i + 1]);
		*(_pQueue + i) = *(_pQueue + (i + 1));
	}printf("\n");
	return get;
}

void PrintQueue(const int* const _pQueue, int _pCurIdx) {
	if (_pQueue == NULL || _pCurIdx == NULL) {
		printf("[ERROR] Argument(인자) is NULL!\n");
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