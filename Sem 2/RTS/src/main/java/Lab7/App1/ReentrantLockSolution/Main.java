package Lab7.App1.ReentrantLockSolution;

import java.util.concurrent.CyclicBarrier;
import java.util.concurrent.locks.ReentrantLock;

public class Main {
    public static void main(String[] args) {
        ReentrantLock reentrantLock1 = new ReentrantLock();
        ReentrantLock reentrantLock2 = new ReentrantLock();
        CyclicBarrier cyclicBarrier = new CyclicBarrier(3);

        ExecutionThread thread1 = new ExecutionThread(reentrantLock1, reentrantLock2, 2, 4, 4, 4, 6, cyclicBarrier);
        ExecutionThread thread2 = new ExecutionThread(reentrantLock1, reentrantLock2, 3, 5, 5, 5, 7, cyclicBarrier);
        ExecutionThread thread3 = new ExecutionThread(reentrantLock1, reentrantLock2, 1, 3, 3, 3, 5, cyclicBarrier);

        thread1.start();
        thread2.start();
        thread3.start();
    }
}