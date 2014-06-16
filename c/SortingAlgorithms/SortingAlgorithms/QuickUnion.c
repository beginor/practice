//
//  QuickUnion.c
//  SortingAlgorithms
//
//  Created by mavericks on 6/16/14.
//  Copyright (c) 2014 mavericks. All rights reserved.
//

#include <stdio.h>
#include "QuickUnion.h"

QuickUnion * QuickUnion_create(const int N) {
    QuickUnion * result = malloc(sizeof(QuickUnion *));
    result->N = N;
    for (int i = 0; i < N; i++) {
        result->arr[i] = i;
    }
    return result;
}

int QuickUnion_root(QuickUnion * qu, int i) {
    while (qu->arr[i] != i) {
        i = qu->arr[i];
    }
    return i;
}

int QuickUnion_connected(QuickUnion * qu, const int p, const int q) {
    return QuickUnion_root(qu, p) == QuickUnion_root(qu, q);
}

void QuickUnion_union(QuickUnion * qu, const int p, const int q) {
    int i = QuickUnion_root(qu, p);
    int j = QuickUnion_root(qu, q);
    qu->arr[i] = j;
}