#include <stdio.h>

//#1. loop_cnt�� ���������� �� ������ �ʱ�ȭ.
//#2. loop_cnt��ŭ loop�� �ݺ��ϸ� �������� A0 = 0, An = An - 1 + n�� ����Ͽ� ����

int MakeStar(int a);

int main(void)
{
    /*int n;

    scanf("%d", &n);

    int loop_cnt = n * (1 + (n)) / 2;
    int new_line_index = 0;
    int cnt = 2;

    for (int i = 0; i < loop_cnt; i++)
    {
        printf("*", n);

        if (new_line_index == i)
        {
            printf("\n");
            new_line_index += cnt;
            cnt++;
        }
    }*/

	/*int a = 0;
	printf("�ܰ踦 �����ּ���:");
	scanf("%d", &a);
	MakeStar(a);
    return 0;*/



    float num, inum;

    printf("�ݿø�");
    scanf("%f", &num);
    inum = (int)num;

    printf("inum %f", inum);

    
    




}

//int MakeStar(int a) {
//	int b = 1;
//	int plus = 2;
//
//	for (int i = 1; i <= a * (a + 1) / 2; i++)
//	{
//		printf("*");
//		if (i == b) {
//			printf("\n");
//			b = b + plus;
//			plus++;
//		}
//	}
//
//}