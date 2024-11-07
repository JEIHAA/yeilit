#include <stdio.h>

void PrintArray2D(int _arr2d[][3]);


// Literal Constant
#define ROW_CNT 2
#define COL_CNT 5

int main() {
	//������ �迭(Multidimensional Arrays)
	//int arr[��][��], row, column
	int arr2d[ROW_CNT][COL_CNT] = { { 11, 12, 13 }, { 21, 22, 23 } }; //2���� �迭�� �ʱ�ȭ �Ҷ��� �� ������ �ݵ�� �־���Ѵ� �ʱ�ȭ������ �ڵ����� ��������� �ʴ´�
	//2���� �迭�̿��� �޸𸮿� ����Ǵ� ����� 1�����迭�� ���� ������ ��ȣ ���о��� ���ڷθ� �ʱ�ȭ �ص� �˾Ƽ� �ȴ�

	for (int row = 0; row < ROW_CNT; ++row) {
		for (int col = 0; col < COL_CNT; ++col) {
			printf("arr[%d][%d]: %d (%p)\n", row, col, arr2d[row][col], &arr2d[row][col]);
		}
	}

	printf("arr2d Size: %d Byte\n", sizeof(arr2d));
	printf("arr2d[0][4]: %d (%p)\n", arr2d[0][4], &arr2d[0][4]);
	//���� �״�� �ΰ� ���� �̵��ص� �޸𸮴� 1�������� ����Ǿ� �ֱ� ������ �׸�ŭ �̵��� ��ġ�� ���� ���´�
	printf("arr2d: %p\n", arr2d);

	printf("arr2d[1]: %p\n", arr2d[1]);

	PrintArray2D(arr2d);
	return 0;
}

void PrintArray2D(int _arr2d[][3]) { // �Լ��� �迭�� ������ �� ���޵Ǵ°� ù �ּ� ���̿��� ���̸� ������� �ǹ̰� ���� ���� ���� ����
	for (int row = 0; row < ROW_CNT; ++row) {
		for (int col = 0; col < COL_CNT; ++col) {
			printf("_arr2d[%d][%d]: %d\n", row, col, _arr2d[row][col]);
		}
	}
	printf("_arr2d: %p\n", &_arr2d);
	printf("_arr2d[1]: %p\n", _arr2d[1]);

}