package Lab2.App4;

import javax.swing.*;
import java.awt.*;

public class Square extends JPanel {
    private static final int INITIAL_Y = 50;

    private int x;
    private int y;
    private int width;
    private int height;
    private Color color;

    public Square(int x, int y, Color color) {
        this.x = x;
        this
                .y = y;
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

    public void resetPosition() {
        y = INITIAL_Y;
        setLocation(x, y);
    }

    @Override
    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        g.setColor(color);
        g.fillRect(x, y, width, height);
    }
}