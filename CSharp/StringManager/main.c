#include <stdio.h>
#include <malloc.h>

// kch8246@naver.com
// 월요일 아침까지
// 제출날짜_자료구조_이름
// 20240119_자료구조_김찬호

int MyStrLen(char _str[]);
int MyStrCmp(char _str1[], char _str2[]);
void MyStrCpy(char** _cpy, char _str[]);
void MyStrCat(char** _cat, char _str1[], char _str2[]);

int main()
{
	// 1. strlen(String Length)
	int len = MyStrLen("Hello");
	printf("%d\n", len);

	// 2. strcmp(String Compare)
	// 2-1. 반환값은 1 혹은 0
	int cmp = MyStrCmp("Hello", "Hello");
	printf("%d\n", cmp);

	//// 3. strcpy(String Copy)
	//// 3-1. 동적할당
	char* cpy = NULL;
	MyStrCpy(&cpy, "World!");
	printf("%s\n", cpy);

	//// 4. strcat(String Concatenation)
	//// 4-1. 동적할당
	char* cat = NULL;
	MyStrCat(&cat, "Hello, ", "World!");
	printf("%s", cat);

	if (cpy != NULL) {
		free(cpy);
		cpy = NULL;
	}
	if (cat != NULL) {
		free(cat);
		cat = NULL;
	}

	return 0;
}

int MyStrLen(char _char[]) {
	int cnt=0;
	while (_char[cnt] != '\0') {
		cnt++;
	}
	return cnt;
}

int MyStrCmp(char _str1[], char _str2[]) {
	int i = 0;
	int value = 0;
	while (_str1[i] != NULL || _str2[i] != NULL) {
		if (_str1[i] != _str2[i]) {
			value++;
		}
		i++;
	}
	if (value != 0) return 0;
	else return 1;	
}

void MyStrCpy(char** _cpy, char _str[]) {
	int len = MyStrLen(_str);
	*_cpy = (char*)malloc(sizeof(char) * (len+1));
	int i = 0;
	while (_str[i] != NULL) {
		*(*_cpy + i) = _str[i];
		i++;
	}
	*(*_cpy + i) = '\0';
}

void MyStrCat(char** _cat, char _str1[], char _str2[]) {
	int str1Len = MyStrLen(_str1);
	int str2Len = MyStrLen(_str2);
	int catIdx = 0;
	*_cat = (char*)malloc(sizeof(char) * (str1Len + str2Len +1));

	int i = 0;
	while (_str1[i] != NULL) {
		*(*_cat + i) = _str1[i];
		i++;
	}
	catIdx += i;
	
	i = 0;
	while (_str2[i] != NULL) {
		*(*_cat + (i + str1Len)) = _str2[i];
		i++;
	}
	catIdx += i;

	*(*_cat + catIdx) = '\0';
}