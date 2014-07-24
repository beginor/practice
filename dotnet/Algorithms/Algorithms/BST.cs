using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms {

    public class BST<TKey, TValue> where TKey : IComparable<TKey> {

        private Node root;

        public bool IsEmpty {
            get {
                return Count == 0;
            }
        }

        public int Count {
            get {
                return Size(root);
            }
        }

        private int Size(Node x) {
            if (x == null) {
                return 0;
            }
            return x.N;
        }

        public bool Contains(TKey key) {
            return !EqualityComparer<TValue>.Default.Equals(Get(key), default(TValue));
        }

        public TValue Get(TKey key) {
            return Get(root, key);
        }

        private TValue Get(Node x, TKey key) {
            if (x == null) {
                return default(TValue);
            }
            int cmp = key.CompareTo(x.Key);
            if (cmp < 0) {
                return Get(x.Left, key);
            }
            if (cmp > 0) {
                return Get(x.Right, key);
            }
            return x.Val;
        }

        public void Put(TKey key, TValue val) {
            if (EqualityComparer<TValue>.Default.Equals(val, default(TValue))) {
                Delete(key);
                return;
            }
            root = Put(root, key, val);
            Debug.Assert(Check());
        }

        private Node Put(Node x, TKey key, TValue val) {
            if (x == null) {
                return new Node {
                                    Key = key, Val = val, N = 1
                                };
            }
            int cmp = key.CompareTo(x.Key);
            if (cmp < 0) {
                x.Left = Put(x.Left, key, val);
            }
            else if (cmp > 0) {
                x.Right = Put(x.Right, key, val);
            }
            else {
                x.Val = val;
            }
            x.N = 1 + Size(x.Left) + Size(x.Right);
            return x;
        }

        public void DeleteMin() {
            if (IsEmpty) {
                throw new InvalidOperationException("Symbol table underflow");
            }
            root = DeleteMin(root);
            Debug.Assert(Check());
        }

        private Node DeleteMin(Node x) {
            if (x.Left == null) {
                return x.Right;
            }
            x.Left = DeleteMin(x.Left);
            x.N = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        public void DeleteMax() {
            if (IsEmpty) {
                throw new InvalidOperationException("Symbol table underflow");
            }
            root = DeleteMax(root);
            Debug.Assert(Check());
        }

        private Node DeleteMax(Node x) {
            if (x.Right == null) {
                return x.Left;
            }
            x.Right = DeleteMax(x.Right);
            x.N = Size(x.Left) + Size(x.Left) + 1;
            return x;
        }

        public void Delete(TKey key) {
            root = Delete(root, key);
            Debug.Assert(Check());
        }

        private Node Delete(Node x, TKey key) {
            if (x == null) {
                return null;
            }
            int cmp = key.CompareTo(x.Key);
            if (cmp < 0) {
                x.Left = Delete(x.Left, key);
            }
            else if (cmp > 0) {
                x.Right = Delete(x.Right, key);
            }
            else {
                if (x.Right == null) {
                    return x.Left;
                }
                if (x.Left == null) {
                    return x.Right;
                }
                Node t = x;
                x = Min(t.Right);
                x.Right = DeleteMin(t.Right);
                x.Left = t.Left;
            }
            x.N = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        public TKey Min() {
            if (IsEmpty) {
                return default(TKey);
            }
            return Min(root).Key;
        }

        private Node Min(Node x) {
            if (x.Left == null) {
                return x;
            }
            return Min(x.Left);
        }

        public TKey Max() {
            if (IsEmpty) {
                return default(TKey);
            }
            return Max(root).Key;
        }

        private Node Max(Node x) {
            if (x.Right == null) {
                return x;
            }
            return Max(x.Right);
        }

        public TKey Floor(TKey key) {
            Node x = Floor(root, key);
            if (x == null) {
                return default(TKey);
            }
            return x.Key;
        }

        private Node Floor(Node x, TKey key) {
            if (x == null) {
                return null;
            }
            int cmp = key.CompareTo(x.Key);
            if (cmp == 0) {
                return x;
            }
            if (cmp < 0) {
                return Floor(x.Left, key);
            }
            Node t = Floor(x.Right, key);
            if (t != null) {
                return t;
            }
            return x;
        }

        public TKey Ceiling(TKey key) {
            Node x = Ceiling(root, key);
            if (x == null) {
                return default(TKey);
            }
            return x.Key;
        }

        private Node Ceiling(Node x, TKey key) {
            if (x == null) {
                return null;
            }
            int cmp = key.CompareTo(x.Key);
            if (cmp == 0) {
                return x;
            }
            if (cmp < 0) {
                Node t = Ceiling(x.Left, key);
                if (t != null) {
                    return t;
                }
                return x;
            }
            return Ceiling(x.Right, key);
        }

        public TKey Select(int k) {
            if (k < 0 || k >= Count) {
                return default(TKey);
            }
            Node x = Select(root, k);
            return x.Key;
        }

        // Return key of rank k. 
        private Node Select(Node x, int k) {
            if (x == null) {
                return null;
            }
            int t = Size(x.Left);
            if (t > k) {
                return Select(x.Left, k);
            }
            if (t < k) {
                return Select(x.Right, k - t - 1);
            }
            return x;
        }

        public int Rank(TKey key) {
            return Rank(key, root);
        }

        // Number of keys in the subtree less than key.
        private int Rank(TKey key, Node x) {
            if (x == null) {
                return 0;
            }
            int cmp = key.CompareTo(x.Key);
            if (cmp < 0) {
                return Rank(key, x.Left);
            }
            if (cmp > 0) {
                return 1 + Size(x.Left) + Rank(key, x.Right);
            }
            return Size(x.Left);
        }

        public IEnumerable<TKey> Keys() {
            return Keys(Min(), Max());
        }

        public IEnumerable<TKey> Keys(TKey lo, TKey hi) {
            var queue = new Queue<TKey>();
            Keys(root, queue, lo, hi);
            return queue;
        }

        private void Keys(Node x, Queue<TKey> queue, TKey lo, TKey hi) {
            if (x == null) {
                return;
            }
            int cmplo = lo.CompareTo(x.Key);
            int cmphi = hi.CompareTo(x.Key);
            if (cmplo < 0) {
                Keys(x.Left, queue, lo, hi);
            }
            if (cmplo <= 0 && cmphi >= 0) {
                queue.Enqueue(x.Key);
            }
            if (cmphi > 0) {
                Keys(x.Right, queue, lo, hi);
            }
        }

        public int Size(TKey lo, TKey hi) {
            if (lo.CompareTo(hi) > 0) {
                return 0;
            }
            if (Contains(hi)) {
                return Rank(hi) - Rank(lo) + 1;
            }
            return Rank(hi) - Rank(lo);
        }

        public int Height() {
            return Height(root);
        }

        private int Height(Node x) {
            if (x == null) {
                return -1;
            }
            return 1 + Math.Max(Height(x.Left), Height(x.Right));
        }

        public IEnumerable<TKey> LevelOrder() {
            var keys = new Queue<TKey>();
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0) {
                Node x = queue.Dequeue();
                if (x == null) {
                    continue;
                }
                keys.Enqueue(x.Key);
                queue.Enqueue(x.Left);
                queue.Enqueue(x.Right);
            }
            return keys;
        }

        private bool Check() {
            if (!IsBST()) {
                Console.WriteLine("Not in symmetric order");
            }
            if (!IsSizeConsistent()) {
                Console.WriteLine("Subtree counts not consistent");
            }
            if (!IsRankConsistent()) {
                Console.WriteLine("Ranks not consistent");
            }
            return IsBST() && IsSizeConsistent() && IsRankConsistent();
        }

        private bool IsBST() {
            return IsBST(root, default(TKey), default(TKey));
        }

        private bool IsBST(Node x, TKey min, TKey max) {
            if (x == null) {
                return true;
            }
            if (min != null && x.Key.CompareTo(min) <= 0) {
                return false;
            }
            if (max != null && x.Key.CompareTo(max) >= 0) {
                return false;
            }
            return IsBST(x.Left, min, x.Key) && IsBST(x.Right, x.Key, max);
        }

        private bool IsSizeConsistent() {
            return IsSizeConsistent(root);
        }

        private bool IsSizeConsistent(Node x) {
            if (x == null) {
                return true;
            }
            if (x.N != Size(x.Left) + Size(x.Right) + 1) {
                return false;
            }
            return IsSizeConsistent(x.Left) && IsSizeConsistent(x.Right);
        }

        private bool IsRankConsistent() {
            for (int i = 0; i < Count; i++) {
                if (i != Rank(Select(i))) {
                    return false;
                }
            }
            foreach (TKey key in Keys()) {
                if (key.CompareTo(Select(Rank(key))) != 0) {
                    return false;
                }
            }
            return true;
        }

        private class Node {
            public int N;
            public TKey Key;
            public Node Left, Right;
            public TValue Val;
        }
    }
}
