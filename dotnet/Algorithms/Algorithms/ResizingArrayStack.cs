using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms {

    public class ResizingArrayStack<TItem> : IEnumerable<TItem> {

        private TItem[] a;
        private int n;

        public ResizingArrayStack() {
            a = new TItem[2];
        }

        public bool IsEmpty {
            get {
                return n == 0;
            }
        }

        public int Size {
            get {
                return n;
            }
        }

        public IEnumerator<TItem> GetEnumerator() {
            return new ReverseArrayIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        private void Resize(int capacity) {
            Debug.Assert(capacity >= n);
            var temp = new TItem[capacity];
            for (int i = 0; i < n; i++) {
                temp[i] = a[i];
            }
            a = temp;
        }

        public void Push(TItem item) {
            if (n == a.Length) {
                Resize(2 * a.Length); // double size of array if necessary
            }
            a[n++] = item; // add item
        }

        public TItem Pop() {
            if (IsEmpty) {
                throw new InvalidOperationException("Stack underflow");
            }
            TItem item = a[n - 1];
            a[n - 1] = default(TItem); // to avoid loitering
            n--;
            // shrink size of array if necessary
            if (n > 0 && n == a.Length / 4) {
                Resize(a.Length / 2);
            }
            return item;
        }

        public TItem Peek() {
            if (IsEmpty) {
                throw new InvalidOperationException("Stack underflow");
            }
            return a[n - 1];
        }

        private class ReverseArrayIterator : IEnumerator<TItem> {

            private int i;
            private ResizingArrayStack<TItem> stack;

            public ReverseArrayIterator(ResizingArrayStack<TItem> stack) {
                this.stack = stack;
                i = this.stack.n;
            }

            public void Dispose() {
                i = 0;
                stack = null;
            }

            public bool MoveNext() {
                if (i <= 0) {
                    return false;
                }
                i = i - 1;
                return true;
            }

            public void Reset() {
                i = stack.n;
            }

            public TItem Current {
                get {
                    return stack.a[i];
                }
            }

            object IEnumerator.Current {
                get {
                    return Current;
                }
            }
        }
    }
}
