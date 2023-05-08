package Lab2.App2.MVCClasses;

import java.util.Observable;
import java.util.Observer;

public class Controller implements Observer {
    private Window window;

    public void Start(int noOfThreads, int processorLoad) {
        window = new Window();

        for (int i = 0; i < noOfThreads; i++) {
            Fir fir = new Fir(i, processorLoad);
            fir.addObserver(this);

            Thread firThread = new Thread(fir);
            if (i + 2 > Thread.MAX_PRIORITY) {
                break;
            } else {
                firThread.setPriority(i + 2);
                firThread.start();
            }
        }
    }

    @Override
    public void update(Observable o, Object arg) {
        window.setProgressValue((ThreadUpdateNotification)arg);
    }
}