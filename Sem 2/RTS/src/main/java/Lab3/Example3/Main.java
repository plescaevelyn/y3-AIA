package Lab3.Example3;

public class Main {
    public static int sumOfDivisors = 0;

    public static void main(String[] args) {
        JoinTestThread w1 = new JoinTestThread("Thread 1",null, 50000);
        JoinTestThread w2 = new JoinTestThread("Thread 2",w1, 20000);
        w1.start();
        w2.start();

        try {
            w1.join();
            w2.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        System.out.println("Sum of divisors: " + sumOfDivisors);
    }
}