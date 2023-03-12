package Lab2.Exercise2.MVCClasses;

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
        if (!(arg instanceof ThreadUpdateNotification notification)) {
            return;
        }

        window.setProgressValue(notification.id, notification.progress);
    }
}