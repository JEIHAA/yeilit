#include <stdio.h>
#include <stdlib.h>

char* Lower(char _str[], int _len);
char* Upper(char _str[], int _len);
char* Swap(char _str[], int _len);

//Lower 소문자로
//Upper 대문자로
//Swap 소->대 대->소
//ASCII CODE
//예외처리
//kch8246@naver.com
//파일명 20240109_C_이희언.c
//메일제목 [과제] 20240109 C 이희언
int main() {
	unsigned char str[] = "Hello, World!";
	int len = sizeof(str) / sizeof(str[0]);
	int i = 0;

	printf("%s\n", str);
	printf("%s\n", Lower(-5, len));
	printf("%s\n",Upper(str, len));
	printf("%s\n", Swap(str, len));


	return 0;
}

char* Lower(const unsigned char _str[], int _len) {
	int i = 0;
	static unsigned char temp[5];
	if (_str == NULL ) {
		printf("NULL!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
		return 0;
	}
	else if (_str >= 0 && _str <= 31) {
		printf("문자만!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
		return 0;
	}
	else if (_str <= 0 || _str == "") {
		printf("문자만!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
		return 0;
	}
	while (_str[i] != '\0') {
		if (i >= 50) {
			printf("너무긺!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
			return 0;
		}
		else{
			temp[i] = _str[i];
		}
		++i;
	}
	temp[i] = '\0';
	for (i = 0; i < _len; ++i) {
		if (temp[i] > 65 && temp[i] <= 90) {
			temp[i] = temp[i] + 32;
		}
	}
	return temp;
}

char* Upper(const char _str[], int _len) {
	int i = 0;
	static char temp[50];
	if (_str == NULL) {
		printf("NULL!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
		return 0;
	}
	else if (_str >= 0 && _str <= 31) {
		printf("문자만!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
		return 0;
	}
	while (_str[i] != '\0') {
		if (i >= 50) {
			printf("너무긺!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
			return 0;
		}
		else {
			temp[i] = _str[i];
		}
		++i;
	}
	temp[i] = '\0';
	for (i = 0; i < _len; ++i) {
		if (temp[i] > 97 && temp[i] <= 122) {
			temp[i] = temp[i] - 32;
		}
	}
	return temp;
}

char* Swap(const char _str[], int _len) {
	int i = 0;
	static char temp[50];
	if (_str == NULL) {
		printf("NULL!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
		return 0;
	}
	else if (_str >= 0 && _str <= 31) {
		printf("문자만!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
		return 0;
	}
	while (_str[i] != '\0') {
		if (i >= 50) {
			printf("너무긺!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
			return 0;
		}
		else {
			temp[i] = _str[i];
			++i;
		}
		
	}
	temp[i] = '\0';
	for (i = 0; i < _len; ++i) {
		if (temp[i] > 97 && temp[i] <= 122) {
			temp[i] = temp[i] - 32;
		}
		else if (temp[i] > 65 && temp[i] <= 90) {
			temp[i] = temp[i] + 32;
		}
	}
	return temp;
}