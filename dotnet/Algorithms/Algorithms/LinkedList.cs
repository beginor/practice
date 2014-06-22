using System.Collections;
using System.Collections.Generic;

namespace Algorithms {

    class Node<TItem> {
        public TItem Item;
        public Node<TItem> Next;
    }

    class ListIterator<TItem> : IEnumerator<TItem> {

        private Node<TItem> current;
        private Node<TItem> firstItem;
        private bool started;

        public ListIterator(Node<TItem> firstItem) {
            this.firstItem = firstItem;
        }

        public void Dispose() {
            firstItem = null;
            current = null;
        }

        public bool MoveNext() {
            if (!started) {
                current = firstItem;
                started = true;
            }
            else {
                current = current.Next;
            }
            return current != null;
        }

        public void Reset() {
            current = null;
            started = false;
        }

        public TItem Current {
            get {
                return current.Item;
            }
        }

        object IEnumerator.Current {
            get {
                return Current;
            }
        }
    }
}