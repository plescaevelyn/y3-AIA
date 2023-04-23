package Lab5.App4;

import java.util.*;

class GeneratorThread extends Thread {
    private final Intersection intersection;
    private int carId;

    public GeneratorThread(Intersection intersection) {
        this.intersection = intersection;
        this.carId = 0;
    }

    @Override
    public void run() {
        Random random = new Random();

        while (true) {
            // generate random number of cars for each road
            for (int road = 0; road < 4; road++) {
                int numCars = random.nextInt(5) + 1;
                for (int i = 0; i < numCars; i++) {
                    Car car = new Car(carId++, road);
                    intersection.getQueue(road).add(car);
                    System.out.println(car + " arrived at the intersection");
                }
            }
            // wait for a random amount of time
            try {
                sleep(random.nextInt(5) + 1);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
}