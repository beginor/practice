namespace Algorithms {

    public class QuickFindUF {

        private readonly int[] id;
        private int count;

        public QuickFindUF(int n) {
            count = n;
            id = new int[n];
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
            return id[p];
        }

        public bool Connected(int p, int q) {
            return id[p] == id[q];
        }

        public void Union(int p, int q) {
            if (Connected(p, q)) {
                return;
            }
            int pid = id[p];
            for (int i = 0; i < id.Length; i++) {
                if (id[i] == pid) {
                    id[i] = id[q];
                }
            }
            count--;
        }
    }
}
