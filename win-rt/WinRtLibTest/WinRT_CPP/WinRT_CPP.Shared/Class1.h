#pragma once

#include <collection.h>
#include <amp.h>
#include <amp_math.h>
#include <algorithm>

using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;

namespace WinRT_CPP {

    public delegate void PrimeFoundHandler(int result);

    public ref class Class1 sealed {

    public:
        Class1();
        // Synchronous method. 
        IVector<double>^  ComputeResult(double input);

        // Asynchronous methods
        IAsyncOperationWithProgress<IVector<int>^, double>^ GetPrimesOrdered(int first, int last);
        IAsyncActionWithProgress<double>^ GetPrimesUnordered(int first, int last);

        event PrimeFoundHandler^ primeFoundEvent;
    };
}
