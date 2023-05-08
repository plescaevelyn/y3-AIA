package Lab2.App4;

import javax.swing.*;
import java.awt.*;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.util.Random;

public class App4 extends JFrame implements KeyListener {
    private final int WINDOW_WIDTH = 500;
    private final int WINDOW_HEIGHT = 500;

    private Square square1;
    private Square square2;
    private Square square3;
    private Circle circle;

    private boolean running;
    private int score;
    private int resumeCount;

    public App4() {
        setTitle("App 4");
        setSize(WINDOW_WIDTH, WINDOW_HEIGHT);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setBackground(Color.BLACK);
        setLocationRelativeTo(null);

        // initialising the squares and the circle, and adding them to the window
        square1 = new Square(50, 50, Color.YELLOW);
        square2 = new Square(150, 50, Color.CYAN);
        square3 = new Square(250, 50, Color.MAGENTA);
        circle = new Circle(225, 400, Color.RED);

        add(square1);
        add(square2);
        add(square3);
        add(circle);

        // starting the threads
        running = true;
        new Thread(() -> moveSquare(square1)).start();
        new Thread(() -> moveSquare(square2)).start();
        new Thread(() -> moveSquare(square3)).start();
        new Thread(this::supervisorThread).start();

        // adding the key listener for circle movement
        addKeyListener(this);
        setFocusable(true);
    }

    private void moveSquare(Square square) {
        Random random = new Random();
        int speed = random.nextInt(10) + 1; // selecting speed as a random value between 1 and 10
        while (running) {
            square.moveDown(speed);
            if (square.getY() >= WINDOW_HEIGHT) {
                square.resetPosition();
            }
            try {
                Thread.sleep(50);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    private void supervisorThread() {
        while (running) {
            if (circle.collidesWith(square1) || circle.collidesWith(square2) || circle.collidesWith(square3)) {
                stopGame();
                showMessage("Game Over!");
            }
            try {
                Thread.sleep(50);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    private void stopGame() {
        running = false;
    }

    private void showMessage(String message) {
        JOptionPane.showMessageDialog(this, message);
    }

    private void resetGame() {
        square1.resetPosition();
        square2.resetPosition();
        square3.resetPosition();
        circle.resetPosition();
        running = true;
        resumeCount++;
    }

    @Override
    public void keyPressed(KeyEvent e) {
        int key = e.getKeyCode();
        if (key == KeyEvent.VK_LEFT) {
            circle.moveLeft();
        } else if (key == KeyEvent.VK_RIGHT) {
            circle.moveRight();
        }
    }

    @Override
    public void keyTyped(KeyEvent e) {
    }

    @Override
    public void keyReleased(KeyEvent e) {
    }
}