package Lab2.Exercise2.MVCClasses;

import javax.swing.JFrame;
import javax.swing.JProgressBar;
import java.util.Observer;
import java.util.Observable;

public class View implements Observer {
    private Model model;
    private JFrame frame;
    private JProgressBar[] progressBars;

    public View(Model model) {
        this.model = model;
        model.addObserver(this);

        this.frame = new JFrame();
        this.frame.setLayout(null);
        this.frame.setSize(450, 400);
        this.frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        init();

        this.frame.setVisible(true);
    }

    private void init() {
        int noOfThreads = model.getNoOfThreads();
        this.progressBars = new JProgressBar[noOfThreads];

        for (int i = 0; i < noOfThreads; i++) {
            JProgressBar pb = new JProgressBar();
            pb.setMaximum(1000);
            pb.setBounds(50, (i + 1) * 30, 350, 20);
            this.frame.add(pb);
            this.progressBars[i] = pb;
        }
    }

    public void update(Observable o, Object arg) {
        int id = (int) arg;
        int val = model.getProgressValue(id);
        progressBars[id].setValue(val);
    }
}