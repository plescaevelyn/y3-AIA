package Lab2.App4;

/*
 * The application from point 3.3 will be modified so that at the bottom of the application a new geometric shape
 * (for example a circle) will be added. The user will be able to move the circle using the keyboard, left or right.
 * The application will have a fourth thread of execution with the role of a supervisor. When the circle collides with
 * one of the squares, all geometric shapes in the window will stop and an error message will be displayed in the window.
 * In this application, the threads responsible for moving the squares will evolve in the loop (the moment a square
 * comes out of the window, it will resume its initial position). The user will be able to resume the game three times.
 * To make the game more interesting, a score will be calculated.
 * It will be calculated by summing the avoided squares successfully.
 * */

public class Main {
    public static void main(String[] args) {
        App4 app = new App4();
        app.setVisible(true);
    }
}
