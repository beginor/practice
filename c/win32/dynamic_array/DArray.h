#ifndef _DArray_h
#define _DArray_h

#include <stdlib.h>

typedef struct _DArray {

    int end;
    int max;

    size_t element_size;
    size_t expand_rate;

    void **contents;

} DArray;

DArray *DArray_create(size_t elementSize, rsize_t initialMax);

void DArray_destroy(DArray *arr);

void DArray_clear(DArray *arr);

void DArray_clear_destroy(DArray *arr);

#endif