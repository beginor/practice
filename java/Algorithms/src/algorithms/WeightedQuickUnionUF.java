package algorithms;

/**
 * Created by beginor on 13-11-19.
 */
public class WeightedQuickUnionUF {

    private int[] id;
    private int[] sz;

    public WeightedQuickUnionUF(int n) {
        id = new int[n];
        sz = new int[n];
        for (int i = 0; i < n; i++) {
            id[i] = i;
            sz[i] = 1;
        }
    }

    private int root(int i) {
        while (i != id[i]) {
            //id[i] = id[id[i]];
            i = id[i];
        }
        return i;
    }

    public boolean connected(int p, int q) {
        return root(p) == root(q);
    }

    public void union(int p, int q) {
        int i = root(p);
        int j = root(q);
        if (sz[i] < sz[j]) {
            id[i] = j;
            sz[j] += sz[i];
        }
        else {
            id[j] = i;
            sz[i] += sz[j];
        }
    }

    private void printId() {
        for (int i = 0; i < id.length; i++) {
            int item = id[i];
            System.out.print(item);
            if (i < id.length - 1) {
                System.out.print(" ");
            }
        }
        System.out.println();
    }

    public static void main(String[] args) {
        WeightedQuickUnionUF uf = new WeightedQuickUnionUF(10);
        uf.union(6, 8);
        uf.printId();
        uf.union(0, 5);
        uf.printId();
        uf.union(7, 2);
        uf.printId();
        uf.union(0, 8);
        uf.printId();
        uf.union(2, 3);
        uf.printId();
        uf.union(9, 1);
        uf.printId();
        uf.union(3, 1);
        uf.printId();
        uf.union(3, 4);
        uf.printId();
        uf.union(0, 9);
        uf.printId();
    }
}
