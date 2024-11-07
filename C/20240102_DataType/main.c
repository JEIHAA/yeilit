#include <stdio.h>

void main(void){
	int i = 10; //���� ����, �ʱ�ȭ
	i = 7; // ���� �� ����
	printf(" i: %d (%p)\n", i, &i);
	printf(" int size: %d Byte\n\n", sizeof(int)); // sizeof�� %d�� ����ؼ� ���� �߻�

	float f = 3.14f;
	printf(" f: %f (%p)\n", f, &f);
	printf(" f size: %d Byte\n\n", sizeof(f));

	int  ftoi = 3.14f;
	printf(" ftoi: %d / %f\n", ftoi, ftoi); //int�� ������ %f�� ���������� ����� �� ����

	float itof = 10;
	printf(" itof: %d / %f\n\n", itof, itof); //float�� ������ %d�� ���������� ����� �� ����

	float x = i + f;
	float x1 = f + i;
	printf(" i+f: %d, %f\n", x, x);
	printf(" f+i: %d, %f\n\n", x1, x1);

	char c1 = 'a'; // �⺻������ ���Ǵ� char�� signed char, '��ȣ�� ����' char ��ȣ ��Ʈ�� ����ϰ� ���� ���� ���� unsigned char ���
	unsigned char c2;
	printf(" c1: %c ", c1);
	printf(" c1: %c\n", 65); // A�� �ƽ�Ű�ڵ� 65, 65�� ���������� ����ϸ� A
	
	c1 = 128;
	printf(" c1: %d ", c1); // -128�� ��µ�. 8bit�� ù��°�ڸ�, 128 �ڸ��� ��ȣ ��Ʈ��. 0�� �Ǹ� ��� 1�� �Ǹ� ������ �ǹǷ� ǥ�� ������ ���� �ִ� +-127

	c2 = 200;
	printf(" c2: %d\n", c2); //c2�� unsigned char�̱� ������ ���������� ���, signed�� ��ȣ ��Ʈ �˻縦 ������ unsigned�� �ǳʶٱ� ������ �ξ� ����
	

	printf(" char Size: %d Byte\n", sizeof(char));

	short s = 5; //Ǯ���� signed short int, unsigned short int ����
	printf(" short Size: %d Byte\n", sizeof(short)); //int�� ���� ũ��. �ӵ��� int�� ���� �������� �޸𸮸� �Ƴ��� ���ؼ� unsigned short int�� unsigned char ���� ���  ���ٵ��� unsigned�� �ʼ�����!

	long l = 100; // Ǯ���� signed long int
	printf(" long Size: %d Byte\n", sizeof(long));

	long long ll = 1000; //signed long long int
	printf(" long long Size: %d Byte\n", sizeof(long long));

	//Double Precision Floationg-Point �ι� ������ �ε� �Ҽ���. �Ǽ��� ��ȣ�� �� �� ��� unsigned�� ���� ����ӵ��� float�� ����, �޸𸮴� �ι� ����
	//���� �ڵ������� int�� ���� �ӵ��� ���� ������ ������ �Ǽ��� ������ �ٲ㼭 int ������ �� �ڿ� �ٽ� �Ǽ��� ��ȯ�ϴ� ����� ����ϱ⵵ ��
	double d = 123.456;
	printf(" double Size: %d Byte\n\n", sizeof(double));

	//��ǻ�Ͱ� ������ ���ϰ� 0�� ���ϴ� ���.            1�� �������� ���� �� 1�� ���Ѵ� -> 2�� ����


	//Type Casting. Type Conversion
	i = f; // ������ �� ��ȯ
	i = (int)f; //����� �� ��ȯ�� ���� �����ϰ� ����� ���̱� ������ ������ �߻����� ���� ���� �ٽ� �ϸ� �����	
	printf("(float)i: %f\n", (float)i); //����� �� ��ȯ i�� �»��� int���ε� ����ϴ� ������ (float)�� �־ �� �������� float�� �ٲ�.(���� )

	float result = (float)5 / 2; // �׳� 5/2�� int�� �����̶� 2.000���� �����
	//������ �� �Ѵ��� ���� �� �� �ֵ��� ��� ���� ��Ȯ�� ǥ���ϴ°� ���� ���� �ѹ� �� ������ �ʿ� �����Ѵ�. ������
	// ���� ���� �� ��ȯ�� �߻����� �ʵ��� �ڷ����� �ִ��� �����. �޸𸮿� �ӵ� ����. ����ġ�� �����ϴϱ�
	//(float)5/2�� 5.0/2.0�ϸ� ���������� ���۵� �ϳ��� �� ��ȯ�ص� �����۵� �Ǵ� ������ �ڷ����� �������� ������ �� ���е��� ���� �ڷ������� ����. '�ڷ����� �°�'
	printf("result: %f\n", result);


	char t1 = -128;
	unsigned char t2 = t1;
	printf("%d %d", t1, t2);
}