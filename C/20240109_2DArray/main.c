#include <stdio.h>

void PrintArray2D(int _arr2d[][3]);


// Literal Constant
#define ROW_CNT 2
#define COL_CNT 5

int main() {
	//다차원 배열(Multidimensional Arrays)
	//int arr[행][열], row, column
	int arr2d[ROW_CNT][COL_CNT] = { { 11, 12, 13 }, { 21, 22, 23 } }; //2차원 배열을 초기화 할때는 열 정보는 반드시 있어야한다 초기화개수로 자동으로 만들어지지 않는다
	//2차원 배열이여도 메모리에 저장되는 방식은 1차원배열과 같기 때문에 괄호 구분없이 숫자로만 초기화 해도 알아서 된다

	for (int row = 0; row < ROW_CNT; ++row) {
		for (int col = 0; col < COL_CNT; ++col) {
			printf("arr[%d][%d]: %d (%p)\n", row, col, arr2d[row][col], &arr2d[row][col]);
		}
	}

	printf("arr2d Size: %d Byte\n", sizeof(arr2d));
	printf("arr2d[0][4]: %d (%p)\n", arr2d[0][4], &arr2d[0][4]);
	//행은 그대로 두고 열만 이동해도 메모리는 1차원으로 저장되어 있기 때문에 그만큼 이동한 위치의 값이 나온다
	printf("arr2d: %p\n", arr2d);

	printf("arr2d[1]: %p\n", arr2d[1]);

	PrintArray2D(arr2d);
	return 0;
}

void PrintArray2D(int _arr2d[][3]) { // 함수에 배열을 전달할 때 전달되는건 첫 주소 뿐이여서 길이를 맞춰봤자 의미가 없고 맞출 수도 없다
	for (int row = 0; row < ROW_CNT; ++row) {
		for (int col = 0; col < COL_CNT; ++col) {
			printf("_arr2d[%d][%d]: %d\n", row, col, _arr2d[row][col]);
		}
	}
	printf("_arr2d: %p\n", &_arr2d);
	printf("_arr2d[1]: %p\n", _arr2d[1]);

}