package Lab3.App2;

/* A Jave 2 SE application with a graphical interface similar to the one in Figure 3.2 will be implemented. Each square in the graphical interface will have a thread of execution (via the Observer/Observable mechanism), which will move its own square to the exit of the opposite enclosure. Moving the squares will only start after the "s" key is pressed. The speed of the squares will be set randomly when the application is started. Square 3 will have a maximum speed that is equal to square 1 and will not be allowed to pass.

The three squares are not allowed to touch each other, which is why it is necessary to synchronize the access through the narrow area between the two enclosures. Thus, the first square that reaches the dotted line will block the square from the opposite enclosure to the dotted line from that side (to be able to avoid it). This synchronization will be implemented through synchronized methods or blocks.

If the first square passing through the narrow area is square 1, it will not continue towards the exit but will wait for the arrival of square 3, after the dotted line. Only squares 1 and 2 must leave the enclosure. This synchronization will be implemented using the join() method.
*/

import javax.swing.*;
import java.awt.event.*;

public class Main implements ActionListener, KeyListener {
    static boolean start = false;

    public static void main(String[] args) {
        JFrame frame = new JFrame("Moving Squares");

        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        frame.setSize(1000, 1000);
        Lines lines = new Lines();
        SquarePanel panel = new SquarePanel();
        frame.add(lines);

        frame.setVisible(true);
        frame.add(panel);
        frame.setVisible(true);

        SquareMover mover1 = new SquareMover(panel, 0, 5, 10);
        SquareMover mover2 = new SquareMover(panel, 1, 10, 20);
        SquareMover mover3 = new SquareMover(panel, 2, 2, 20);

        frame.addKeyListener(new KeyAdapter() {
            @Override
            public void keyPressed(KeyEvent e) {
                int code = e.getKeyCode();
                if (code == KeyEvent.VK_S) {
                    mover1.start();
                    mover2.start();
                    mover3.start();
                }
            }
        });
    }

    public void actionPerformed(ActionEvent actionEvent) {
        start = true;
    }

    public void keyPressed(KeyEvent event) {
        int code = event.getKeyCode();
        if (code == KeyEvent.VK_S)
            start = true;
    }

    public void keyTyped(KeyEvent event) {
    }

    public void keyReleased(KeyEvent event) {
    }
}