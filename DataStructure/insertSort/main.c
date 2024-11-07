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
// TODO: �̱� ��ũ�� ����Ʈ�� Ȱ���� ��������!
int main()
{
	//���� ����(Insertion Sort)
	//O(n^2)
	int arr[MAX_LEN] = { 0 }; // �迭�� ���� ���
	srand(time(NULL));
	for (int i = 0; i < MAX_LEN - 1; ++i)
		arr[i] = rand() % 10;
	PrintArray(arr, MAX_LEN);
	//Pseudo Code(�ǻ� �ڵ�)

	//1. Ű�� ����
	//1-1 for(key 1 ���� �����ϰ� MAX����)
	for (int key = 1; key < MAX_LEN; ++key) // key���� �Ű��� ���̴�. key�� 1���� �����ؼ� �迭�� �ִ� ���� ������  ����
	{// 2. Ű�� ������ ��ȸ (Ű������ ū����ã���� �׿��ʿ�����)
		int keyVal = arr[key]; // key ���� ��ȭ�� ���� �ʱ� ���� keyVal������ ����
		int i = key - 1; // key ���� ���� i �� ����
		for (; i >= 0; --i) // i�� 0���� ũ�ų� ������������ ������
		{//3.�� �ű��
			if (keyVal < arr[i]) // ���� i�� �迭�� Ű������� Ŭ�� �ݺ�
			{
				printf("%d: %d -> %d\n", key, i, i + 1);  // i�� �迭�� i+1��ŭ �̵��� ���� �����
				arr[i + 1] = arr[i]; // i�� + 1 �� ��ŭ�� �ڸ��� i������

			}
			//3-1. Ż������
			else
			{
				break; //if ������ �ƴҶ� ������ Ż����
			}
		}
		// 4. ����
		printf("Insert: %d (%d)\n", i + 1, keyVal);
		arr[i] = keyVal; // i + 1�� �ڸ��� Ű ���(keyVal)�� ������

		PrintArray(arr, MAX_LEN);
	}
}
