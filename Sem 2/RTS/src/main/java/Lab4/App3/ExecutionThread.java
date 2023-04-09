package Lab4.App3;

public class ExecutionThread extends Thread {
    Integer monitor;
    int sleep, activity_min, activity_max;
    public ExecutionThread(Integer monitor, int sleep, int activity_min, int activity_max) {
        this.monitor = monitor;
        this.sleep = sleep;
        this.activity_min = activity_min;
        this.activity_max = activity_max;
    }
    public void run() {
        System.out.println(this.getName() + " - STATE 1");

        System.out.println(this.getName() + " - STATE 2");
        synchronized (monitor) {
            System.out.println(this.getName() + " - STATE 3");
            int k = (int) Math.round(Math.random()*(activity_max
                    - activity_min) + activity_min);
            for (int i = 0; i < k * 100000; i++) {
                i++; i--;
            }
        }

        try {
            Thread.sleep(Math.round(Math.random() * sleep) * 500);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        System.out.println(this.getName() + " - STATE 4");
    }
}
