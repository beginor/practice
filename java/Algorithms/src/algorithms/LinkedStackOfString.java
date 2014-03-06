package algorithms;

/**
 * Created by zhangzhimin on 13-11-25.
 */
public class LinkedStackOfString {

    private Node first;

    private class Node {

        public String item;
        public Node next;
    }

    public boolean isEmpty() {
        return first == null;
    }

    public void push(String item) {
        Node oldFirst = first;
        first = new Node();
        first.item = item;
        first.next = oldFirst;
    }

    public String pop() {
        String item = first.item;
        first = first.next;
        return item;
    }
}
