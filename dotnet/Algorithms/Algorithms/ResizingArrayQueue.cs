using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms {

    public class ResizingArrayQueue<TItem> : IEnumerable<TItem> {

        private int n;
        private int first;
        private int last;
        private TItem[] q;

        public ResizingArrayQueue() {
            // cast needed since no generic array creation in Java
            q = new TItem[2];
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

        private void Resize(int max) {
            Debug.Assert(max >= n);
            var temp = new TItem[max];
            for (int i = 0; i < n; i++) {
                temp[i] = q[(first + i) % q.Length];
            }
            q = temp;
            first = 0;
            last = n;
        }

        public void Enqueue(TItem item) {
            // double size of array if necessary and recopy to front of array
            if (n == q.Length) {
                Resize(2 * q.Length); // double size of array if necessary
            }
            q[last++] = item; // add item
            if (last == q.Length) {
                last = 0; // wrap-around
            }
            n++;
        }

        public TItem Dequeue() {
            if (IsEmpty) {
                throw new InvalidOperationException("Queue underflow");
            }
            TItem item = q[first];
            q[first] = default(TItem); // to avoid loitering
            n--;
            first++;
            if (first == q.Length) {
                first = 0; // wrap-around
            }
            // shrink size of array if necessary
            if (n > 0 && n == q.Length / 4) {
                Resize(q.Length / 2);
            }
            return item;
        }

        public TItem Peek() {
            if (IsEmpty) {
                throw new InvalidOperationException("Queue underflow");
            }
            return q[first];
        }

        private class ArrayIterator : IEnumerator<TItem> {

            private ResizingArrayQueue<TItem> queue;
            private int i;

            public ArrayIterator(ResizingArrayQueue<TItem> queue) {
                this.queue = queue;
                i = -1;
            }

            public void Dispose() {
                queue = null;
                i = -1;
            }

            public bool MoveNext() {
                if (i < queue.n) {
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
                    return queue.q[i];
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
