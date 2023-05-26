package Lab2.App3;

/*
Implement an application that has three threads of execution.

Specifications:
1. The application has a graphical user interface in where three geometric shapes (for example, squares) will be added,
initially arranged at the top of the window.
2. Each thread of execution is responsible for moving the squares, towards the bottom of the window, with a constant speed,
randomly calculated (between a minimum and a maximum) for each square.
3. The threads if execution will be stopped when the geometric shapes exit the window perimeter. For stopping the threads,
the stop() method will be defined, which will use a logical variable.

 */

public class Main {
    public static void main(String[] args) {
        App3 app = new App3();
        app.setVisible(true);
    }
}
