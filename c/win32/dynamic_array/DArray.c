#include "DArray.h"

#define DEFAULT_EXPAND_RATE 300

DArray *DArray_create(size_t elementSize, rsize_t initialMax) {
    DArray *array = malloc(sizeof(DArray));
    array->max = initialMax;
    array->contents = calloc(initialMax, sizeof(void *));
    
    array->end = 0;
    array->element_size = elementSize;

    array->expand_rate = DEFAULT_EXPAND_RATE;
    return array;
}

void DArray_destroy(DArray *arr) {
    if (arr) {
        if (arr->contents) {
            free(arr->contents);
        }
        free(arr);
    }
}

void DArray_clear(DArray *arr) {
    if (arr->element_size > 0) {
        for (int i = 0; i < arr->max; i++) {
            if (arr->contents[i] != NULL) {
                free(arr->contents[i]);
            }
        }
    }
}

void DArray_clear_destroy(DArray *arr) {
    DArray_clear(arr);
    DArray_destroy(arr);
}