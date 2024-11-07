#include <stdio.h>
#include<malloc.h>
#include<minmax.h>
#define SAFE_FREE(p) do{if(p){free(p);p=NULL;}} while(0)

//kch8246@naver.com
//������ ��ħ����
//��¥_�ڷᱸ��_�̸�
void error(char _str);
int Mystrlen(char** _str);
int Mystrcmp(char** _str, char** _str2);
void Mystrcpy(char** _str, char** _str2);
void Mystrcat(char** _str, char** _str2, char* _cat);
int main() {
	//1. strlen(String Length)  �Է��� ���ڿ��� ���̸� ��ȯ���ִ� �Լ� (��±���)
	char* str = (char*)malloc(sizeof(char) * 100);
	char* str2 = (char*)malloc(sizeof(char) * 100);
	char* strcpy = (char*)malloc(sizeof(char) * 100);
	printf("1�� ���ڿ��� �Է��Ͻÿ�.:");
	scanf_s("%s", str, 100);
	printf("2�� ���ڿ��� �Է��Ͻÿ�.:");
	scanf_s("%s", str2, 100);
	printf("lenth %d\n", Mystrlen(&str));
	printf("1�� ���ڿ� : %s\n", str);
	printf("2�� ���ڿ� : %s\n", str2);
	// ���ڿ��� ������ ���


	int temp = Mystrcmp(&str, &str2);
	printf("���ڿ� ������ 0 �ٸ��� 1  : %d\n", temp);

	//2. strcmp(String Compare) ���ڿ��� ���ϴ� �Լ� (������? ��� �ٸ��� ��ȯ�Ǵ� �Լ�)
	//2-1. ��ȯ����1 Ȥ��0 ���ڿ� ���ؼ� ������ �ٸ��� ��.

	//Mystrcmp(&str, &str2, strlen, strlen2);

	printf("1�� ���ڿ��� ���̴� : %d\n", Mystrlen(&str));
	printf("2�� ���ڿ��� ���̴� : %d\n", Mystrlen(&str2));
	int strlen = Mystrlen(&str);
	int strlen2 = Mystrlen(&str2);

	printf("True or False :%d\n", Mystrcmp(&str, &str2, strlen, strlen2));


	//3. strcpy(String Copy) ���ڿ��� ���� ���ִ� �Լ�
	printf("������ ���ڿ�:");
	scanf_s("%s", strcpy,100);
	char* copy = NULL;
	char* cat = NULL;
	Mystrcpy(&copy, &strcpy);
	printf("����� ���ڿ�:%s \n", copy);
	//printf("������ ���ڿ� :%s", );


	// ������ ���ڿ� ���
	//4.strcat(String Concatenation) ���ڿ��� �����ִ� �Լ�
	Mystrcat(&str, &str2, &cat);

	//3-1. �����Ҵ� 

	SAFE_FREE(str);
	SAFE_FREE(str2);
	SAFE_FREE(copy);
	SAFE_FREE(cat);
	//������!! �޸� ������ �˴ϴ�!!!!!!
	return 0;
}

void error(char _str) {
	if (!_str) {
		return -1;
	}

}
int Mystrlen(char** _str) {
	error(*_str);

	int i = 0;
	while (*(*_str + i))
	{
		i++;
	}
	return i;
}
int Mystrcmp(char** _str, char** _str2) {
	error(_str);
	error(_str2);
	int i = 0;

	/*if (stlen < stlen2) {
		printf("���ڿ��� ���̰� �ٸ��� 2�� ���ڿ��� �� ��ϴ�.\n");

	}
	else if (stlen > stlen2) {
		printf("���ڿ��� ���̰� �ٸ��� 1�� ���ڿ��� �� ��ϴ�.\n");
	}
	else {
		printf("���ڿ��� ���̰� �Ȱ����ϴ�. \n");
	}*/
	/*for (int i = 0; (*(*_str + i) != NULL || (*(*_str2 + i)) != NULL); i++) {
		if (*(*_str + i) == *(*_str2 + i)) {
			printf("���� ���� ���ڿ�[%c]\n", *(*_str + i));
		}
		else {
			printf("[diffrent!]���� : [%c] != [%c] \n", *(*_str + i), *(*_str2 + i));
			++dcnt;
		}
		}
		*/

	while ((*(*_str + i)) || *(*_str2 + i))
	{
		if (*(*_str + i) != *(*_str2 + i))
		{
			return 0;
		}
		i++;
	}
	return 1;

}

void Mystrcpy(char** _str, char** _str2) {
	error(*_str);
	int len = Mystrlen(_str2);
	*_str = (char*)malloc(sizeof(char) * (len)+1);

	for (int i = 0; i < len; i++) {
		*(*_str + i) = *(*_str2 + i);
	}

	*(*_str + len) = '\0';
}

void Mystrcat(char** _str, char** _str2, char* _cat) {
	int len = Mystrlen(_str);
	int len2 = Mystrlen(_str2);
	_cat = (char*)malloc(sizeof(char) * (len + len2)+1);
	static int i = 0;

	for (i = 0; i < len; ++i) {
		_cat[i] = (*_str)[i];
	};
	for (int j = 0; j < len2; ++j, ++i) {
		_cat[i] = (*_str2)[j];
	}

	_cat[i] = '\0';
	printf("������ ���ڿ� : %s\n", _cat);
}