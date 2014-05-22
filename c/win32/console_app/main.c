#include <Windows.h>
#include <wchar.h>
#include <stdio.h>
#include "KMP.h"

#define STR_EQUAL 0

// Quick sort demo
void Quick_sort_demo() {
    
}

typedef struct {
    int length;
    int *arr;
} MyArray;

MyArray * MyArray_init(int length) {
    MyArray *arr = malloc(sizeof(MyArray));
    arr->length = length;
    arr->arr = malloc(length * sizeof(int));
    for (int i = 0; i < length; i++) {
        *(arr->arr + i) = i + 1;
    }
    return arr;
}

void MyArray_destroy(MyArray *arr) {
    if (arr) {
        if (arr->arr) {
            free(arr->arr);
        }
        arr->length = 0;
    }
}

int search(const char *pat, const char *txt) {
    int M = strlen(pat);
    int N = strlen(txt);
    for (int i = 0; i <= N - M; i++) {
        int j;
        for (j = 0; j < M; j++) {
            if (*(txt + i + j) != *(pat + j)) {
                break;
            }
        }
        if (j == M) {
            return i;
        }
    }
    return N;
}

void testSearch(const char* pat, const char* txt) {
    int find = search(pat, txt);

    printf("%s\n", txt);
    for (int i = 0; i < find; i++) {
        printf("%s", " ");
    }
    printf("%s\n", pat);
}

void testKmpSearch(const char* pat, const char* txt) {
    KMP *kmp = KMP_init(pat, 256);
    int find = KMP_search(kmp, txt);
    KMP_free(kmp);
    free(kmp);

    printf("%s\n", txt);
    for (int i = 0; i < find; i++) {
        printf("%s", " ");
    }
    printf("%s\n", pat);
}

int* testReturnArray() {
    int len = 10;
    int* a = malloc(len * sizeof(int));
    for (int i = 0; i < len; i++) {
        *(a + i) = i;
    }
    return a;
}

int wmain(int argc, WCHAR *argv[]) {
    SYSTEMTIME lt;
    GetLocalTime(&lt);

    wprintf(L"The local time is: %02d:%02d:%02d\n", lt.wHour, lt.wMinute, lt.wSecond);
    //Quick_sort_demo();

    printf("\n");

    char *txt = "AABACAABABACAA";
    char *pat = "ABABAC";

    testSearch(pat, txt);

    printf("\n");

    //testKmpSearch(pat, txt);

    int* arr = testReturnArray();
    free(arr);

    MyArray *myArr = MyArray_init(10);
    MyArray_destroy(myArr);
    
    //free(txt);
    //free(pat);

    return EXIT_SUCCESS;
}