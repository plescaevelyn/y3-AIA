package Lab4.App4;

public class ExecutionThread extends Thread {
    Integer monitor1, monitor2;
    int sleep, activity_min, activity_max;
    public ExecutionThread(Integer monitor1, Integer monitor2, int sleep, int activity_min, int activity_max) {
        this.monitor1 = monitor1;
        this.monitor2 = monitor2;
        this.sleep = sleep;
        this.activity_min = activity_min;
        this.activity_max = activity_max;
    }

    public ExecutionThread(Integer monitor1, int sleep, int activity_min, int activity_max) {
        this.monitor1 = monitor1;
        this.sleep = sleep;
        this.activity_min = activity_min;
        this.activity_max = activity_max;
    }

    public void run() {
        System.out.println(this.getName() + " - STATE 1");
        try {
            Thread.sleep(Math.round(Math.random() * sleep) * 500);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        System.out.println(this.getName() + " - STATE 2");

        if (monitor1 != null) {
            synchronized (monitor1) {
                System.out.println(this.getName() + " - STATE 3");
                int k = (int) Math.round(Math.random() * (activity_max
                        - activity_min) + activity_min);
                for (int i = 0; i < k * 100000; i++) {
                    i++;
                    i--;
                }
            }
        }

        System.out.println(this.getName() + " - STATE 4");
    }
}
