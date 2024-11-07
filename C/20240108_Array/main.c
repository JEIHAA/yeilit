#include <stdio.h>

void PrintArray(int _arr[5]);

int main() {
	// 배열(Array)
	// arr[Index]
	// arr[0] -> 1: 배열요소(Elements)
	// [5]: 배열의 길이(Length)

	// 정적배열(Static Array) 리터럴 상수로만 배열의 길이 결정
	int arr[5] = { 0 }; // 초기화 개수가 모자라도 하나만 하면 뒤에는 다 0으로 초기화 됨. 아예 안하면 반드시 쓰레기 값이 나옴. 초기화 필수
	// 배열길이를 비워둬도 1, 2, 3, 4, 5로 초기화 하면 길이 5의 배열이 자동으로 만들어짐
	// arr = {1, 2, 3, 4, 5}; 안됨 초기 한번만 가능
	//arr[2] = 100; // 배열 요소 하나하나 접근해서 값 변경해야함

	printf("arr Size: %d Byte\n", sizeof(arr)); // 정적배열만 배열의 총 크기가 나옴
	// 배열 각 요소의 주소는 연속되어 있다

	//int len = sizeof(arr) / sizeof(int);
	int len = sizeof(arr) / sizeof(arr[0]); //배열의 전체 크기를 배열의 첫번째 요소의 크기로 나눠서 배열의 길이를 구함. 정적 배열만 가능하다

	//PrintArray(arr, len);
	for (int i = 0; i < len; ++i) {
		printf("arr[%d]: %d (%p)\n", i, arr[i], &arr[i]);
	}

	// 메모리 주소연산(Memory Offset) arr[0]+1: 값 연산 &arr[0]+1: 주소 연산 arr+1: 주소 연산
	printf("arr Address: %p\n", arr + 1); // 배열의 이름은 배열 첫번째 요소의 주소와 같다
	// 주소에 1을 더하면 메모리 주소의 +1이 아니라 한칸을 이동한다, 사용되고 있는 메모리의 크기만큼(자료형 크기만큼) 이동한다 int -> 4byte씩, 
	// 배열 첫번째 요소에서 인덱스 만큼 건너뛰어서 해당 요소를 찾는다

	//arr[100] = 1000; //arr의 주소에서 100번째 건너뛴 곳에 1000을 저장
	//printf("arr[100]: %d\n", arr[100]); //arr의 주소에서 100번째 건너뛴 곳에 어떤 값이 저장되어 있는지 모름. window에서 사용하는 부분이었을 경우 컴퓨터 뻗음
	// 이제 컴파일러에서 막아줌, 옛날 버전에서는 됐었다.
	// C, C++만 주소연산이 됨 메모리에 직접 접근이 가능하니 자꾸 예상치 못한 곳에서 문제가 발생하거나 컴퓨터 뻗어버림. 게임 개발에서는 메모리 직접 접근이 필요할 때가 있음


	
	int tmpArr[3] = { 10, 20, 30 };
	PrintArray(tmpArr, 3);

	return 0;
}

void PrintArray(int _arr[5], int _len) {
	int len = sizeof(_arr) / sizeof(_arr[0]); //_arr는 메모리 주소, len은 지금 _arr의 길이를 계산한것(배열의 이름의 길이) 주소를 저장하는 주소의 길이
	// 배열이 통채로 넘어오는 것이 아니라 첫번째 주소값만 넘어오기 때문에 전체 배열의 크기를 알 수가 없다. 정적 배열을 받는게 아니다
	printf("_arr Size: %d Byte\n", sizeof(_arr));
	//_arr[2] = 100; // 지역변수인데 원본 배열의 값도 바뀜
	// PrintArray(arr)로 배열의 이름을 전달함 -> 메모리의 주소를 전달함
	// -> _arr[2]는 arr의 주소에서 2칸 이동한 것 -> 원본의 주소와 같은 위치여서 해당 위치 메모리의 값을 바꾸면 원본의 값도 바뀜
	// 배열의 크기가 얼마나 크든 배열의 첫 주소만 가지고 연산을 하기 때문에 속도와 상관이 없음
	for (int i = 0; i < len; ++i) {
		printf("_arr[%d]: %d\n", i, _arr[i]);
	}
}