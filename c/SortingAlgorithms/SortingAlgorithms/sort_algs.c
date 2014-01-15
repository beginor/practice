#include <stdlib.h>

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

void merge(int arr[], int aux[], int lo, int mid, int hi) {
    for (int k = lo; k <= hi; k++) {
        aux[k] = arr[k];
    }
    
    int i = lo, j = mid + 1;
    for (int k = lo; k <= hi; k++) {
        if (i > mid) {
            arr[k] = aux[j++];
        }
        else if (j > hi) {
            arr[k] = aux[i++];
        }
        else if (arr[j] > arr[i]) {
            arr[k] = aux[j++];
        }
        else {
            arr[k] = aux[i++];
        }
    }
}

void merge_sort_impl(int arr[], int aux[], int lo, int hi) {
    if (lo >= hi) {
        return;
    }
    int mid = (lo + hi) / 2;
    merge_sort_impl(arr, aux, lo, mid);
    merge_sort_impl(arr, aux, mid + 1, hi);
    
    if (arr[mid + 1] > arr[mid]) {
        merge(arr, aux, lo, mid, hi);
    }
}

void merge_sort(int arr[], int N) {
    int * aux;
    aux = (int *)malloc(sizeof(int) * N);
    merge_sort_impl(arr, aux, 0, N - 1);
    free(aux);
}

void swap(int arr[], int i, int j) {
    int tmp = arr[i];
    arr[i] = arr[j];
    arr[j] = tmp;
}