package Lab2;

/*
Implement an application that has three threads of execution.

Specifications:
1. The application has a graphical user interface in where three geometric shapes (for example, squares) will be added,
initially arranged at the top of the window.
2. Each thread of execution is responsible for moving the squares, towards the bottom of the window, with a constant speed,
randomly calculated (between a minimum and a maximum) for each square.
3. The threads if execution will be stopped when the geomtric shapes exit the window perimeter. For stopping the threads,
the stop() method will be defined, which will use a logical variable.
 */

import javax.swing.*;
import java.awt.*;
import java.util.Random;

public class Exercise3 extends JFrame{
    private final int WINDOW_WIDTH = 500;
    private final int WINDOW_HEIGHT = 500;

    private Square square1;
    private Square square2;
    private Square square3;

    private boolean running;

    public Exercise3() {
        setTitle("Exercise 2");
        setSize(WINDOW_WIDTH, WINDOW_HEIGHT);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setBackground(Color.BLACK);
        setLocationRelativeTo(null);

        // initialising the squares and adding the squares to the window
        square1 = new Square(50, 50, Color.YELLOW);
        square2 = new Square(150, 50, Color.CYAN);
        square3 = new Square(250, 50, Color.MAGENTA);

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

    public static void main(String[] args) {
        Exercise3 app = new Exercise3();
        app.setVisible(true);
    }

    private static class Square extends JPanel {
        private int x;
        private int y;
        private int width;
        private int height;
        private Color color;

        public Square(int x, int y, Color color) {
            this.x = x;
            this.y = y;
            this.width = 50;
            this.height = 50;
            this.color = color;
        }

        public void moveDown(int distance) {
            y += distance;
            setLocation(x, y);
        }

        public int getY() {
            return y;
        }

        @Override
        public void paintComponent(Graphics g) {
            super.paintComponent(g);
            g.setColor(color);
            g.fillRect(x, y, width, height);
        }
    }
}
