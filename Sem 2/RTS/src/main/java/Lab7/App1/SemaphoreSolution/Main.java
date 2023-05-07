package Lab7.App1.SemaphoreSolution;

import Lab7.App1.ReentrantLockSolution.ExecutionThread;

import java.util.concurrent.CyclicBarrier;
import java.util.concurrent.Semaphore;

public class Main {
    public static void main(String[] args) {
        Semaphore semaphore1 = new Semaphore(1);
        Semaphore semaphore2 = new Semaphore(1);
        CyclicBarrier cyclicBarrier = new CyclicBarrier(2);

        new Lab7.App1.ReentrantLockSolution.ExecutionThread(semaphore1, semaphore2, 2, 4, 4, 4, 6, cyclicBarrier).start();
        new ExecutionThread(semaphore2, semaphore1, 3, 5, 5, 5, 7, cyclicBarrier).start();
    }
}