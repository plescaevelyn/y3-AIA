package Lab4.App1;

public class Main {
    public static void main(String[] args) {
        Integer monitor1 = 1;
        Integer monitor2 = 1;
        new ExecutionThread(monitor1, 2, 4, 4, 4).start();
//        new ExecutionThread(monitor1,3,6,3,3).start();
        new ExecutionThread(monitor2, 2, 5, 5, 5).start();
    }
}