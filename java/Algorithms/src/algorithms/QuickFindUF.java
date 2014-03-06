package algorithms;

/**
 * Created by beginor on 13-11-19.
 */
public class QuickFindUF {

    private int[] id;

    public QuickFindUF(int n) {
        id = new int[n];
        for (int i = 0; i < n; i++) {
            id[i] = i;
        }
    }

    public boolean connected(int p, int q) {
        return id[p] == id[q];
    }

    public void union(int p, int q) {
        int pid = id[p];
        int qid = id[q];
        for (int i = 0; i < id.length; i++) {
            if (id[i] == pid) {
                id[i] = qid;
            }
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
        QuickFindUF uf = new QuickFindUF(10);
        uf.union(5, 6);
        uf.printId();
        uf.union(9, 0);
        uf.printId();
        uf.union(8, 3);
        uf.printId();
        uf.union(8, 1);
        uf.printId();
        uf.union(9, 6);
        uf.printId();
        uf.union(4, 8);
        uf.printId();
    }
}
