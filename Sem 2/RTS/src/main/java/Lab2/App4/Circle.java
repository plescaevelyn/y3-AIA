package Lab2.App4;

import javax.swing.*;
import java.awt.*;

public class Circle extends JPanel {
    private static final int INITIAL_X = 225;
    private static final int INITIAL_Y = 400;
    private static final int DIAMETER = 50;
    private static final int SPEED = 10;

    private int x;
    private int y;
    private Color color;

    public Circle(int x, int y, Color color) {
        this.x = x;
        this.y = y;
        this.color = color;
    }

    public void moveLeft() {
        x -= SPEED;
        setLocation(x, y);
    }

    public void moveRight() {
        x += SPEED;
        setLocation(x, y);
    }

    public boolean collidesWith(Square square) {
        int squareX = square.getX();
        int squareY = square.getY();
        int squareWidth = square.getWidth();
        int squareHeight = square.getHeight();

        if (x + DIAMETER >= squareX && x <= squareX + squareWidth && y + DIAMETER >= squareY && y <= squareY + squareHeight) {
            return true;
        }

        return false;
    }

    public void resetPosition() {
        x = INITIAL_X;
        y = INITIAL_Y;
        setLocation(x, y);
    }

    @Override
    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        g.setColor(color);
        g.fillOval(x, y, DIAMETER, DIAMETER);
    }
}