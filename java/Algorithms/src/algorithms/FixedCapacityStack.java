package algorithms;

import java.util.Iterator;

/**
 * Fixed Capacity Stack
 * Created by zhangzhimin on 13-11-26.
 */
public class FixedCapacityStack<Item> implements Iterable<Item> {

    private Item[] s;
    private int N = 0;

    public FixedCapacityStack(int capacity) {
        s = (Item[])new Object[capacity];
    }

    @Override
    public Iterator<Item> iterator() {
        return new ReverseArrayIterator();
    }

    private class ReverseArrayIterator implements Iterator<Item> {

        private int i = N;

        @Override
        public boolean hasNext() {
            return i > 0;
        }

        @Override
        public Item next() {
            return s[--i];
        }

        @Override
        public void remove() {
            /* not supported */
        }
    }

    public void push(Item item) {
        s[N++] = item;
    }

    public Item pop() {
        Item item = s[--N];
        s[N] = null;
        return item;
    }
}
