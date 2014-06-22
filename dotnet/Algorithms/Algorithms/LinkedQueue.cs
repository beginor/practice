using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Algorithms {

    public class LinkedQueue<TItem> : IEnumerable<TItem> {

        private Node<TItem> first;
        private Node<TItem> last;
        private int n;

        public LinkedQueue() {
            first = null;
            last = null;
            n = 0;
            Debug.Assert(Check());
        }

        public bool IsEmpty {
            get {
                return first == null;
            }
        }

        public int Size {
            get {
                return n;
            }
        }

        public IEnumerator<TItem> GetEnumerator() {
            return new ListIterator<TItem>(first);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public TItem Peek() {
            if (IsEmpty) {
                throw new InvalidOperationException("Queue underflow");
            }
            return first.Item;
        }

        public void Enqueue(TItem item) {
            Node<TItem> oldlast = last;
            last = new Node<TItem> { Item = item, Next = null };
            if (IsEmpty) {
                first = last;
            }
            else {
                oldlast.Next = last;
            }
            n++;
            Debug.Assert(Check());
        }

        public TItem Dequeue() {
            if (IsEmpty) {
                throw new InvalidOperationException("Queue underflow");
            }
            TItem item = first.Item;
            first = first.Next;
            n--;
            if (IsEmpty) {
                last = null; // to avoid loitering
            }
            Debug.Assert(Check());
            return item;
        }

        public override String ToString() {
            var s = new StringBuilder();
            foreach (TItem item in this) {
                s.Append(item + " ");
            }
            return s.ToString();
        }

        private bool Check() {
            if (n == 0) {
                if (first != null) {
                    return false;
                }
                if (last != null) {
                    return false;
                }
            }
            else if (n == 1) {
                if (first == null || last == null) {
                    return false;
                }
                if (first != last) {
                    return false;
                }
                if (first.Next != null) {
                    return false;
                }
            }
            else {
                if (first == last) {
                    return false;
                }
                if (first.Next == null) {
                    return false;
                }
                if (last.Next != null) {
                    return false;
                }

                // check internal consistency of instance variable N
                int numberOfNodes = 0;
                for (Node<TItem> x = first; x != null; x = x.Next) {
                    numberOfNodes++;
                }
                if (numberOfNodes != n) {
                    return false;
                }

                // check internal consistency of instance variable last
                Node<TItem> lastNode = first;
                while (lastNode.Next != null) {
                    lastNode = lastNode.Next;
                }
                if (last != lastNode) {
                    return false;
                }
            }

            return true;
        }

    }
}
