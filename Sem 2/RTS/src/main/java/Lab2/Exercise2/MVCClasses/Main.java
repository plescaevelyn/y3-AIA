package Lab2.Exercise2.MVCClasses;

public class Main {
    private static final int NO_OF_THREADS = 6;
    private static final int PROCESSOR_LOAD = 1000000;

    public static void main(String[] args) {
        Model model = new Model(NO_OF_THREADS, PROCESSOR_LOAD);
        View view = new View(model);
        Controller controller = new Controller(model);

        controller.startThreads();
    }
}