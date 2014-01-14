#include "sort_algs.h"
#include "sort_algs_helpers.h"

void insertion_sort(int arr[], int N) {
    for (int i = 1; i < N; i++) {
        for (int j = i; j > 0 && arr[j] > arr[j - 1]; j--) {
            swap(arr, j, j - 1);
            //print_array(arr, N);
        }
    }
}

void selection_sort(int arr[], int N) {
    for (int i = 0; i < N; i++) {
        int k = i;
        for (int j = i + 1; j < N; j++) {
            if (arr[k] < arr[j]) {
                k = j;
            }
        }
        swap(arr, i, k);
    }
}

void bubble_sort(int arr[], int N) {
    for (int i = 0; i < N; i++) {
        int swapped = 0;
        for (int j = N; j > i; j--) {
            if (arr[j] > arr[j - 1]) {
                swap(arr, j, j - 1);
                swapped = 1;
            }
        }
        if (swapped == 0) {
            break;
        }
    }
}

void shell_sort(int arr[], int N) {
    int h = 1;
    while (3 * h < N) { h = h * 3 + 1; }

    while (h > 0) {
        for (int i = h; i < N; i++) {
            for (int j = i; j >= h && arr[j] > arr[j - h]; j -= h) {
                swap(arr, j, j - h);
            }
        }
        h = h / 3;
    }
}

void swap(int arr[], int i, int j) {
    int tmp = arr[i];
    arr[i] = arr[j];
    arr[j] = tmp;
}