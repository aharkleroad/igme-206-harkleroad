/*
 * Aizlynn Harkleroad
 * 
 * HW5 - TheFarmstead
 * https://docs.google.com/document/d/1xnF9pZIhLC-PW3OAOktW15VzMtAktTZWnHEsuQSDBpQ/edit?tab=t.0
 * No known bugs or errors
 */

namespace HW_TheFarmstead_AHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // variable declaration
            int numberOfCrops;
            Crop[] cropTypes;
            int numberOfFields;
            string farmName;
            int maintenanceCost;
            double startingMoney;
            Farm myFarm;
            char input = 'q';

            // print introduction and get user input to instantiate Farm and Crop objects
            Console.WriteLine("Welcome to Farmstead, your virtual farming adventure!");
            Console.WriteLine("Start your farming journey by defining the crops available and naming your farm.");
            Console.WriteLine();

            numberOfCrops = SmartConsole.GetValidNumericInput("How many types of crops do you want to define?", 1, 5);
            cropTypes = new Crop[numberOfCrops];
            // creates one Crop object for each crop the user wants to define
            for (int i = 0; i < numberOfCrops; i++)
            {
                // local variable declaration for Crop instantiation
                string cropName;
                double cropCost;
                int daysUntilHarvest;
                // prompt user for input
                Console.WriteLine("Define crop type #" + (i + 1));
                cropName = SmartConsole.GetPromptedInput("Name:");
                cropCost = SmartConsole.GetValidNumericInput("Cost:", 1, 500);
                daysUntilHarvest = SmartConsole.GetValidNumericInput("Days until harvest:", 1, 10);
                // save the Crop so it can be accessed later
                cropTypes[i] = new Crop(cropName, daysUntilHarvest, cropCost);
                Console.WriteLine();
            }

            // get user input to create the Farm object
            farmName = SmartConsole.GetPromptedInput("Please name your farm:");
            Console.WriteLine();
            numberOfFields = SmartConsole.GetValidNumericInput("How many fields are available for planting:", 1, 5);
            Console.WriteLine();
            startingMoney = SmartConsole.GetValidNumericInput("How much money are you starting with:", 1, 1000);
            Console.WriteLine();
            maintenanceCost = SmartConsole.GetValidNumericInput("What is the daily maintenance cost:", 1, 50);
            Console.WriteLine();
            myFarm = new Farm(farmName, cropTypes, numberOfFields, startingMoney, maintenanceCost);
            Console.WriteLine("*** " + myFarm.Name + ", ready for a fruitful season! ***");

            // continues the game while the farm still has money and the player doesn't quit
            while (myFarm.Money > 0 && input != '4')
            {
                // print farm info and menu options and then get input from user on what they want to do today
                myFarm.PrintStatus();
                Console.WriteLine("\t1. Plant crops");
                Console.WriteLine("\t2. Harvest and sell produce");
                Console.WriteLine("\t3. Do nothing today");
                Console.WriteLine("\t4. Quit");
                input = SmartConsole.GetPromptedChoice(">", new char[] { '1', '2', '3', '4' });
                Console.WriteLine();

                // executes different actions based on the user's input
                switch (input)
                {
                    // plants crops
                    case '1':
                        myFarm.Plant();
                        break;
                    // harvests a field
                    case '2':
                        myFarm.Harvest();
                        break;
                    // does nothing
                    case '3':
                    // quits
                    case '4':
                        break;
                    // invalid input
                    default:
                        Console.WriteLine("Input not recognized");
                        break;
                }
                // complete daily items that happen regardless of player action
                // ie: pay the maintenance cost, generate weather events, etc
                myFarm.DaysPassed();
                Console.WriteLine();
            }

            // if the game ends because the farm ran out of money, print the lose ending
            if (myFarm.Money <= 0)
            {
                SmartConsole.PrintError(myFarm.Name + " ran out of money!");
            }
            // if the player quit and had more than $0, print the win ending
            else
            {
                SmartConsole.PrintSuccess(String.Format("You quit with {0:C2} in the bank!", myFarm.Money));
            }
        }
    }
}
