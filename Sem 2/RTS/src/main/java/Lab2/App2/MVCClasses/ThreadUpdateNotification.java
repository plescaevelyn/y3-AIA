package Lab2.App2.MVCClasses;

public class ThreadUpdateNotification {
    public int id;
    public int progress;

    public int getId() {
        return id;
    }

    public int getProgress() {
        return progress;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setProgress(int progress) {
        this.progress = progress;
    }

    public ThreadUpdateNotification(int id, int progress) {
        this.id = id;
        this.progress = progress;
    }
}
