package Lab2.App2.MVCClasses;

import java.util.Observable;

public class Fir extends Observable implements Runnable {
    int progress;
    int id;
    int processorLoad;

    public Fir(int id, int processorLoad) {
        this.id=id;
        this.processorLoad = processorLoad;
    }

    public void updateNotification(int id, int progress) {
        this.id = id;
        this.progress = progress;
    }

    @Override
    public void run() {
        int c = 0;

        while(c < 1000){
            for(int j = 0; j < this.processorLoad; j++) {
                j++;
                j--;
            }
        }
        c++;

        try {
            Thread.sleep(10);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }

        this.setChanged();
        this.notifyObservers(new ThreadUpdateNotification(this.id, c));
    }
}