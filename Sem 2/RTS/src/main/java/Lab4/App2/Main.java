package Lab4.App2;

public class Main {
    public static void main(String[] args) {
        Integer monitor = 1;
        new ExecutionThread(monitor,2,4,4,4,6).start();
        new ExecutionThread(monitor,3,5,5,5,7).start();
    }
}