//
//  QuickFind.h
//  SortingAlgorithms
//
//  Created by mavericks on 6/16/14.
//  Copyright (c) 2014 mavericks. All rights reserved.
//
#ifndef SortingAlgorithms_QuickFind_h
#define SortingAlgorithms_QuickFind_h

#include <stdlib.h>

typedef struct _Quickfind {
    
    int* arr;
    int N;
    
} QuickFind;

QuickFind * QuickFind_create(const int N);

int QuickFind_connected(QuickFind * qf, const int p, const int q);

void QuickFind_union(QuickFind * qf, const int p, const int q);

#endif
