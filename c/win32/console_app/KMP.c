#include "KMP.h"
#include <string.h>
#include <stdlib.h>
#include <stdio.h>

KMP * KMP_init(const char *pat, const int R) {
    KMP *kmp = malloc(sizeof(KMP*));
    int M = strlen(pat);

    char* p = calloc(M, sizeof(char));
    printf("length of p is: %d", strlen(p));
    
    
    for (int i = 0; i < M; i++) {
        p[i] = pat[i];
    }

    kmp->pat = p;
    kmp->patLength = M;
    kmp->R = R;
    
    kmp->dfa = calloc(R, sizeof(int *));
    for (int r = 0; r < R; r++) {
        kmp->dfa[r] = calloc(M, sizeof(int));
    }
    
    kmp->dfa[0][0] = 1;
    for (int i = 1; i < M; i++) {
        kmp->dfa[0][i] = 0;
    }
    for (int X = 0, j = 1; j < M; j++) {
        for (int c = 0; c < R; c++) {
            kmp->dfa[c][j] = kmp->dfa[c][X];
        }
        kmp->dfa[(int)pat[j]][j] = j + 1;
        X = kmp->dfa[(int)pat[j]][X];
    }
    return kmp;
}

int KMP_search(const KMP *kmp, const char *txt) {
    const int M = kmp->patLength;
    const int N = strlen(txt);
    int i, j;
    for (i = 0, j = 0; i < N && j < M; i++) {
        j = kmp->dfa[(int)txt[i]][j];
    }
    if (j == M) {
        return i - M;
    }
    return N;
}

void KMP_free(KMP *kmp) {
    free(kmp->pat);
    for (int r = 0; r < kmp->R; r++) {
        free(kmp->dfa[r]);
    }
    free(kmp->dfa);
    //free(kmp);
}