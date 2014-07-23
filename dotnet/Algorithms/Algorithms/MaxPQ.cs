using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms {

    public class MaxPQ<TKey> : IEnumerable<TKey> where TKey : IComparable<TKey> {

        private TKey[] pq;
        private int n;
        private readonly IComparer<TKey> comparer;

        public MaxPQ(int capacity) {
            pq = new TKey[capacity + 1];
            n = 0;
        }

        public MaxPQ() : this(1) {
        }

        public MaxPQ(int capacity, IComparer<TKey> comparer) {
            this.comparer = comparer;
            pq = new TKey[capacity + 1];
            n = 0;
        }

        public MaxPQ(IComparer<TKey> comparator) : this(1, comparator) {
        }

        public MaxPQ(TKey[] keys) {
            n = keys.Length;
            pq = new TKey[keys.Length + 1];
            for (int i = 0; i < n; i++) {
                pq[i + 1] = keys[i];
            }
            for (int k = n / 2; k >= 1; k--) {
                Sink(k);
            }
            Debug.Assert(IsMaxHeap());
        }

        private bool IsEmpty {
            get {
                return n == 0;
            }
        }

        public int Size {
            get {
                return n;
            }
        }

        private void Resize(int capacity) {
            Debug.Assert(capacity > n);
            var temp = new TKey[capacity];
            for (int i = 1; i <= n; i++) {
                temp[i] = pq[i];
            }
            pq = temp;
        }

        public void Insert(TKey x) {
            if (n == pq.Length - 1) {
                Resize(2 * pq.Length);
            }

            pq[++n] = x;
            Swim(n);
            Debug.Assert(IsMaxHeap());
        }

        public TKey DelMax() {
            if (IsEmpty) {
                throw new InvalidOperationException("Priority queue under flow");
            }
            Exch(1, n);
            TKey max = pq[n--];
            Sink(1);
            pq[n + 1] = default(TKey);
            if (n > 0 && (n == (pq.Length - 1) / 4)) {
                Resize(pq.Length / 2);
            }
            Debug.Assert(IsMaxHeap());
            return max;
        }

        private void Swim(int k) {
            while (k > 1 && Less(k / 2, k)) {
                Exch(k, k / 2);
                k = k / 2;
            }
        }

        private void Sink(int k) {
            while (2 * k <= n) {
                int j = 2 * k;
                if (j < n && Less(j, j + 1)) {
                    j++;
                }
                if (!Less(k, j)) {
                    break;
                }
                Exch(k, j);
                k = j;
            }
        }

        private bool Less(int i, int j) {
            if (comparer == null) {
                return pq[i].CompareTo(pq[j]) < 0;
            }
            return comparer.Compare(pq[i], pq[j]) < 0;
        }

        private bool IsMaxHeap(int k = 1) {
            if (k > n) {
                return true;
            }
            int left = 2 * k, right = 2 * k + 1;
            if (left <= n && Less(k, left)) {
                return false;
            }
            if (right <= n && Less(k, right)) {
                return false;
            }
            return IsMaxHeap(left) && IsMaxHeap(right);
        }

        private void Exch(int i, int j) {
            var tmp = pq[i];
            pq[i] = pq[j];
            pq[j] = tmp;
        }

        public IEnumerator<TKey> GetEnumerator() {
            return new HeapEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        private class HeapEnumerator : IEnumerator<TKey> {

            private MaxPQ<TKey> copy;

            public HeapEnumerator(MaxPQ<TKey> original) {
                if (original.comparer == null) {
                    copy = new MaxPQ<TKey>(original.Size);
                }
                else {
                    copy = new MaxPQ<TKey>(original.Size, original.comparer);
                }
                for (int i = 1; i <= original.n; i++) {
                    copy.Insert(original.pq[i]);
                }
            }

            public void Dispose() {
                copy = null;
                Current = default(TKey);
            }

            public bool MoveNext() {
                if (copy.IsEmpty) {
                    return false;
                }
                Current = copy.DelMax();
                return true;
            }

            public void Reset() {
                throw new NotSupportedException();
            }

            public TKey Current { get; private set; }

            object IEnumerator.Current {
                get {
                    return Current;
                }
            }
        }
    }
}