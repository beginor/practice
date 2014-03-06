package algorithms;

/**
 * Created by beginor on 13-11-22.
 */
public class Graph {

    private final int  V;
    private Bag<Integer> adj[];

    public Graph(int V) {
        this.V = V;
        adj = new Bag[V];
        for (int v = 0; v < V; v++) {
            adj[v] = new Bag<Integer>();
        }
    }

    public void addEdge(int v, int w) {
        adj[v].add(w);
        adj[w].add(v);
    }

    public Iterable<Integer> adj(int v) {
        return adj[v];
    }
}
