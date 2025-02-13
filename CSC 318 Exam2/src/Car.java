public class Car {
    protected int road;  // road the car is on
    protected int turnDirection;  // direction the car will turn
    protected double arrivalTime;  // time the patient arrives
    protected double intersectionTime;  // time it takes for the patient to be serviced
    public Car(){  // Patient constructor
        int randomRoad = (int) (Math.random() * 100);
        if (randomRoad <= 50){  // car arrives from EW road
            road = 1;
        }
        else {  // car arrives from NS road
            road = 2;
        }
        intersectionTime = 0;
    }  // end of Car constructor

    public double getRoad() {
        return road;
    }
    public double getArrivalTime() {
        return arrivalTime;
    }
    public int getTurnDirection() {
        return turnDirection;
    }
    public void setArrivalTime(double arrivalTime) {
        this.arrivalTime = arrivalTime;
    }
    public void setIntersectionTime(double intersectionTime) {
        this.intersectionTime = intersectionTime;
    }
}  // end of Car