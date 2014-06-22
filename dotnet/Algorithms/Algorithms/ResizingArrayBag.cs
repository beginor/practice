using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms {

    public class ResizingArrayBag<TItem> : IEnumerable<TItem> {

        private int n;
        private TItem[] a;

        public ResizingArrayBag() {
            a = new TItem[2];
        }

        public IEnumerator<TItem> GetEnumerator() {
            return new ArrayIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
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

        private void Resize(int capacity) {
            Debug.Assert(capacity >= n);
            var temp = new TItem[capacity];
            for (int i = 0; i < n; i++) {
                temp[i] = a[i];
            }
            a = temp;
        }

        public void Add(TItem item) {
            if (n == a.Length) {
                Resize(2 * a.Length); // double size of array if necessary
            }
            a[n++] = item; // add item
        }

        private class ArrayIterator : IEnumerator<TItem> {

            private ResizingArrayBag<TItem> bag;
            private int i;

            public ArrayIterator(ResizingArrayBag<TItem> bag) {
                this.bag = bag;
                i = -1;
            }

            public void Dispose() {
                bag = null;
                i = -1;
            }

            public bool MoveNext() {
                if (i < bag.n) {
                    i++;
                    return true;
                }
                return false;
            }

            public void Reset() {
                i = -1;
            }

            public TItem Current {
                get {
                    return bag.a[i];
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
