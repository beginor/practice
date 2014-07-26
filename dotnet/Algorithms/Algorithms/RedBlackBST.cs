using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms {

    public class RedBlackBST<TKey, TValue> where TKey : IComparable<TKey> {

        private const bool Red = true;
        private const bool Black = false;

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

        private int Size(Node h) {
            if (h == null) {
                return 0;
            }
            return h.N;
        }

        public bool Contains(TKey key) {
            return !EqualityComparer<TValue>.Default.Equals(Get(key), default(TValue));
        }

        public TValue Get(TKey key) {
            return Get(root, key);
        }

        private TValue Get(Node h, TKey key) {
            if (h == null) {
                return default(TValue);
            }
            int cmp = key.CompareTo(h.Key);
            if (cmp < 0) {
                return Get(h.Left, key);
            }
            if (cmp > 0) {
                return Get(h.Right, key);
            }
            return h.Val;
        }

        public void Put(TKey key, TValue val) {
            root = Put(root, key, val);
            root.Color = Black;
            Debug.Assert(Check());
        }

        private Node Put(Node h, TKey key, TValue val) {
            if (h == null) {
                return new Node(key, val, Red, 1);
            }
            int cmp = key.CompareTo(h.Key);
            if (cmp < 0) {
                h.Left = Put(h.Left, key, val);
            }
            else if (cmp > 0) {
                h.Right = Put(h.Right, key, val);
            }
            else {
                h.Val = val;
            }

            if (IsRed(h.Right) && !IsRed(h.Left)) {
                h = RotateLeft(h);
            }
            if (IsRed(h.Left) && IsRed(h.Left.Left)) {
                h = RotateRight(h);
            }
            if (IsRed(h.Left) && IsRed(h.Right)) {
                FlipColors(h);
            }

            h.N = Size(h.Left) + Size(h.Right) + 1;

            return h;
        }

        public void DeleteMin() {
            if (IsEmpty) {
                throw new InvalidOperationException("Symbol table underflow");
            }
            if (!IsRed(root.Left) && !IsRed(root.Right)) {
                root.Color = Red;
            }
            root = DeleteMin(root);
            if (!IsEmpty) {
                root.Color = Black;
            }
            Debug.Assert(Check());
        }

        private Node DeleteMin(Node h) {
            if (h.Left == null) {
                return null;
            }
            if (!IsRed(h.Left) && !IsRed(h.Left.Left)) {
                h = MoveRedLeft(h);
            }
            h.Left = DeleteMin(h.Left);
            
            return Balance(h);
        }

        public void DeleteMax() {
            if (IsEmpty) {
                throw new InvalidOperationException("Symbol table underflow");
            }
            if (!IsRed(root.Left) && !IsRed(root.Right)) {
                root.Color = Red;
            }
            root = DeleteMax(root);
            if (!IsEmpty) {
                root.Color = Black;
            }
            Debug.Assert(Check());
        }

        private Node DeleteMax(Node h) {
            if (IsRed(h.Left)) {
                h = RotateRight(h);
            }
            if (h.Right == null) {
                return null;
            }
            if (!IsRed(h.Right) && !IsRed(h.Right.Left)) {
                h = MoveRedLeft(h);
            }
            h.Right = DeleteMax(h.Right);
            return Balance(h);
        }

        public void Delete(TKey key) {
            if (!Contains(key)) {
                throw new InvalidOperationException("symbol table does not contain {0}" + key);
            }
            if (!IsRed(root.Left) && !IsRed(root.Right)) {
                root.Color = Red;
            }
            root = Delete(root, key);
            if (!IsEmpty) {
                root.Color = Black;
            }
            Debug.Assert(Check());
        }

        private Node Delete(Node h, TKey key) {
            Debug.Assert(Contains(key));
            if (key.CompareTo(h.Key) < 0) {
                if (!IsRed(h.Left) && !IsRed(h.Left.Left)) {
                    h = MoveRedLeft(h);
                }
                h.Left = Delete(h.Left, key);
            }
            else {
                if (IsRed(h.Left)) {
                    h = RotateRight(h);
                }
                if (key.CompareTo(h.Key) == 0 && h.Right == null) {
                    return null;
                }
                if (!IsRed(h.Right) && !IsRed(h.Right.Left)) {
                    h = MoveRedRight(h);
                }
                if (key.CompareTo(h.Key) == 0) {
                    Node x = Min(h.Right);
                    h.Key = x.Key;
                    h.Val = x.Val;
                    h.Right = DeleteMin(h.Right);
                }
                else {
                    h.Right = Delete(h.Right, key);
                }
            }
            return Balance(h);
        }

        private Node RotateLeft(Node h) {
            Debug.Assert(h != null && IsRed(h.Right));
            Node x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.Color = x.Left.Color;
            h.Color = Red;
            x.N = h.N;
            h.N = Size(h.Left) + Size(h.Right) + 1;
            return x;
        }

        private Node RotateRight(Node h) {
            Debug.Assert(h != null && IsRed(h.Left));
            Node x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.Color = x.Right.Color;
            h.Color = Red;
            x.N = h.N;
            h.N = Size(h.Left) + Size(h.Right) + 1;
            return x;
        }

        private void FlipColors(Node h) {
            Debug.Assert(h != null && h.Left != null && h.Right != null);
            Debug.Assert((!IsRed(h) && IsRed(h.Left) && IsRed(h.Right))
                || (IsRed(h) && !IsRed(h.Left) && !IsRed(h.Right)));
            h.Color = !h.Color;
            h.Left.Color = !h.Left.Color;
            h.Right.Color = !h.Right.Color;
        }

        private Node MoveRedLeft(Node h) {
            Debug.Assert(h != null);
            Debug.Assert(IsRed(h) && !IsRed(h.Left) && !IsRed(h.Left.Left));

            FlipColors(h);
            if (IsRed(h.Right.Left)) {
                h.Right = RotateRight(h.Right);
                h = RotateLeft(h);
            }
            return h;
        }

        private Node MoveRedRight(Node h) {
            Debug.Assert(h != null);
            Debug.Assert(IsRed(h) && !IsRed(h.Right) && !IsRed(h.Right.Left));
            FlipColors(h);
            if (IsRed(h.Left.Left)) {
                h = RotateRight(h);
            }
            return h;
        }

        private Node Balance(Node h) {
            Debug.Assert(h != null);
            if (IsRed(h.Right)) {
                h = RotateLeft(h);
            }
            if (IsRed(h.Left) && IsRed(h.Left.Left)) {
                h = RotateRight(h);
            }
            if (IsRed(h.Left) && IsRed(h.Right)) {
                FlipColors(h);
            }
            h.N = Size(h.Left) + Size(h.Right) + 1;
            return h;
        }

        private static bool IsRed(Node h) {
            if (h == null) {
                return false;
            }
            return h.Color == Red;
        }

        public TKey Min() {
            if (IsEmpty) {
                return default(TKey);
            }
            return Min(root).Key;
        }

        private Node Min(Node h) {
            if (h.Left == null) {
                return h;
            }
            return Min(h.Left);
        }

        public TKey Max() {
            if (IsEmpty) {
                return default(TKey);
            }
            return Max(root).Key;
        }

        private Node Max(Node h) {
            if (h.Right == null) {
                return h;
            }
            return Max(h.Right);
        }

        public TKey Floor(TKey key) {
            Node h = Floor(root, key);
            if (h == null) {
                return default(TKey);
            }
            return h.Key;
        }

        private Node Floor(Node h, TKey key) {
            if (h == null) {
                return null;
            }
            int cmp = key.CompareTo(h.Key);
            if (cmp == 0) {
                return h;
            }
            if (cmp < 0) {
                return Floor(h.Left, key);
            }
            Node t = Floor(h.Right, key);
            if (t != null) {
                return t;
            }
            return h;
        }

        public TKey Ceiling(TKey key) {
            Node h = Ceiling(root, key);
            if (h == null) {
                return default(TKey);
            }
            return h.Key;
        }

        private Node Ceiling(Node h, TKey key) {
            if (h == null) {
                return null;
            }
            int cmp = key.CompareTo(h.Key);
            if (cmp == 0) {
                return h;
            }
            if (cmp < 0) {
                Node t = Ceiling(h.Left, key);
                if (t != null) {
                    return t;
                }
                return h;
            }
            return Ceiling(h.Right, key);
        }

        public TKey Select(int k) {
            if (k < 0 || k >= Count) {
                return default(TKey);
            }
            Node h = Select(root, k);
            return h.Key;
        }

        // Return key of rank k. 
        private Node Select(Node h, int k) {
            if (h == null) {
                return null;
            }
            int t = Size(h.Left);
            if (t > k) {
                return Select(h.Left, k);
            }
            if (t < k) {
                return Select(h.Right, k - t - 1);
            }
            return h;
        }

        public int Rank(TKey key) {
            return Rank(key, root);
        }

        // Number of keys in the subtree less than key.
        private int Rank(TKey key, Node h) {
            if (h == null) {
                return 0;
            }
            int cmp = key.CompareTo(h.Key);
            if (cmp < 0) {
                return Rank(key, h.Left);
            }
            if (cmp > 0) {
                return 1 + Size(h.Left) + Rank(key, h.Right);
            }
            return Size(h.Left);
        }

        public IEnumerable<TKey> Keys() {
            return Keys(Min(), Max());
        }

        public IEnumerable<TKey> Keys(TKey lo, TKey hi) {
            var queue = new Queue<TKey>();
            Keys(root, queue, lo, hi);
            return queue;
        }

        private void Keys(Node h, Queue<TKey> queue, TKey lo, TKey hi) {
            if (h == null) {
                return;
            }
            int cmplo = lo.CompareTo(h.Key);
            int cmphi = hi.CompareTo(h.Key);
            if (cmplo < 0) {
                Keys(h.Left, queue, lo, hi);
            }
            if (cmplo <= 0 && cmphi >= 0) {
                queue.Enqueue(h.Key);
            }
            if (cmphi > 0) {
                Keys(h.Right, queue, lo, hi);
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

        public int Height {
            get {
                return NodeHeight(root);
            }
        }

        private int NodeHeight(Node h) {
            if (h == null) {
                return -1;
            }
            return 1 + Math.Max(NodeHeight(h.Left), NodeHeight(h.Right));
        }

        public IEnumerable<TKey> LevelOrder() {
            var keys = new Queue<TKey>();
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0) {
                Node h = queue.Dequeue();
                if (h == null) {
                    continue;
                }
                keys.Enqueue(h.Key);
                queue.Enqueue(h.Left);
                queue.Enqueue(h.Right);
            }
            return keys;
        }

        private bool Check() {
            var isBst = IsBST();
            var isSizeConsistent = IsSizeConsistent();
            var isRankConsistent = IsRankConsistent();
            var isBalanced = IsBalanced();
            var is23 = Is23();
            if (!isBst) {
                Console.WriteLine("Not in symmetric order");
            }
            
            if (!isSizeConsistent) {
                Console.WriteLine("Subtree counts not consistent");
            }
            
            if (!isRankConsistent) {
                Console.WriteLine("Ranks not consistent");
            }
            
            if (!is23) {
                Console.WriteLine("Not a 2-3 tree");
            }
            
            if (!isBalanced) {
                Console.WriteLine("Not balanced");
            }
            return isBst && isSizeConsistent && isRankConsistent && is23 && isBalanced;
        }

        private bool IsBST() {
            return IsBST(root, default(TKey), default(TKey));
        }

        private bool IsBST(Node h, TKey min, TKey max) {
            if (h == null) {
                return true;
            }
            if (!EqualityComparer<TKey>.Default.Equals(min, default(TKey)) && h.Key.CompareTo(min) <= 0) {
                return false;
            }
            if (!EqualityComparer<TKey>.Default.Equals(max, default(TKey)) && h.Key.CompareTo(max) >= 0) {
                return false;
            }
            return IsBST(h.Left, min, h.Key) && IsBST(h.Right, h.Key, max);
        }

        private bool IsSizeConsistent() {
            return IsSizeConsistent(root);
        }

        private bool IsSizeConsistent(Node h) {
            if (h == null) {
                return true;
            }
            if (h.N != Size(h.Left) + Size(h.Right) + 1) {
                return false;
            }
            return IsSizeConsistent(h.Left) && IsSizeConsistent(h.Right);
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

        private bool Is23() {
            return Is23(root);
        }

        private bool Is23(Node x) {
            if (x == null) {
                return true;
            }
            if (IsRed(x.Right)) {
                return false;
            }
            if (x != root && IsRed(x) && IsRed(x.Left)) {
                return false;
            }
            return Is23(x.Left) && Is23(x.Right);
        }

        private bool IsBalanced() {
            int black = 0;     // number of black links on path from root to min
            Node x = root;
            while (x != null) {
                if (!IsRed(x)) {
                    black++;
                }
                x = x.Left;
            }
            return IsBalanced(root, black);
        }

        // does every path from the root to a leaf have the given number of black links?
        private bool IsBalanced(Node x, int black) {
            if (x == null) {
                return black == 0;
            }
            if (!IsRed(x)) {
                black--;
            }
            return IsBalanced(x.Left, black) && IsBalanced(x.Right, black);
        }

        private class Node {
            public int N;
            public TKey Key;
            public Node Left, Right;
            public TValue Val;
            public bool Color;

            public Node(TKey key, TValue val, bool color, int n) {
                Key = key;
                Val = val;
                Color = color;
                N = n;
            }
        }

    }

}