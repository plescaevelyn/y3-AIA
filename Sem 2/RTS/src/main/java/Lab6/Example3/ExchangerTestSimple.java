package Lab6.Example3;

import java.util.List;
import java.util.concurrent.Exchanger;

public class ExchangerTestSimple {
    public static void main(String args[]){
        Exchanger<List<Integer>> exchanger = new Exchanger<List<Integer>>();

        Fir f1 = new Fir(1000,exchanger,"Duke");
        Fir f2 = new Fir(5000,exchanger,"Wild Wings");
        f1.start(); f2.start();
    }
}
