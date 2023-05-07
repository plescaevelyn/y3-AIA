package Lab7.App3;

public class Main {
    public static void main(String[] args) {
        Object monitor1 = new Object();
        Object monitor2 = new Object();

        ExecutionThread1 thread1 = new ExecutionThread1(monitor1, monitor2, 7, 2, 3);
        ExecutionThread2 thread2 = new ExecutionThread2(thread1, monitor1, 3, 5, 1);
        ExecutionThread2 thread3 = new ExecutionThread2(thread1, monitor2, 4, 6, 2);

        thread1.start();
        thread2.start();
        thread3.start();
    }
}