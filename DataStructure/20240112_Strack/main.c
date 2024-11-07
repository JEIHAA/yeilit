#include <stdio.h>
#include <limits.h>

//Buffer �����͸� ��Ƶΰ� �����ϴ� ����
#define BUF_MAX 10

// ���Ǻ� ������(Conditional Compile)
//#define DEBUG_MODE // ���ǵǾ� �ִٸ� #ifdef DEBUG_MODE, #endif�� �ڵ�κ��� �����صθ� ��µ�, ���ǵǾ� ���� �ʴٸ� ������ �Ҷ� �ش� �κ��� ���ܵ�
// �����Ϸ� ����� Debug�� Release ����� ����
// Debug ���� ������ �� ������� ���� ������ �������, Relese�� ���ุ�� ���� ���� �����, �뷮���̰� ŭ
// Debug ��忡���� �� ���ư��� Relese������ ���� ��� ����, ���� ������ ���� Relese�� �����ؼ� �����ؾ���

//Push
// *�迭, *�ε���, ��. �ܺο��� ���ͼ� ���ο��� �����ؾ��ϴ� ��� - �ּ� ������ �ؾ� �ܺ��� ���� ���ο��� ���� �����ϴ� �����͸� �ٿ��� �ּҸ� ����
void Push(int* const _pStack, int* const _pCurIdx, int _value);

//Pop
int Pop(const int* const _pStack, int* const _pCuridx);

//stack Print
void PrintStack(const int* const _pStack, int _curIdx); // _stack�� �迭�̶� ������, _curIdx�� �׳� �ܺο��� �ޱ⸸ �ϴϱ� �׳� int

// ������ ���� á���� �˻��ϴ� �Լ�
// ������ ����ִ��� �˻��ϴ� �Լ�
// ���� ����� ������ ��ȯ�ϴ� �Լ� / ���� ũ�⵵ ����
// ���� Ŭ���� �Լ�

int main() {
	// �ڷᱸ��(Data Structures
	// ����(Stack) �������� ���� FILO
	int stack[BUF_MAX] = {0};
	// Current Index
	int curIdx = 0;	

	// stack�� �迭�̱� ������ �׳� �־��ָ� �ּҰ� �˾Ƽ� ���� curIdx�� �Ϲ� �����̱� ������ & �ٿ��� �ּ� �־��ش�
	for (int i = 0; i < 20; ++i) {
		Push(stack, &curIdx, i*5);
		/*Push(stack, &curIdx, 20);
		Push(stack, &curIdx, 12);*/
	}
	

	PrintStack(stack, curIdx);
	
	int pop = Pop(stack, &curIdx);
	printf("Pop: %d\n", pop);
	printf("Pop: %d\n", Pop(stack, &curIdx));
	PrintStack(stack, curIdx);
	return 0;
}

// ������ ����
void Push(int* const _pStack, int* const _pCurIdx, int _value) {
	if ((*_pCurIdx) >= BUF_MAX) {
		printf("[ERROR] stack Overflow!\n");
		return;
	}


	// ����ó��(Exception)
	if (*_pCurIdx < BUF_MAX) {
		// _pStack�� �迭, �迭�� ���ʿ� �ּҸ� �޾Ƽ� �ּҿ����� �ϱ� ������ *�� �ٿ��� ���� ã�� �ʿ䰡 ����
		// _pStack[*_pCurIdx] = _value;
		// ������ �ּҿ��� ���
		*(_pStack + (*_pCurIdx)) = _value;
		++(*_pCurIdx);
	}
}

// ������ ����
int Pop(const int* const _pStack, int* _pCurIdx) {
	// ����ó��
	if (_pStack == NULL || _pCurIdx == NULL) { 
		printf("[ERROR] %d Line: _pStack or _pCurIdx is NULL!\n", __LINE__);
		return INT_MIN;
	}
	if ((*_pCurIdx) <= 0) {
		printf("[ERROR] %d Line: Stack is Empty!\n", __LINE__);
		return INT_MIN; 
	}

	int pop = 0;
	if ((*_pCurIdx) > 0) {
		--(*_pCurIdx);
		//pop = _pStack[(*_pCurIdx)];
		pop = *(_pStack + (*_pCurIdx));

#ifdef DEBUG_MODE // ���࿡ DEBUG_MODE�� ���ǵǾ� �ִٸ� (_DEBUG �� ������ Debug ��忡���� Ȱ��ȭ ��)
		printf("pop: %d\n", pop); // __FILE__, __LINE__ ������ ������ �ִ� �κ��� ������� �� �� ����
#endif // ������� ����, ���ǵǾ� ���� �ʴٸ� ��Ȱ��ȭ ��
	}

	return pop;

}

// ������ ���
void PrintStack(const int* const _pStack, int _curIdx) {
	for (int i = 0; i < _curIdx; ++i) {
		//printf("%d - ", _stack[i]);
		printf("%d - ", *(_pStack + i)); //*(_pStack+i) _pStack�� �ּҿ��� i��ŭ �̵��� ���� ��
	}printf("\n");
}