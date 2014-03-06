package algorithms;

/**
 * Resizing Array Stack of string.
 * Created by zhangzhimin on 13-11-25.
 */
public class ResizingArrayStackOfString {

    private String[] s;
    private int N;

    public ResizingArrayStackOfString() {
        s = new String[1];
    }

    public void push(String item) {
        if (N == s.length) {
            resize(s.length * 2);
        }
        s[N++] = item;
    }

    public void resize(int capacity) {
        String[] copy = new String[capacity];
        for (int i = 0; i < N; i++) {
            copy[i] = s[i];
        }
        s = copy;
    }

    public String pop() {
        String item = s[--N];
        s[N] = null;
        if (N > 0 && N == s.length / 4) {
            resize(s.length / 2);
        }
        return item;
    }
}
