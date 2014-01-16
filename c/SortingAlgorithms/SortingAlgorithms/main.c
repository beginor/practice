#include <stdio.h>
#include <stdlib.h>

#include "sort_algs.h"
#include "sort_algs_helpers.h"

// test insertion sort;
void test_insertion_sort(void) {
    int *array;
    int len = 10;
    array = (int*)malloc(sizeof(int) * len);
    fill_random_array(array, len);
    
    printf("before insertion sort: \n");
    print_array(array, len);

    insertion_sort(array, len);
    
    printf("after insertion sort: \n");
    print_array(array, len);
    
    free(array);
}

// test selection sort
void test_selection_sort(void) {
    int *array;
    int len = 10;
    array = (int*)malloc(sizeof(int) * len);
    fill_random_array(array, len);
    
    printf("before selection sort: \n");
    print_array(array, len);

    selection_sort(array, len);
    
    printf("after selection sort: \n");
    print_array(array, len);
    
    free(array);
}

// test bubble sort
void test_bubble_sort() {
    int * array;
    int len = 10;
    array = (int *)malloc(sizeof(int) * len);
    fill_random_array(array, len);

    printf("before bubble sort: \n");
    print_array(array, len);

    bubble_sort(array, len);

    printf("after bubble sort: \n");
    print_array(array, len);

    free(array);
}

// test shell sort
void test_shell_sort() {
    int * array;
    int len = 10;
    array = (int *)malloc(sizeof(int) * len);
    fill_random_array(array, len);

    printf("before shell sort: \n");
    print_array(array, len);

    shell_sort(array, len);

    printf("after shell sort: \n");
    print_array(array, len);

    free(array);
}

// test merge sort
void test_merge_sort() {
    int * array;
    int len = 10;
    array = (int *)malloc(sizeof(int) * len);
    fill_random_array(array, len);
    
    printf("before merge sort: \n");
    print_array(array, len);
    
    merge_sort(array, len);
    
    printf("after merge sort: \n");
    print_array(array, len);
    
    free(array);
}

// test heap sort
void test_heap_sort() {
    int * array;
    int len = 10;
    array = (int *)malloc(sizeof(int) * len);
    fill_random_array(array, len);
    
    printf("before heap sort: \n");
    print_array(array, len);
    
    heap_sort(array, len);
    
    printf("after heap sort: \n");
    print_array(array, len);
    
    free(array);
}

int main(int argc, const char * argv[]) {
    test_insertion_sort();

    test_selection_sort();

    test_bubble_sort();

    test_shell_sort();

    test_merge_sort();
    
    test_heap_sort();
    
    return 0;
}