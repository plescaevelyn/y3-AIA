package Lab5.App4;

public class TrafficControlSimulator {
    public static void main(String[] args) {
        Intersection intersection = new Intersection();

        // create the generator thread and start it
        GeneratorThread generator = new GeneratorThread(intersection);
        generator.start();

        // create the traffic threads and start them
        for (int road = 0; road < 4; road++) {
            TrafficThread traffic = new TrafficThread(intersection, road);
            traffic.start();
        }
    }
}