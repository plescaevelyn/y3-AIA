package Lab3.Example3;

class JoinTestThread extends Thread {
    Thread t;
    String n;
    int num;

    JoinTestThread(String n, Thread t, int num) {
        this.setName(n);
        this.t = t;
        this.num = num;
    }

    public void run() {
        System.out.println("Thread " + getName() + " has entered the run() method");
        try {
            if (t != null)
                t.join();

            System.out.println("Thread " + getName() + " calculating divisors.");

            int sum = 0;
            for (int i = 1; i <= num; i++) {
                if (num % i == 0) {
                    sum += i;
                }
            }

            Main.sumOfDivisors += sum;

            System.out.println("Thread " + getName() + " has determined sum of divisors.");

        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}