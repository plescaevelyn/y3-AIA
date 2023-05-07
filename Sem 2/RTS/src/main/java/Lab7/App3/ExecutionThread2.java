package Lab7.App3;

public class ExecutionThread2 extends Thread {
    private final Thread dependentThread;
    private final Object monitor;
    private final int sleep;
    private final int activity_min;
    private final int activity_max;

    public ExecutionThread2(Thread dependentThread, Object monitor, int sleep, int activity_min, int activity_max) {
        this.dependentThread = dependentThread;
        this.monitor = monitor;
        this.sleep = sleep;
        this.activity_min = activity_min;
        this.activity_max = activity_max;
    }

    public void run() {
        System.out.println(this.getName() + " - STATE 1");

        synchronized (monitor) {
            try {
                monitor.wait();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }

            System.out.println(this.getName() + " - STATE 2");
            int k = (int) Math.round(Math.random() * (activity_max - activity_min) + activity_min);
            for (int i = 0; i < k * 100000; i++) {
                i++;
                i--;
            }

            System.out.println(this.getName() + " - STATE 3");
        }

        System.out.println(this.getName() + " - STATE 4");
        if (dependentThread != null) {
            try {
                dependentThread.join();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
}