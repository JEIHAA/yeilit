#include <stdio.h>
#include <malloc.h>
#include <string.h>

#define SAFE_FREE(p) if(p) { free(p);  p = NULL; }\


// strlen(String Length)���ڿ� ���� ��ȯ���ִ� �Լ�
int MyStrLen(const char** const _pStr);

// strcmp(StringCompare) ���ڿ� �� ��ȯ�� 1 or 0
int MyStrCmp(const char** const _pStrCmpOne, const char** const _pStrCmpTwo );

// strcpy(String Copy) �����Ҵ�
void MyStrCpy(const char** _pStr , char** const _pCpyStr);

// strcat(String Concatenation)���ڿ� ��ġ�� //�����Ҵ�
void MyStrCat(char** const _pCatStr, const char** const _pStr, char** _pStr2);

// kch8246@naver.com
// 240119_�ڷᱸ��_�����
//���ڿ��� �����ϴ� ���
int main()
{
	char* str = (char*)malloc(sizeof(char)*100);
	char* str2 = (char*)malloc(sizeof(char)*100);
	printf("1�� ���ڿ��� �Է��ϼ���\n");
	scanf("%s",str);
	printf("2�� ���ڿ��� �Է��ϼ���\n");
	scanf("%s",str2);
	printf("1�� ���ڿ� : %s\n",str);
	printf("2�� ���ڿ� : %s\n", str2);
	int len = MyStrLen(&str);
	int len2 = MyStrLen(&str2);
	printf(" 1�� ���ڿ� count : %d\n", len);
	printf(" 2�� ���ڿ� count : %d\n", len2);
	
	
	int cmp = MyStrCmp(&str, &str2);
	printf("�� ���ڿ��� ����1. �ٸ���2  : %d\n", cmp);

	char* cpy = NULL;
	char* str3 = (char*)malloc(sizeof(char) * 100);
	printf("�����ϰ���� ���ڿ��� �Է��ϼ���\n");
	scanf("%s", str3);
	MyStrCpy(&cpy, &str3);
	printf("����� ��: %s\n", cpy);
	
	char* cat = NULL;
	MyStrCat(&cat, &str, &str2);
	printf("�ٿ����� : %s",cat);

	SAFE_FREE(str);
	SAFE_FREE(str2);
	SAFE_FREE(str3);
	SAFE_FREE(cpy);
	SAFE_FREE(cat);
	return 0;
}

int MyStrLen(const char** const _pStr)
{
	if (!_pStr)
	{
		printf("ERROR] (MyStrLen) Parameter is NULL!");
		return;
	}
	int i = 0;
	while (*(*_pStr + i))
	{
		i++;
	}
	return i;
}

int MyStrCmp(const char** const _pStrCmpOne, char** const _pStrCmpTwo)
{
	if (!_pStrCmpOne || !_pStrCmpTwo)
	{
		printf("ERROR] (MyStrCmp) Parameter is NULL!");
		return;
	}
	int i = 0;
	while ((*(*_pStrCmpOne + i)) || *(*_pStrCmpTwo + i)) //�� ���� �ϳ��� ���� �ƴϸ� while���� ���ư�
	{
		if (*(*_pStrCmpOne + i) != *(*_pStrCmpTwo + i)) //���� ���� ���� ������ �ٷ� �Լ�Ż��
		{
			return 0;
		}
		i++;
	}
	return 1;
}

void MyStrCpy(char** const _pStr, char** const _pCpyStr)
{
	if (!_pStr || !_pCpyStr)
	{
		printf("ERROR] (MyStrCpy) Parameter is NULL!");
		return;
	}
	int len = MyStrLen(_pCpyStr);
	*_pStr = (char*)malloc(sizeof(char) * (len+1));
	for (int i = 0; i < len; i++)
	{
		*(*_pStr + i) = *(*_pCpyStr + i);
	}
	*(*_pStr + len) = '\0';
}

void MyStrCat(char** const _pCatStr, const char** const _pStr, char** _pStr2)
{
	if (!_pCatStr || !_pStr || !_pStr2)
	{
		printf("ERROR] (MyStrCat) Parameter is NULL!");
		return;
	}
	int len = MyStrLen(_pStr);
	int len2 = MyStrLen(_pStr2);
	int curIdx = 0;
	
	*_pCatStr = (char*)malloc(sizeof(char)*(len + len2+1));
	for (int i = 0; i < len; i++)
	{
		*(*_pCatStr + curIdx) = *(*_pStr + i);
		curIdx++;
	}
	for (int j = 0; j < len2; j++)
	{
		*(*_pCatStr + curIdx) = *(*_pStr2 + j);
		curIdx++;
	}
	*(*_pCatStr + len + len2) = '\0';
}