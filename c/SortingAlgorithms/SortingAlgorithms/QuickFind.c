//
//  QuickFind.c
//  SortingAlgorithms
//
//  Created by mavericks on 6/16/14.
//  Copyright (c) 2014 mavericks. All rights reserved.
//

#include <stdio.h>
#include <stdlib.h>

#include "QuickFind.h"

QuickFind * QuickFind_create(const int N) {
    QuickFind * result = malloc(sizeof(QuickFind *));
    result->N = N;
    for (int i = 0; i < N; i++) {
        result->arr[i] = i;
    }
    return result;
}

int QuickFind_connected(QuickFind * qf, const int p, const int q) {
    if (qf->arr[p] == qf->arr[q]) {
        return 1;
    }
    return 0;
}

void QuickFind_union(QuickFind * qf, const int p, const int q) {
    int pid = qf->arr[p];
    int qid = qf->arr[q];
    for (int i = 0; i < qf->N; i++) {
        if (qf->arr[i] == pid) {
            qf->arr[i] = qid;
        }
    }
}