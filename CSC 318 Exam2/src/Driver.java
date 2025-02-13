

import java.util.ArrayList;
public class Driver {
    public static void main(String[] args) {
        double clock = 0;  // time clock
        double timePassed;
        double eventTime;  // sets when an event occurs
        int carArrivals = 0;  // tracks number of cars that arrive
        int carsThroughLine = 0;  // tracks number of cars that pass through the intersection
        int NSCarsThroughLine = 0;  // saves number of northbound cars that pass through intersection
        int EWCarsThroughLine = 0;  // saves number of east-west cars that pass through intersection
        int totalCarsInEW = 0;  // saves sum total of all cars in EW line during the sim
        int totalCarsInNS = 0;  // saves sum total of all cars in NS line during the sim
        int timesThroughLoop = 0;  // saves the number of times the loop has been travelled through
        double totalWaitAll = 0;  // total wait for all cars on NS and EW roads
        double totalWaitSquared = 0;
        double totalWaitEW = 0;  // total wait for all EW cars
        double EWWaitSquared = 0;
        double totalWaitNS = 0;  // total wait for all NS cars
        double NSWaitSquared = 0;
        boolean EWGreen = false;  // EW light is green, beginning of light cycle
        boolean NSGreen = false;  // NS light is green, must be opposite EW
        boolean GreenArrow = false;  // Arrow for NS is green
        boolean EWCarInIntersection = false;  // an EW car is currently going through the intersection
        boolean NSCarInIntersection = false;  // an EW car is currently going through the intersection
        ArrayList<Car> EWQueue = new ArrayList<>();  // cars on EW road
        int carsInEWQueue;
        ArrayList<Car> NSQueue = new ArrayList<>();  // cars on NS road
        int carsInNSQueue;
        EventManager<Events> eventQueue = new EventManager();  // event queue
        Events shutdown = new Events(10, 1000);  // event triggers end of sim, 60000 mins/1000 hrs
        eventQueue.addToManager(shutdown);  // adds shutdown event to queue so sim stops after 100 hours
        Events eventCreator = new Events(7, 0);  // turns light green and bootstraps light turning red
        eventQueue.addToManager(eventCreator);
        eventTime = TimetoArriveorServe(120);  // finds arrival time of first patient
        System.out.println("The first car arrives at " + eventTime);
        eventCreator = new Events(1, new Car(), eventTime);  // creates first arrival event to start sim
        eventQueue.addToManager(eventCreator);
        Events currentEvent = eventQueue.getValue(0);  // sets first event to be handled by the switch
        while (currentEvent.getEventType() != 10) {  // 1000 hours have not passed
            timePassed = currentEvent.getTime() - clock;
            carsInEWQueue = EWQueue.size();
            totalCarsInEW += carsInEWQueue;
            totalWaitAll += carsInEWQueue * timePassed;
            totalWaitSquared += (carsInEWQueue * timePassed) * (carsInEWQueue * timePassed);
            totalWaitEW += carsInEWQueue * timePassed;
            EWWaitSquared += (carsInEWQueue * timePassed) * (carsInEWQueue * timePassed);
            carsInNSQueue = NSQueue.size();
            totalCarsInNS += carsInNSQueue;
            totalWaitAll += carsInNSQueue * timePassed;
            totalWaitSquared += (carsInNSQueue * timePassed) * (carsInNSQueue * timePassed);
            totalWaitNS += carsInNSQueue * timePassed;
            NSWaitSquared += (carsInNSQueue * timePassed) * (carsInNSQueue * timePassed);
            carsInNSQueue = carsInEWQueue = 0;  // resets cars in queue for next loop/event
            clock = currentEvent.getTime();
            switch (currentEvent.getEventType()) {
                case 1:  // car arrives at intersection
                    carArrivals++;
                    if (currentEvent.car.getRoad() == 1){
                        EWQueue.add(currentEvent.car);
                        currentEvent.car.setArrivalTime(currentEvent.getTime());
                        if (EWGreen && (EWQueue.size() == 1) && !EWCarInIntersection){
                            eventCreator = new Events(3, currentEvent.car, clock);
                            eventQueue.addToManager(eventCreator);
                        }
                    }
                    else {
                        NSQueue.add(currentEvent.car);
                        currentEvent.car.setArrivalTime(currentEvent.getTime());
                        if (NSGreen && (NSQueue.size() == 1) && !NSCarInIntersection){
                            eventCreator = new Events(4, currentEvent.car, clock);
                            eventQueue.addToManager(eventCreator);
                        }
                    }
                    // determine the time the next car will arrive
                    eventTime = TimetoArriveorServe(120) + clock;
                    eventCreator = new Events(1, new Car(), eventTime);
                    eventQueue.addToManager(eventCreator);  // add event to queue
                    if (clock > 500 && clock <= 500.166){  // print to show working correctly
                        System.out.println("A new car arrives at " + eventTime);
                    }
                    break;
                case 2:  // car enters the line
                    System.out.println("This is event 2. We have incorporated it in the arrival event so if we are here we are in trouble.");
                    break;
                case 3:  // car enters intersection (EW)
                    if (EWCarInIntersection){
                        System.out.println("Two cars attempt to enter the intersection at the same time. Error.");
                    }
                    if (currentEvent.car != EWQueue.get(0)){
                        System.out.println("Car entering intersection =/= the one at the beginning of the queue.");
                    }
                    EWCarInIntersection = true;
                    int randomEWTurn = (int) (Math.random() * 100);
                    if (randomEWTurn <= 70){
                        currentEvent.car.turnDirection = 1;  // turn south
                        eventTime = TimetoArriveorServe(720);  // 5 second turn avg
                    }
                    else {
                        currentEvent.car.turnDirection = 0;  // turn north
                        eventTime = TimetoArriveorServe(450);  // 8 second turn avg
                    }
                    eventCreator = new Events(5, currentEvent.car, eventTime + clock);
                    eventQueue.addToManager(eventCreator);
                    carsThroughLine++;
                    EWCarsThroughLine++;
                    if (clock > 500 && clock <= 500.166){  // print to show working correctly
                        System.out.println("An EW car enters the intersection");
                    }
                    break;
                case 4:  // car enters intersection (NS)
                    if (NSCarInIntersection){
                        System.out.println("Two cars attempt to enter the intersection at the same time. Error.");
                    }
                    if (currentEvent.car != NSQueue.get(0)){
                        System.out.println("Car entering intersection =/= the one at the beginning of the queue.");
                    }
                    NSCarInIntersection = true;
                    int randomNSTurn = (int) (Math.random() * 100);
                    if (randomNSTurn <= 25){
                        currentEvent.car.turnDirection = 1;  // turn west
                    }
                    else {
                        currentEvent.car.turnDirection = 0;  // no turn
                    }
                    if (currentEvent.car.getTurnDirection() == 0){  // car continues straight
                        eventTime = TimetoArriveorServe(900);  // 4 second avg
                        eventCreator = new Events(6, currentEvent.car, eventTime + clock);
                        eventQueue.addToManager(eventCreator);
                        if (clock > 500 && clock <= 500.166){  // print to show working correctly
                            System.out.println("An NS car enters the intersection");
                        }
                    }
                    else if (GreenArrow == true) {  // car able to turn west, green arrow
                        eventTime = TimetoArriveorServe(450);  // 8 second turn avg
                        eventCreator = new Events(6, currentEvent.car, eventTime + clock);
                        eventQueue.addToManager(eventCreator);
                        if (clock > 500 && clock <= 500.166){  // print to show working correctly
                            System.out.println("An NS car enters the intersection");
                        }
                    }
                    else {  // car may not be able to turn, no green arrow
                        int randomTraffic = (int) (Math.random() * 100);
                        if (randomTraffic >= 50){  // no traffic
                            eventTime = TimetoArriveorServe(450);  // 8 second turn avg
                            eventCreator = new Events(6, currentEvent.car, eventTime + clock);
                            eventQueue.addToManager(eventCreator);
                            if (clock > 500 && clock <= 500.166){  // print to show working correctly
                                System.out.println("An NS car enters the intersection");
                            }
                        }
                        else {
                            NSCarInIntersection = false;
                            carsThroughLine--;
                            NSCarsThroughLine--;
                            if (clock > 500 && clock <= 500.166){  // print to show working correctly
                                System.out.println("Car must wait for next light cycle to turn");
                            }
                        }
                    }
                    carsThroughLine++;
                    NSCarsThroughLine++;
                    break;
                case 5:  // car exits intersection (EW)
                    if (!EWCarInIntersection){
                        System.out.println("Trying to remove a nonexistent car from the intersection");
                        break;
                    }
                    EWCarInIntersection = false;
                    EWQueue.remove(0);  // removes first (current) car
                    if (EWGreen && EWQueue.size() > 0){
                        eventCreator = new Events(3, EWQueue.get(0), clock);
                        eventQueue.addToManager(eventCreator);
                    }
                    break;
                case 6:  // car exits intersection (NS)
                    if (!NSCarInIntersection){
                        System.out.println("Trying to remove a nonexistent car from the intersection");
                    }
                    NSCarInIntersection = false;
                    NSQueue.remove(0);  // removes first (current) car
                    if (NSGreen && NSQueue.size() > 0){
                        eventCreator = new Events(4, NSQueue.get(0), clock);
                        eventQueue.addToManager(eventCreator);
                    }
                    break;
                case 7:  // EW light turns green, NS light turns red
                    EWGreen = true;
                    NSGreen = false;
                    eventCreator = new Events(8, clock + 0.03333);  // light changes in 2 minutes
                    eventQueue.addToManager(eventCreator);
                    if (EWQueue.size() > 0) {  // cars on EW will begin to enter intersection if any are waiting
                        eventCreator = new Events(3, EWQueue.get(0), clock);
                        eventQueue.addToManager(eventCreator);
                    }
                    if (clock > 500 && clock <= 500.166){  // print to show working correctly
                        System.out.println("The EW light turns green");
                    }
                    break;
                case 8: // NS light turns green, NS arrow turns green, EW light turns red
                    EWGreen = false;
                    NSGreen = true;
                    GreenArrow = true;
                    eventCreator = new Events(9, clock + 0.01666);  // arrow turns off in 1 minute
                    eventQueue.addToManager(eventCreator);
                    if (NSQueue.size() > 0) {  // cars on NS road will begin to enter intersection if any are waiting
                        eventCreator = new Events(4, NSQueue.get(0), clock);
                        eventQueue.addToManager(eventCreator);
                    }
                    if (clock > 500 && clock <= 500.166){  // print to show working correctly
                        System.out.println("The NS light turns green");
                    }
                    break;
                case 9:  // NS arrow turns off
                    GreenArrow = false;
                    eventCreator = new Events(7, clock + 0.03333);  // light changes in 2 minutes
                    eventQueue.addToManager(eventCreator);
                    if (clock > 500 && clock <= 500.166){  // print to show working correctly
                        System.out.println("The NS arrow turns off");
                    }
                    break;
                case 10:  // should be the shutdown event
                    System.out.println("Should be shutdown event but we are still in the switch.");
                    break;
                default:  // event type is not one that we've defined
                    System.out.println("This is a bad event of type " + currentEvent.eventType + " at " + clock + " time.");
                    break;
            }  // end of switch
            eventQueue.removeEvent(0);  // removes event we've finished dealing with
            currentEvent = eventQueue.getValue(0);  // gets the next event (chronologically)
            timesThroughLoop++;
        }  // end of while
        double avgCarWait = totalWaitAll / carsThroughLine;
        double avgEWWait = totalWaitEW / EWCarsThroughLine;
        double avgNSWait = totalWaitNS / NSCarsThroughLine;
        double avgEWCars = (double)totalCarsInEW/timesThroughLoop;
        double avgNSCars = (double)totalCarsInNS/timesThroughLoop;
        System.out.println();
        System.out.println("Printing the Statistics for this Run");
        System.out.print("A total of " + carArrivals + " cars arrived at the intersection");
        System.out.println(" and " + carsThroughLine + " passed through it.");
        System.out.print(NSCarsThroughLine + " cars travelling north on the north-south road and " + EWCarsThroughLine);
        System.out.println(" cars travelling on the east-west road passed through the intersection.");
        System.out.print("The average wait time for a car on the EW road was " + avgEWWait + " hours with a ");
        System.out.println("variance of " + ((EWWaitSquared/EWCarsThroughLine)-(avgEWWait*avgEWWait)) + " hours.");
        System.out.print("The average wait time for a car going north on the NS road was " + avgNSWait + " hours with a ");
        System.out.println("variance of " + ((NSWaitSquared/NSCarsThroughLine)-(avgNSWait*avgNSWait)) + " hours.");
        System.out.print("The average wait time for a car in general was " + avgCarWait + " hours with a ");
        System.out.println("variance of " + ((totalWaitSquared/carsThroughLine)-(avgCarWait*avgCarWait)) + " hours.");
        System.out.println("The average number of cars waiting on the EW road was " + avgEWCars);
        System.out.println("The average number of cars waiting on the NS road was " + avgNSCars);
    } // end of main

    public static double TimetoArriveorServe(double rate) {
        double deltime;
        double bigx;
        bigx=Math.random();
        if(bigx>0.999)bigx=Math.random();
        deltime=-Math.log(1.0-bigx)/rate;
        return deltime;
    } // end of TimetoArriveorServe
}  // end of Driver