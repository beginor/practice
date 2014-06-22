namespace Algorithms {

    public class QuickUnionUF {

        private readonly int[] id;
        private int count;

        public QuickUnionUF(int n) {
            id = new int[n];
            count = n;
            for (int i = 0; i < n; i++) {
                id[i] = i;
            }
        }

        public int Count {
            get {
                return count;
            }
        }

        public int Find(int p) {
            while (p != id[p]) {
                p = id[p];
            }
            return p;
        }

        public bool Connected(int p, int q) {
            return Find(p) == Find(q);
        }

        public void Union(int p, int q) {
            int rootP = Find(p);
            int rootQ = Find(q);
            if (rootP == rootQ) {
                return;
            }
            id[rootP] = rootQ;
            count--;
        }
    }
}
