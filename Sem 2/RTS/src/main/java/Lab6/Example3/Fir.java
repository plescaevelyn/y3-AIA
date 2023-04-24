package Lab6.Example3;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.Exchanger;

class Fir extends Thread{
    List<Integer> list = new ArrayList<Integer>();
    int sleepTime;
    Exchanger<List<Integer>> exchanger;
    String name;

    Fir(int sT, Exchanger<List<Integer>> exchanger, String name){
        this.sleepTime=sT;
        this.exchanger=exchanger;
        this.name =name;
    }

    public void displayList(){
        // displays the list of the current thread
        for (int i = 0; i < this.list.size(); i++) {
            System.out.println(this.list.get(i));
        }
    }

    public void run(){
        int noElem = (int)Math.round(Math.random()*3+1);
        for(int i = 0; i < noElem; i++){
            // populate the list with a random number of items
            int elem = (int)Math.round(Math.random()*100);
            list.add(elem);
        }
        this.displayList(); //display the list before exchange
        try {
            Thread.sleep(this.sleepTime);
            // the thread is waiting x ms the exchange of objects is made
            this.list=exchanger.exchange(this.list);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        this.displayList();//display the list after the exchange
    }
}
