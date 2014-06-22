using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Algorithms {

    /// <summary>
    ///     Linked list stack.
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public class LinkedStack<TItem> : IEnumerable<TItem> {

        private Node<TItem> first;
        private int n;

        public LinkedStack() {
            first = null;
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

        public void Push(TItem item) {
            Node<TItem> oldfirst = first;
            first = new Node<TItem>();
            first.Item = item;
            first.Next = oldfirst;
            n++;
            //assert check();
        }

        public TItem Pop() {
            if (IsEmpty) {
                throw new InvalidOperationException("Stack underflow");
            }
            TItem item = first.Item; // save item to return
            first = first.Next; // delete first node
            n--;
            //assert check();
            return item; // return the saved item
        }

        public TItem Peek() {
            if (IsEmpty) {
                throw new InvalidOperationException("Stack underflow");
            }
            return first.Item;
        }

        public override string ToString() {
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
            }
            else if (n == 1) {
                if (first == null) {
                    return false;
                }
                if (first.Next != null) {
                    return false;
                }
            }
            else {
                if (first.Next == null) {
                    return false;
                }
            }

            // check internal consistency of instance variable N
            int numberOfNodes = 0;
            for (Node<TItem> x = first; x != null; x = x.Next) {
                numberOfNodes++;
            }
            if (numberOfNodes != n) {
                return false;
            }

            return true;
        }

    }
}
