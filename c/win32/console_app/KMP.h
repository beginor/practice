#ifndef _KMP_h
#define _KMP_h

typedef struct _KMP {

    int R;
    char *pat;
    int patLength;
    int **dfa;

} KMP;

/* Create kmp search struct */
KMP * KMP_init(const char *pat, const int R);

/* do kmp search with text */
int KMP_search(const KMP *kmp, const char *txt);

void KMP_free(KMP *kmp);
#endif