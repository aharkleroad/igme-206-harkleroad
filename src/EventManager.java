import java.util.ArrayList;
public class EventManager <T extends Comparable>{
    protected ArrayList<T> eventList = new ArrayList<T>();  // generic type ArrayList for holding events
    protected int length;  // number of events in the list

    public EventManager(){  // EventManager constructor
        length = 0;  // no events in the manager
    }  // end of EventManager constructor

    public void addToManager(T x){  // puts an event into the manager in chronological order
        if (length == 0){  // no events in the manager yet
            eventList.add(length, x);
        }
        else if (x.compareTo(eventList.get(length - 1)) > 0){  // event occurs later than the last event in the manager
            eventList.add(length, x);
        }
        else{  // the event is not the last event chronologically in the manager
            int i = 0;
            while (x.compareTo(eventList.get(i)) == 1 && i < length){  // event occurs after the event in i position
                i++;
            }  // end of while
            eventList.add(i, x);
        }
        length++;
    }  // end of addToManager
    public T getValue(int i){  // returns the event in a given position
        if (i < length) {  // we are not at the end of the ArrayList
            return eventList.get(i);
        }
        else {  // given index is larger than the length of the ArrayList
            return null;
        }
    }  // end of getValue
    public void removeEvent(int i){  // removes an event at a given index
        if (i >= 0 && i < length){  // we are in the ArrayList
            eventList.remove(i);
            length--;
        }
    }  // end of removeEvent
}  // end of EventManager
