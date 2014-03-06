#include "DArray.h"

int main(int argc, char** argv) {
    
    DArray *arr = DArray_create(10, 10);
    
    DArray_clear_destroy(arr);

    return 0;
}