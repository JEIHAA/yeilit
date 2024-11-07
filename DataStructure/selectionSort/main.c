#include <stdio.h>
#include <stdlib.h> //�Ϲ������� �� ������� ������ �����ϴ� rand() �Լ��� ���� �߻��⸦ �ʱ�ȭ�ϴ� srand() �Լ��� ����Ǿ� �ֽ��ϴ�.
#include <time.h>//���� �ð��� ��� ���� time() �Լ��� �Ϲ������� �� ����� ����Ǿ� �ֽ��ϴ�.
#define MAX_LEN 6
// �����Ͱ� ��ġ���ʰ� �������� �� ä��� / ���� ū ���� ã�� �� ���� ��ҿ� ��ü�ϴ� ����� �ݺ�
// TODO: �̱� ��ũ�� ����Ʈ�� �������� �����ϱ�
int main()
{
	// ���� �˰���
	// ���� ����(Selection Sort)
	// Big-O Notation(��� ǥ���)
	// O(n^2)
	// 1. ���� ���� �� ã��
	// 2. ù ��° �ڸ��� �� ��ȯ
	srand(time(NULL));//���� �ð��� �̿��Ͽ� �Ź� �ٸ� ���� �����Ͽ� ���� �߻��⸦ �ʱ�ȭ�մϴ�.
	int arr[MAX_LEN] = { 15, 3, 7, 20, 1, 10 };// �迭 arr��ũ�⸦ �ƽ� ���������ְ� ������� 0���� �ʱ�ȭ�����
	//for (int i = 0; i < MAX_LEN; ++i) // �ִ� ũ�Ⱑ �� ������ ĭ�� �� ĭ�� �̵��Ѵ�
		//arr[i] = rand() % 100; // 100 ���ϱ����� ������ �߻��Ѵ�
	for (int i = 0; i < MAX_LEN; ++i) // �ִ� ũ�Ⱑ �� ������ �� ĭ�� �̵��Ѵ� - �ʱⰪ
		printf("%d - ", arr[i]);
	printf("(%d)\n", MAX_LEN);
	for (int i = 0; i < MAX_LEN - 1; ++i) // �迭�� �ִ� ���� �������� �˻��ϴ� for��
	{
		int minIdx = i;
		// minIdx�� ���� ���� ���� ��Ƶ� ������ ����, �ϴ� i�� �� ������ ���� �д� (�ּڰ��� ã���� �� ������ ����)
		for (int j = i + 1; j < MAX_LEN; ++j) // j(= �̵��� ��)�� i���� �� ĭ �տ� �־�� i�� ���� �� �־ i + 1.
		{
			// �ּڰ� ã��
			if (arr[minIdx] > arr[j]) // i�� j���� ũ�ٸ� ����
			{

				minIdx = j; // i�� �־�� �� ��ġ�� j�� �־� �ְ� if���� Ż���ؼ� �ٽ� if���� �������� ���ư��� �˻� �� �ݺ�
				// (ó�� minIdx�� 3�̿����� 3��������1�̳��ͼ� �װ����� ��������minIdx��
				printf("minIdx: %d (%d/%d)\n",
					arr[j], i, j);
			}
		}
		for (int i = 0; i < MAX_LEN; ++i)
			printf("%d - ", arr[i]);
		printf("(%d)\n", MAX_LEN);
		printf("\n");
		// ù ��° �ڸ��� �� ��ȯ
		// TODO: Swap�Լ� �����
		int tmp = arr[minIdx];//������������ minIdx��  tmp ������ ��Ƶ�
		arr[minIdx] = arr[i]; // i �� mixidx�� ������ ���ش�
		arr[i] = tmp; //  tmp�� i�� �������ش�
		printf("%d <- %d\n", i, minIdx);
	}
	for (int i = 0; i < MAX_LEN; ++i)
		printf("%d - ", arr[i]);
	printf("(%d)\n", MAX_LEN);
	return 0;
}