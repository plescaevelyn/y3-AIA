package Lab2.Exercise2.MVCClasses;

import java.util.Observable;

public class Model extends Observable {
    private int noOfThreads;
    private int processorLoad;
    private int[] progressValues;

    public Model(int noOfThreads, int processorLoad) {
        this.noOfThreads = noOfThreads;
        this.processorLoad = processorLoad;
        this.progressValues = new int[noOfThreads];
    }

    public int getNoOfThreads() {
        return noOfThreads;
    }

    public int getProcessorLoad() {
        return processorLoad;
    }

    public int getProgressValue(int id) {
        return progressValues[id];
    }

    public void setProgressValue(int id, int val) {
        progressValues[id] = val;
        setChanged();
        notifyObservers(id);
    }
}