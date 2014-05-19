#include <Windows.h>
#include <wchar.h>
#include <stdio.h>
#include "KMP.h"

#define STR_EQUAL 0

// Quick sort demo
void Quick_sort_demo() {
    
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

int wmain(int argc, WCHAR *argv[]) {
    SYSTEMTIME lt;
    GetLocalTime(&lt);

    wprintf(L"The local time is: %02d:%02d:%02d\n", lt.wHour, lt.wMinute, lt.wSecond);
    //Quick_sort_demo();

    printf("\n");

    char *txt = "AABACAABABACAA";
    char *pat = "ABABAC";

    int find = search(pat, txt);

    printf("%s\n", txt);
    for (int i = 0; i < find; i++) {
        printf("%s", " ");
    }
    printf("%s\n", pat);

    printf("\n");

    KMP *kmp = KMP_init(pat, 256);
    int find2 = KMP_search(kmp, txt);
    KMP_free(kmp);
    free(kmp);

    printf("%s\n", txt);
    for (int i = 0; i < find; i++) {
        printf("%s", " ");
    }
    printf("%s\n", pat);

    //free(txt);
    //free(pat);

    return EXIT_SUCCESS;
}