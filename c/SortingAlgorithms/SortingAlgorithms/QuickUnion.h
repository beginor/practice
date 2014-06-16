//
//  QuickUnion.h
//  SortingAlgorithms
//
//  Created by mavericks on 6/16/14.
//  Copyright (c) 2014 mavericks. All rights reserved.
//

#ifndef SortingAlgorithms_QuickUnion_h
#define SortingAlgorithms_QuickUnion_h

#include <stdlib.h>

typedef struct {
    
    int * arr;
    int * sz;
    int N;
    
} QuickUnion;

QuickUnion * QuickUnion_create(const int N);

int QuickUnion_connected(QuickUnion * qu, const int p, const int q);

void QuickUnion_union(QuickUnion * qu, const int p, const int q);

#endif
