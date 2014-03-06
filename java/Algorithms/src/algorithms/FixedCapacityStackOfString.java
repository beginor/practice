package algorithms;

/**
 * Created by zhangzhimin on 13-11-25.
 */
public class FixedCapacityStackOfString {

    private String[] s;
    private int n = 0;

    public FixedCapacityStackOfString(int capacity) {
        s = new String[capacity];
    }

    public void push(String item) {
        s[n++] = item;
    }

    public String pop() {
        String item = s[--n];
        s[n] = null;
        return item;
    }
}
