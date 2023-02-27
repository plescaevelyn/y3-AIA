package Lab2.Exercise2.MVCClasses;

import java.util.ArrayList;
import java.util.List;

public class Controller {
    private Model model;
    private List<Fir> firs;

    public Controller(Model model) {
        this.model = model;
        this.firs = new ArrayList<>();
    }

    public void addFir(Fir fir) {
        firs.add(fir);
    }

    public void startThreads() {
        for (Fir fir : firs) {
            fir.start();
        }
    }
}