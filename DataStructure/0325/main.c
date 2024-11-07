#include <stdio.h>
#include<malloc.h>
#include<minmax.h>
#define SAFE_FREE(p) do{if(p){free(p);p=NULL;}} while(0)

//kch8246@naver.com
//월요일 아침까지
//날짜_자료구조_이름
void error(char _str);
int Mystrlen(char** _str);
int Mystrcmp(char** _str, char** _str2);
void Mystrcpy(char** _str, char** _str2);
void Mystrcat(char** _str, char** _str2, char* _cat);
int main() {
	//1. strlen(String Length)  입력한 문자열의 길이를 반환해주는 함수 (출력까지)
	char* str = (char*)malloc(sizeof(char) * 100);
	char* str2 = (char*)malloc(sizeof(char) * 100);
	char* strcpy = (char*)malloc(sizeof(char) * 100);
	printf("1번 문자열을 입력하시요.:");
	scanf_s("%s", str, 100);
	printf("2번 문자열을 입력하시요.:");
	scanf_s("%s", str2, 100);
	printf("lenth %d\n", Mystrlen(&str));
	printf("1번 문자열 : %s\n", str);
	printf("2번 문자열 : %s\n", str2);
	// 문자열의 내용을 출력


	int temp = Mystrcmp(&str, &str2);
	printf("문자열 같으면 0 다르면 1  : %d\n", temp);

	//2. strcmp(String Compare) 문자열을 비교하는 함수 (같은지? 몇개가 다른지 반환되는 함수)
	//2-1. 반환값은1 혹은0 문자열 비교해서 같은지 다른지 비교.

	//Mystrcmp(&str, &str2, strlen, strlen2);

	printf("1번 문자열의 길이는 : %d\n", Mystrlen(&str));
	printf("2번 문자열의 길이는 : %d\n", Mystrlen(&str2));
	int strlen = Mystrlen(&str);
	int strlen2 = Mystrlen(&str2);

	printf("True or False :%d\n", Mystrcmp(&str, &str2, strlen, strlen2));


	//3. strcpy(String Copy) 문자열을 복사 해주는 함수
	printf("복사할 문자열:");
	scanf_s("%s", strcpy,100);
	char* copy = NULL;
	char* cat = NULL;
	Mystrcpy(&copy, &strcpy);
	printf("복사된 문자열:%s \n", copy);
	//printf("합쳐진 문자열 :%s", );


	// 합쳐진 문자열 출력
	//4.strcat(String Concatenation) 문자열을 합쳐주는 함수
	Mystrcat(&str, &str2, &cat);

	//3-1. 동적할당 

	SAFE_FREE(str);
	SAFE_FREE(str2);
	SAFE_FREE(copy);
	SAFE_FREE(cat);
	//선생님!! 메모리 해제가 됩니다!!!!!!
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
		printf("문자열의 길이가 다르며 2번 문자열이 더 깁니다.\n");

	}
	else if (stlen > stlen2) {
		printf("문자열의 길이가 다르며 1번 문자열이 더 깁니다.\n");
	}
	else {
		printf("문자열의 길이가 똑같습니다. \n");
	}*/
	/*for (int i = 0; (*(*_str + i) != NULL || (*(*_str2 + i)) != NULL); i++) {
		if (*(*_str + i) == *(*_str2 + i)) {
			printf("서로 같은 문자열[%c]\n", *(*_str + i));
		}
		else {
			printf("[diffrent!]문자 : [%c] != [%c] \n", *(*_str + i), *(*_str2 + i));
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
	printf("합쳐진 문자열 : %s\n", _cat);
}