/* Event types:
    Car arrives at intersection (north bound)
    Car arrives at intersection (EW road)
    Car passes through intersection (from north road)
    Car passes through intersection (from EW road)
    Light turns green EW
    Light turns red EW
    Light turns green NS and arrow turns green
    Arrow turns red
    Light turns red NS
    Sim ends
 */
public class Events implements Comparable{
    protected int eventType;  // kind of event
    protected Car car;  // patient linked to the event
    protected double time;  // time the event occurs

    public Events(int eventType, Car car, double time){  // Events constructor (associated car)
        this.eventType = eventType;
        this.car = car;
        this.time = time;
    }  // end of Events constructor
    public Events(int eventType, double time){  // Events constructor (no car)
        this.eventType = eventType;
        this.time = time;
    }  // end of Events constructor

    public double getTime() {
        return time;
    }
    public int getEventType() {
        return eventType;
    }

    public int compareTo(Object o) {  // compares the times when two events take place
        if (getTime() >= ((Events)o).getTime()){  // first event is later than or at the same time as the second
            return 1;
        }
        else {  // first event is before the second
            return -1;
        }
    }  // end of compareTo
}  // end of Events