package Lab2.App3;

import javax.swing.*;
import java.awt.*;
import java.util.Random;

public class App3 extends JFrame {
    private final int WINDOW_WIDTH = 500;
    private final int WINDOW_HEIGHT = 500;

    private Square square1;
    private Square square2;
    private Square square3;

    Graphics graphics;

    private boolean running;

    public App3() {
        setTitle("Square mover app");
        setSize(WINDOW_WIDTH, WINDOW_HEIGHT);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setBackground(Color.BLACK);
        setLocationRelativeTo(null);

        this.graphics = new DebugGraphics();

        setLayout(new FlowLayout());

        // initialising the squares and adding the squares to the window
        square1 = new Square(50, 50, Color.RED);
        square2 = new Square(150, 50, Color.YELLOW);
        square3 = new Square(250, 50, Color.GREEN);

        add(square1);
        add(square2);
        add(square3);

        // starting the threads
        running = true;
        new Thread(() -> moveSquare(square1)).start();
        new Thread(() -> moveSquare(square2)).start();
        new Thread(() -> moveSquare(square3)).start();
    }

    private void moveSquare(Square square) {
        Random random = new Random();
        int speed = random.nextInt(10) + 1; // selecting speed as a random value between 1 and 10

        while (running) {
            square.moveDown(speed);

            if (square.getY() >= WINDOW_HEIGHT) {
                stopThreads();
            }
            try {
                Thread.sleep(50);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    private void stopThreads() {
        running = false;
    }
}
