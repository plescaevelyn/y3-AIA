package Lab5.App4;

class Car {
    private final int carId;
    private final int road;

    public Car(int carId, int road) {
        this.carId = carId;
        this.road = road;
    }

    @Override
    public String toString() {
        return "Car " + carId + " on road " + road;
    }
}