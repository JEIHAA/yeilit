#include <stdio.h>
#include <malloc.h>

//Default Length
#define DEF_LEN 5
// Macro Function
#define SAFE_FREE(p) do { if (p) { free(p); p = NULL; }} while (0);


int AllocateVector(	int** const _pVec,	int* const _pCurIdx, int* const _pMaxLen, int _len);

void Insert( int** const _pVec,	int* const _pCurIdx, int* const _pMaxLen, int _insertIdx, int _value);

void PrintVector( const int* const _pVec,	int _curIdx, int _maxLen);

void AddFront(int** const _pVec, int* const _pCurIdx, int* const _pMaxLen, int _value);

void AddBack(int** const _pVec, int* const _pCurIdx, int* const _pMaxLen, int _value);

void Clear(int* const _pCurIdx);

void RemoveAt(int** const _pVec, int* const _pCurIdx, int _insertIdx);

// *RemoveAt*

int main() {
	// 벡터(Vector), Array
	// STL(Standard Template Library)

	int* pVector = NULL;
	int maxLen = 0;
	int curIdx = 0;
	if (AllocateVector(&pVector, &curIdx, &maxLen, DEF_LEN) == -1) {
		printf("ERROR] AllocateVector is Failed!\n");
		return -1;
	}

	for (int i = 0; i < 5; ++i)
		Insert(&pVector, &curIdx, &maxLen, i, i*10);

	PrintVector(pVector, curIdx, maxLen);

	Insert(&pVector, &curIdx, &maxLen, 3, 123);

	PrintVector(pVector, curIdx, maxLen);

	AddFront(&pVector, &curIdx, &maxLen, 456);
	PrintVector(pVector, curIdx, maxLen);

	AddBack(&pVector, &curIdx, &maxLen, 567);
	PrintVector(pVector, curIdx, maxLen);

	Clear(&curIdx);

	AddBack(&pVector, &curIdx, &maxLen, 567);
	PrintVector(pVector, curIdx, maxLen);

	AddFront(&pVector, &curIdx, &maxLen, 456);
	PrintVector(pVector, curIdx, maxLen);

	RemoveAt(&pVector, &curIdx, 2);
	PrintVector(pVector, curIdx, maxLen);

	RemoveAt(&pVector, &curIdx, 1);
	PrintVector(pVector, curIdx, maxLen);

	SAFE_FREE(pVector)

	/*if (pVector != NULL) {
		free(pVector);
		pVector = NULL;
	}*/
	return 0;
}

int AllocateVector(int** const _pVec, int* const _pCurIdx, int* const _pMaxLen, int _len) {
	if (_pVec == NULL) return -1;
	if (_len < 1) return -1;
	
	//if (*_pVec != NULL) {
	//	//return -1; 이미 쓰고 있는 공간을 해제하고 싶으면 하면 되고 그냥 두고 싶으면 그냥 리턴하면 된다
	//	free(*_pVec);
	//	*_pVec = NULL;
	//}

	SAFE_FREE(*_pVec);

	*_pVec = (int*)malloc(sizeof(int) * _len);
	if (*_pVec == NULL) return -1;

	*_pCurIdx = 0;
	*_pMaxLen = _len;

	return 0;
}

void Insert(int** const _pVec, int* const _pCurIdx, int* const _pMaxLen, int _insertIdx, int _value) {
	if (_pVec == NULL || _pCurIdx == NULL) return;
	if (_insertIdx < 0 || _insertIdx > *_pCurIdx) {
		printf("ERROR] Invalid Index!\n");
		return;
	}

	if (*_pCurIdx == *_pMaxLen) {
		//realloc()
		//calloc() 할당 후에 자동으로 0으로 초기화 해줌
		// 1. 새로운 공간 할당
		int* pNewVec = (int*)malloc(sizeof(int) * (*_pMaxLen * 2));
		// 2. 기존 배열에서 값을 복사
		for (int i = 0; i < _insertIdx; ++i) {
			*(pNewVec + i) = *((*_pVec) + i);
		}

		*(pNewVec + (_insertIdx)) = _value;

		for (int i = (_insertIdx+1); i <= (*_pCurIdx); ++i) {
			*(pNewVec + i) = *((*_pVec) + (i-1));
		}

		// 3. 기본 배열 제거
		SAFE_FREE(*_pVec);

		// 4. 새로운 배열을 설정
		*_pVec = pNewVec;

		//*((*_pVec) + _pCurIdx) = _value;

		++(*_pCurIdx);
		(*_pMaxLen) <<= 1; //2배로 늘림

		return;
	}

	int curIdx = *_pCurIdx;
	for (int i = curIdx; i > _insertIdx; --i) {
		(*_pVec)[i] = (*_pVec)[i - 1];
	}
	
	(*_pVec)[_insertIdx] = _value;

	
	++(*_pCurIdx);
}

void AddFront(int** const _pVec, int* const _pCurIdx, int* const _pMaxLen, int _value) {
	Insert(_pVec, _pCurIdx, _pMaxLen, 0, _value);
}

void AddBack(int** const _pVec, int* const _pCurIdx, int* const _pMaxLen, int _value) {
	Insert(_pVec, _pCurIdx, _pMaxLen, *_pCurIdx, _value);
}

void Clear(int* const _pCurIdx) {
	*_pCurIdx = 0;
}

void RemoveAt(int** const _pVec, int* const _pCurIdx, int _insertIdx) {
	if (_pVec == NULL || _pCurIdx == NULL) return;
	if (_insertIdx < 0 || _insertIdx > *_pCurIdx) {
		printf("ERROR] Invalid Index!\n");
		return;
	}
	for(int i =_insertIdx; i<(*_pCurIdx-1); ++i)
		*((*_pVec) + i) = *(*_pVec+(i+1));
	--(*_pCurIdx);
}

void PrintVector(const int* const _pVec, int _curIdx, int _maxLen) {
	if (_pVec == NULL) return;
	if (_curIdx < 0 || _maxLen < 0) {
		printf("ERROR] !\n");
		return;
	}

	for (int i = 0; i < _curIdx; ++i)
		printf("%d - ", _pVec[i]);
	printf("(%d/%d)\n", _curIdx, _maxLen);
}