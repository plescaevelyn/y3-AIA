package Lab4.App1;
public class Main {
    public static void main(String[] args) {
        Integer monitor = 1;
        new ExecutionThread(monitor,2,4,4,4).start();
        new ExecutionThread(monitor,3,6,3,3).start();
        new ExecutionThread(monitor,2,5,5,5).start();
    }
}