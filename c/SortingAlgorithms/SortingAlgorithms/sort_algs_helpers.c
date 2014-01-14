#include "sort_algs_helpers.h"
#include <stdio.h>
#include <stdlib.h>

void print_array(int arr[], int N) {
    int i = 0;
    while (i < N) {
        printf("%3d", arr[i]);
        if (i < N - 1) {
            printf(" ");
        }
        i++;
    }
    printf("\n");
}

void fill_random_array(int arr[], int N) {
    const int min = 1;
    const int max = 100;
    for (int i = 0; i < N; i++) {
        arr[i] = rand() % (max - min) + min;
    }
}