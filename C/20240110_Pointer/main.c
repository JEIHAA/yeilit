#include <stdio.h>
#include <malloc.h>

int main() {
	// 포인터(Pointer)
	int val = 10;
	int* pVal = &val;
	printf("val: %d (%p)\n", val, &val);
	printf("pVal: %d (%p)\n", *pVal, pVal); // *pVal 주소 안의 값 pVal 원래 값 (주소)(포인터 변수니까 주소가 저장되어 있음)

	printf("int* Size: %d Byte\n", sizeof(int*));
	printf("double* Size: %d Byte\n", sizeof(double*));

	float* pFloat = &val;
	printf("pFloat: %f (%p)\n", *pFloat, pFloat); //포인터가 가리키는 값의 타입과 포인터의 타입이 다르면 제대로 읽어올 수 없다.
	*pVal = 200; // val, pVal, pFloat 전부 200으로 바뀜. 주소가 같으니까, 다 원본에 연결되어 있으니까

	/// * asterisk

	// 동적할당(Dynamic Memory Allocate)
	
	// Strack Overflow: stack에서 지역변수를 저장하는데 지역변수들의 메모리 양이 stack의 용량을 넘어서면 터진다
	// 동적할당하면 Heap에 저장됨, 사용자가 메모리를 직접 관리함
	int* ptr = (int*)malloc(sizeof(int)); //m alloc : Memory Allocate malloc(원하는, 필요한 byte 크기);
	// void malloc(); void*형으로 return한다.
	// void형 -> 읽는 방법이 없어서 기본 자료형으로 사용할 수 없음, void val; 불가능.
	// void도 주소가 있긴 해야하니까 void*가 존재하는데 읽을 수 없기 때문에 (int*)malloc(); 처럼 읽을 방식으로 형 변환을 해줘야함
	// size_t/ _t : typeDef, f12 누르면 정의되어있는 거 볼 수 있음

	if(ptr != NULL)
		*ptr = 10;

	float* pArr = (float*)malloc(sizeof(float) * 5);
	/* (float*)malloc(sizeof(float) * 500)만큼의 메모리를 사용하려면 배열의 경우 연속된 메모리 공간이 있어야하는데 메모리를 쓰다보면 남은 공간에 구멍있어서 적중실패됨
		{
		  float* pArr = (float*)malloc(sizeof(float)*5)
		}
		이런 지역이 있을 때 영역{}을 벗어나면 stack에 저장된 float* 형 변수 pArr(8byte)는 사라지지만
		Heap에 할당된 (float*)malloc(sizeof(float)*5) 만큼의 메모리는 사라지지 않는다.(비워지지 않는다) -> 메모리 누수(Leak)
		(float*)malloc(sizeof(float)*5)만큼의 공간의 주소는 float* 형 변수 pArr에 저장되어 있는데 pArr가 이미 사라짐 -> (float*)malloc(sizeof(float)*5)만큼의 공간은 인식할 수 없어짐. 미아됨
		만약 반복문이었다면 반복한 수 만큼의 (float*)malloc(sizeof(float)*5)크기의 공간이 미아가 됨 ㄷㄷㄷㄷ
		헉! '그 버스게임' 오래 켜두면 컴퓨터가 뒤지는 이유! 게임 실행하는 동안 메모리가 어디서 계속 새고 있음ㄷㄷㄷ
		pArr = &val; 도 마찬가지
		(float*)malloc(sizeof(float)*5)의 주소는 pArr가 가지고 있었는데
		유일하게 주소를 알던 pArr가 &val의 주소를 가지게 되면서 (float*)malloc(sizeof(float)*5)의 공간은 또 다시 줄줄 새면서 미아가 됨
		그래서 */

	free(pArr);

	/* free()로 할당된 메모리를 해방해준다.(잠궈준다)
	   그런데 */

	//free(pArr);

	/* free()를 두번 써버리면, (같은 친구를 두번 해방시켜주면) 프로그램이 또 뻗어버린다.
	   free(pArr)를 하면 할당되었던 (float*)malloc(sizeof(float)*5)크기의 메모리는 반환되는 것이 맞지만,
	   pArr에는 아직 (float*)malloc(sizeof(float)*5)의 주소가 저장되어 있다.
	   (float*)malloc(sizeof(float)*5)의 주소는 이미 다른 곳에서 사용되고 있을 수도 있고 뭐가 들어있을지 모르는데 다시 또 해제를 해버리면
	   빈집이라 이사온 새 가족들이 갑자기 집을 빼앗겨버린다..*/

	pArr = NULL;
	// pArr = NULL;로 저장하고 있던 주소도 날려주자.
	 
	// 이걸 한번에 하는 국룰 숙어 코드!
	if (pArr != NULL) {
		free(pArr);
		pArr = NULL;
	}
	
	// 포인터 참조(Pointer Reference)

	//float* pArr2 = pArr;

	/* 함수에 pArr를 전달받아 사용하는 경우 float* pArr2 = pArr;와 같이 포인터를 복사하는 것과 같음
	   pArr2와 pArr는 같은 주소를 가지고 있는데 둘 중 하나라도 사용중인 공간을 해제(반환)하거나 해제된 주소를 쓰려고 하면 뻗어버림
	   참조 카운터: 포인터에 카운터를 만들고 포인터를 어디서인가 참조하게 될 경우 1 증가, 그 포인터를 해제할 때 실제로 해제하는 것이 아니라 참조 카운터를 1 감소시킴
	   참조 카운터를 사용하는 방식 -> 스마트 포인터 -> 오류가 많아 수정과 발전한 방식 -> 유니크 포인터(C++) -> 진화 -> 가비지 콜렉터(JAVA)
	   가비지 콜렉터: 사용되고 있는 메모리에 각각 참조 카운터를 적용, 특정한 타이밍에 카운터가 0이 되어있는 것들을 한번에 해제. 너무 오래걸림, 사용자가 정리 타이밍을 선택할 수 없음. -> 게임프로그래밍에 부적합
	   C, C++은 직접 관리가 가능하기 때문에 게임프로그래밍에 적합
	   그래서 큰 게임은 C++을 사용하는 언리얼로 많이 제작하는 것
	   유니티는 C#이라 자동으로 되지만 너무 느림 */

	//pArr[2] = 100;
	//printf("pArr[2]: %f\n", pArr[2]);
	//printf("*(pArr+2): %f\n", *(pArr+2)); // pArr+2 :pArr(주소)에서, +2: 2칸 떨어진 곳의, *(): 값을 봄. *pArr + 2: *pArr 가리키고 있는 주소 안의 값에, +2: 2를 더함

	// 다차원 배열 동적할당
	int** pArr2d = (int**)malloc(sizeof(int*) * 2); //행
	//int* pArr1d = (int*)malloc(sizeof(int) * 3); //열
	//pArr2d[0] = pArr1d;
	
	// 열이 될 배열 2개의 각 첫 주소를 배열 형태로 저장한다(행이 될 배열에 저장한다)
	// 열 배열의 첫주소를 포인터에 저장(int*), 포인터의 주소는 또 다른 공간에 저장(int**, int 2차원 포인터). 포인터의 포인터.
	// 포인터의 포인터의 포인터의 포인터의 포인터. 의 포인터의 포인터의 포인터의포인터의포인터의포인터 건축무한육면각체가 또 !!
	// 주소 안의 주소 주소 안의 주소 주소 안의 주소 안의 주소안의주소안의주소안의주소
	// 5차원 포인터배열을 만들고 .txt로 출력 ㄷㄷ 현대식 건축무한육면각체 작시

	for (int i = 0; i < 2; ++i) {
		*(pArr2d + i) = (int*)malloc(sizeof(int) * 3);
	}
	
	*(*(pArr2d + 1) + 2) = 100; // 똑같다
	pArr2d[1][2] = 100;         // 똑같다

	for (int i = 0; i < 2; ++i) {
		for (int j = 0; j < 3; ++j) {
			printf("*(*(pArr2d + %d) + %d): %d (%p)\n", i, j, *(*(pArr2d + i)+j), &(*(*(pArr2d+i)+j)) ); 
			// 1차원포인터배열을 두번 할당해서 각각 2차원 배열을 만들었기 때문에 1차원 배열의 시작점마다 메모리 위치가 다름. 연속되지 않음
			// 정적배열과 같이 만드려면 1차원 포인터 배열의 길이를 2배로 해서 첫 주소와 중간 주소를 각각 2차원 배열에 넣어주면 된다.

			// 1차원포인터 배열 2개를 2차원포인터 배열에 저장해서 만드는 방식은 3번 해제해줘야함. 해제는 생성의 역순
			// 1차원포인터 배열 2개의 정보는 2차원포인터 배열에 저장되어 있기 때문에 2차원포인터 배열을 먼저 해제하면 1차원포인터 배열들이 미아가 될 수 있다.
			// 1차원포인터 배열들은 2차원포인터 배열의 존재를 모르기 때문에 1차원 배열 먼저 해제해 줘야한다.
		}
	}

	for (int i = 0; i < 2; ++i) {  // 1차원포인터 배열 해제
		if (*(pArr2d + i) != NULL) { // *(pArr2d+i): 2차원포인터 배열 pArr2d의 i번째 요소(pArr2d의 i번째에 저장되어 있는 값, pArr1d(1차원포인터 배열)의 주소)가 NULL이 아니라면
			free(*(pArr2d + i)); // pArr2d의 i번째 요소의 값(pArr1d가 가리키는 주소에 들어있는, 할당되어 있는 메모리) 해제
			*(pArr2d+i) = NULL; // pArr2d의 i번째 요소를 비움
		}
	}
	if (pArr2d != NULL) { // pArr2d가 NULL이 아니라면
		free(pArr2d); // pArr2d가 가리키는 주소에 들어있는, 할당되어있는 메모리를 해제
		pArr2d = NULL; // pArr2d를 비움(pArr2d에 저장되어 있던 주소를 지움)
	}

	// 정상적으로 모두 해제되고 종료되었다면 코드 0이 반환됨
	// 사용되고 있는 메모리의 상태를 추적해주는 프로파일러를 사용하는 것을 권장


	return 0;
}