#include<stdio.h>
#include<stdlib.h>
#include<time.h>
#define MAX_LEN 10
void PrintArray(const int* const _pArr, int _len)
{
	for (int i = 0; i < _len; ++i)
		printf("%d - ", _pArr[i]);
	printf("(%d)\n", _len);
}
// TODO: 싱글 링크드 리스트를 활용해 삽입정렬!
int main()
{
	//삽입 정렬(Insertion Sort)
	//O(n^2)
	int arr[MAX_LEN] = { 0 }; // 배열에 난수 배당
	srand(time(NULL));
	for (int i = 0; i < MAX_LEN - 1; ++i)
		arr[i] = rand() % 10;
	PrintArray(arr, MAX_LEN);
	//Pseudo Code(의사 코드)

	//1. 키값 선정
	//1-1 for(key 1 부터 시작하고 MAX까지)
	for (int key = 1; key < MAX_LEN; ++key) // key값은 옮겨질 값이다. key이 1부터 시작해서 배열의 최대 길이 전까지  증가
	{// 2. 키값 왼쪽을 순회 (키값보다 큰값을찾으면 그왼쪽에놓음)
		int keyVal = arr[key]; // key 값이 변화가 되지 않기 위해 keyVal값으로 저장
		int i = key - 1; // key 값의 전을 i 로 대입
		for (; i >= 0; --i) // i가 0보다 크거나 같아질때까지 선감소
		{//3.값 옮기기
			if (keyVal < arr[i]) // 만약 i의 배열이 키밸류보다 클때 반복
			{
				printf("%d: %d -> %d\n", key, i, i + 1);  // i의 배열이 i+1한큼 이동한 것을 출력함
				arr[i + 1] = arr[i]; // i의 + 1 한 만큼의 자리에 i를넣음

			}
			//3-1. 탈출조건
			else
			{
				break; //if 조건이 아닐때 엘스로 탈출함
			}
		}
		// 4. 삽입
		printf("Insert: %d (%d)\n", i + 1, keyVal);
		arr[i] = keyVal; // i + 1의 자리에 키 밸류(keyVal)를 대입함

		PrintArray(arr, MAX_LEN);
	}
}
