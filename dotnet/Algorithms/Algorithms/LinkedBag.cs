using System.Collections;
using System.Collections.Generic;

namespace Algorithms {

    public class LinkedBag<TItem> : IEnumerable<TItem> {

        private int n;
        private Node<TItem> first;

        public LinkedBag() {
            first = null;
            n = 0;
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

        public void Add(TItem item) {
            Node<TItem> oldfirst = first;
            first = new Node<TItem> { Item = item, Next = oldfirst };
            n++;
        }

        public IEnumerator<TItem> GetEnumerator() {
            return new ListIterator<TItem>(first);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

    }
}