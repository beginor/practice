namespace Algorithms {

    public class WeightedQuickUnionUF {

        private readonly int[] id;
        private readonly int[] sz;
        private int count;

        public WeightedQuickUnionUF(int n) {
            count = n;
            id = new int[n];
            sz = new int[n];
            for (int i = 0; i < n; i++) {
                id[i] = i;
                sz[i] = 1;
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

            // make smaller root point to larger one
            if (sz[rootP] < sz[rootQ]) {
                id[rootP] = rootQ;
                sz[rootQ] += sz[rootP];
            }
            else {
                id[rootQ] = rootP;
                sz[rootP] += sz[rootQ];
            }
            count--;
        }
    }
}
