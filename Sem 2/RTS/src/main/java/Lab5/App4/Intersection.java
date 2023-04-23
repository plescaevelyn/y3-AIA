package Lab5.App4;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.Semaphore;

public class Intersection {
    private final List<List<Car>> queues;
    private final Semaphore trafficLight;

    public Intersection() {
        queues = new ArrayList<>();
        for (int i = 0; i < 4; i++) {
            queues.add(new ArrayList<>());
        }
        trafficLight = new Semaphore(1);
    }

    public List<Car> getQueue(int road) {
        return queues.get(road);
    }

    public Semaphore getTrafficLight() {
        return trafficLight;
    }
}