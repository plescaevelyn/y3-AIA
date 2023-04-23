package Lab5.App4;

import java.util.List;
import java.util.Random;

class TrafficThread extends Thread {
    private final Intersection intersection;
    private final int road;

    public TrafficThread(Intersection intersection, int road) {
        this.intersection = intersection;
        this.road = road;
    }

    @Override
    public void run() {
        Random random = new Random();
        while (true) {
            List<Car> queue = intersection.getQueue(road);
            if (queue.size() >= 2) {
                try {
                    intersection.getTrafficLight().acquire();

                    // acquire up to 10 permits from the traffic light
                    int numPermits = Math.min(queue.size(), 10);
                    intersection.getTrafficLight().acquire(numPermits);

                    System.out.println("Traffic light turned green for road " + road);

                    // allow up to 10 cars to pass through the intersection
                    for (int i = 0; i < numPermits; i++) {
                        Car car = queue.remove(0);
                        System.out.println(car + " passed through the intersection");
                        sleep(1000);
                    }

                    // release the permits and the traffic light
                    intersection.getTrafficLight().release(numPermits);
                    System.out.println("Traffic light turned red for road " + road);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            } else {
                // wait for a random amount of time before checking the queue again
                try {
                    sleep(random.nextInt(3) + 1);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        }
    }
}