package test;

import algorithms.LinkedStack;
import stdlib.StdOut;

/**
 * Created by beginor on 13-11-26.
 */
public class StackTest {

    public static void main(String[] args) {
        LinkedStack<Integer> stack = new LinkedStack<Integer>();
        int n = 50;
        while (n > 0) {
            stack.push(n % 2);
            n = n / 2;
        }

        for (int d : stack) {
            StdOut.print(d);
        }
    }
}
