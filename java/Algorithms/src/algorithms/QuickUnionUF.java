package algorithms;

/**
 * Created by beginor on 13-11-19.
 */
public class QuickUnionUF {

    private int[] id;

    public QuickUnionUF(int n) {
        id = new int[n];
        for (int i = 0; i < n; i++) {
            id[i] = i;
        }
    }

    private int root(int i) {
        while (i != id[i]) {
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
        id[i] = j;
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
        QuickUnionUF uf = new QuickUnionUF(10);
        uf.union(8, 5);
        uf.printId();
        uf.union(7, 5);
        uf.printId();
        uf.union(4, 1);
        uf.printId();
        uf.union(9, 7);
        uf.printId();
        uf.union(1, 5);
        uf.printId();
        uf.union(0, 9);
        uf.printId();
    }
}
