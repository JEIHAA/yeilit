#include <stdio.h>
#include <stdlib.h> //일반적으로 이 헤더에는 난수를 생성하는 rand() 함수와 난수 발생기를 초기화하는 srand() 함수가 선언되어 있습니다.
#include <time.h>//현재 시간을 얻기 위한 time() 함수가 일반적으로 이 헤더에 선언되어 있습니다.
#define MAX_LEN 6
// 데이터가 겹치지않게 랜덤으로 값 채우기 / 제일 큰 값을 찾아 맨 뒤의 요소와 교체하는 방법을 반복
// TODO: 싱글 링크드 리스트로 선택정렬 구현하기
int main()
{
	// 정렬 알고리즘
	// 선택 정렬(Selection Sort)
	// Big-O Notation(빅오 표기법)
	// O(n^2)
	// 1. 제일 작은 값 찾기
	// 2. 첫 번째 자리와 값 교환
	srand(time(NULL));//현재 시간을 이용하여 매번 다른 값을 생성하여 난수 발생기를 초기화합니다.
	int arr[MAX_LEN] = { 15, 3, 7, 20, 1, 10 };// 배열 arr의크기를 맥스 랜으로해주고 멤버들을 0으로 초기화해줬다
	//for (int i = 0; i < MAX_LEN; ++i) // 최대 크기가 될 때까지 칸이 한 칸씩 이동한다
		//arr[i] = rand() % 100; // 100 이하까지의 난수가 발생한다
	for (int i = 0; i < MAX_LEN; ++i) // 최대 크기가 될 때까지 한 칸씩 이동한다 - 초기값
		printf("%d - ", arr[i]);
	printf("(%d)\n", MAX_LEN);
	for (int i = 0; i < MAX_LEN - 1; ++i) // 배열의 최대 길이 이전까지 검사하는 for문
	{
		int minIdx = i;
		// minIdx을 제일 작은 값을 담아둘 변수로 지정, 일단 i를 그 값으로 정해 둔다 (최솟값을 찾으면 그 값으로 변함)
		for (int j = i + 1; j < MAX_LEN; ++j) // j(= 이동할 값)는 i보다 한 칸 앞에 있어야 i랑 비교할 수 있어서 i + 1.
		{
			// 최솟값 찾기
			if (arr[minIdx] > arr[j]) // i가 j보다 크다면 실행
			{

				minIdx = j; // i가 있어야 할 위치에 j를 넣어 주고 if문을 탈출해서 다시 if위의 포문으로 돌아가서 검사 후 반복
				// (처음 minIdx는 3이였으나 3보다작은1이나와서 그값으로 최종저장minIdx에
				printf("minIdx: %d (%d/%d)\n",
					arr[j], i, j);
			}
		}
		for (int i = 0; i < MAX_LEN; ++i)
			printf("%d - ", arr[i]);
		printf("(%d)\n", MAX_LEN);
		printf("\n");
		// 첫 번째 자리와 값 교환
		// TODO: Swap함수 만들기
		int tmp = arr[minIdx];//위에서가져온 minIdx를  tmp 변수에 담아둠
		arr[minIdx] = arr[i]; // i 를 mixidx로 대입을 해준다
		arr[i] = tmp; //  tmp를 i로 대입해준다
		printf("%d <- %d\n", i, minIdx);
	}
	for (int i = 0; i < MAX_LEN; ++i)
		printf("%d - ", arr[i]);
	printf("(%d)\n", MAX_LEN);
	return 0;
}