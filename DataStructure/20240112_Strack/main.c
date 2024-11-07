#include <stdio.h>
#include <limits.h>

//Buffer 데이터를 모아두고 관리하는 공간
#define BUF_MAX 10

// 조건부 컴파일(Conditional Compile)
//#define DEBUG_MODE // 정의되어 있다면 #ifdef DEBUG_MODE, #endif로 코드부분을 지정해두면 출력됨, 정의되어 있지 않다면 컴파일 할때 해당 부분은 제외됨
// 컴파일러 상단의 Debug과 Release 모드의 차이
// Debug 모드는 빌드할 때 디버깅을 위한 정보도 들어있음, Relese는 실행만을 위한 정봔 빌드됨, 용량차이가 큼
// Debug 모드에서는 잘 돌아가도 Relese에서는 뻗는 경우 있음, 포폴 제출할 때는 Relese로 빌드해서 제출해야함

//Push
// *배열, *인덱스, 값. 외부에서 들어와서 내부에서 변경해야하는 경우 - 주소 연산을 해야 외부의 값을 내부에서 변경 가능하니 포인터를 붙여서 주소를 받음
void Push(int* const _pStack, int* const _pCurIdx, int _value);

//Pop
int Pop(const int* const _pStack, int* const _pCuridx);

//stack Print
void PrintStack(const int* const _pStack, int _curIdx); // _stack은 배열이라 포인터, _curIdx는 그냥 외부에서 받기만 하니까 그냥 int

// 스택이 가득 찼는지 검사하는 함수
// 스택이 비어있는지 검사하는 함수
// 스택 요소의 갯수를 반환하는 함수 / 버퍼 크기도 같이
// 스택 클리어 함수

int main() {
	// 자료구조(Data Structures
	// 스택(Stack) 지역변수 저장 FILO
	int stack[BUF_MAX] = {0};
	// Current Index
	int curIdx = 0;	

	// stack은 배열이기 때문에 그냥 넣어주면 주소가 알아서 들어가고 curIdx는 일반 변수이기 때문에 & 붙여서 주소 넣어준다
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

// 데이터 삽입
void Push(int* const _pStack, int* const _pCurIdx, int _value) {
	if ((*_pCurIdx) >= BUF_MAX) {
		printf("[ERROR] stack Overflow!\n");
		return;
	}


	// 예외처리(Exception)
	if (*_pCurIdx < BUF_MAX) {
		// _pStack은 배열, 배열은 애초에 주소를 받아서 주소연산을 하기 때문에 *를 붙여서 값을 찾을 필요가 없다
		// _pStack[*_pCurIdx] = _value;
		// 포인터 주소연산 방식
		*(_pStack + (*_pCurIdx)) = _value;
		++(*_pCurIdx);
	}
}

// 데이터 추출
int Pop(const int* const _pStack, int* _pCurIdx) {
	// 예외처리
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

#ifdef DEBUG_MODE // 만약에 DEBUG_MODE가 정의되어 있다면 (_DEBUG 로 적으면 Debug 모드에서만 활성화 됨)
		printf("pop: %d\n", pop); // __FILE__, __LINE__ 등으로 문제가 있는 부분이 어디인지 볼 수 있음
#endif // 여기까지 실행, 정의되어 있지 않다면 비활성화 됨
	}

	return pop;

}

// 데이터 출력
void PrintStack(const int* const _pStack, int _curIdx) {
	for (int i = 0; i < _curIdx; ++i) {
		//printf("%d - ", _stack[i]);
		printf("%d - ", *(_pStack + i)); //*(_pStack+i) _pStack의 주소에서 i만큼 이동한 곳의 값
	}printf("\n");
}