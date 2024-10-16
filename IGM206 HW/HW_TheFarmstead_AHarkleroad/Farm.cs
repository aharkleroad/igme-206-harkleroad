using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_TheFarmstead_AHarkleroad
{
    internal class Farm
    {
        // field declaration
        private string name;
        private int daysPassed;
        private double currentMoney;
        private double maintenanceCost;
        private int numberOfPlots;
        private Crop[] availableCrops;
        private Crop[] currentCrops;
        private Random rng;

        // Farm properties
        // returns or sets the Farm's name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // returns or sets the number of days that have passed on the Farm
        public int Days
        {
            get { return daysPassed; }
            set { daysPassed = value; }
        }

        // returns or sets the amount of money the Farm has
        public double Money
        {
            get { return currentMoney; }
            set { currentMoney = value; }
        }

        // parameterized Farm constructor
        public Farm(string name, Crop[] availableCrops, int numPlots, double currentMoney, double maintenanceCost)
        {
            this.name = name;
            this.availableCrops = availableCrops;
            this.numberOfPlots = numPlots;
            this.currentMoney = currentMoney;
            this.maintenanceCost = maintenanceCost;
            this.daysPassed = 1;
            this.currentCrops = new Crop[numPlots];
            this.rng = new Random();
        }

        // Farm methods
        // Prints each field
        // Shows that the fields are empty, that they can be harvested, or how many days until they can be harvested 
        public string BuildFieldList()
        {
            // variable declaration
            string fieldList = "";

            for (int i = 0; i < numberOfPlots; i++)
            {
                fieldList += " - Field " + (i + 1) + ": ";
                if (currentCrops[i] == null)
                {
                    fieldList += "Empty\n";
                }
                else
                {
                    fieldList += currentCrops[i].ToString() + "\n";
                }
            }
            return fieldList;
        }

        // performs the daily Farm activities
        public void DaysPassed()
        {
            // variable declaration
            int weather;

            // pays maintenance cost
            currentMoney -= maintenanceCost;
            // determines the weather
            weather = rng.Next(1, 101);
            // there is a blight and all crop die
            if (weather > 0 && weather <= 5)
            {
                SmartConsole.PrintError("Blight has struck the farm! \nAll our crops are dead :(");
                for (int i = 0; i < currentCrops.Length; i++)
                {
                    currentCrops[i] = null;
                }
            }
            // it rains and crops do not grow
            else if (weather > 5 && weather <= 25)
            {
                SmartConsole.PrintWarning("It rained. Nothing grew today \nHopefully tomorrow will be better.");
            }
            // there is no weather event and all crops grow
            else
            {
                for (int i = 0; i < currentCrops.Length; i++)
                {
                    if (currentCrops[i] != null)
                    {
                        currentCrops[i].DayPassed();
                    }
                }
            }
            // increases the day
            daysPassed++;
        }

        // attempts to plant a Crop in an empty field
        public void Plant()
        {
            // variable declaration
            bool isEmptyField = false;
            int whereToPlant = -2;
            Crop cropToPlant;
            int cropPosition;

            // checks that there is at least one empty field
            for (int i = 0; i < currentCrops.Length; i++)
            {
                if (currentCrops[i] == null)
                {
                    isEmptyField = true;
                    whereToPlant = i;
                    break;
                }
            }

            // if there is, print the Crop options and get user input to determine what Crop should be planted there
            if (isEmptyField)
            {
                Console.WriteLine("Select a crop to plant:");

                for (int i = 0; i < availableCrops.Length; i++)
                {
                    Console.WriteLine("\t{0}. {1} (Cost: {2:C2})", (i + 1), availableCrops[i].Name, availableCrops[i].Cost);
                }
                cropPosition = SmartConsole.GetValidNumericInput(">", 1, availableCrops.Length) - 1;
                cropToPlant = new Crop(availableCrops[cropPosition]);

                // plant the Crop if the Farm can afford it
                if (currentMoney - cropToPlant.Cost > 0)
                {
                    currentCrops[whereToPlant] = cropToPlant;
                    SmartConsole.PrintSuccess(String.Format("{0} planted in field #{1}.", cropToPlant.Name, (whereToPlant + 1)));
                    currentMoney -= cropToPlant.Cost;
                }
                // otherwise tell the player it can't be bought
                else
                {
                    SmartConsole.PrintError("Not enough funds to plant " + cropToPlant.Name);
                }
            }
            // otherwise tell the player all the fields are full
            else
            {
                SmartConsole.PrintError("Unable to plant right now. Harvest something first.");
            }
        }

        // attempts to harvest a Crop from a given field
        public void Harvest()
        {
            // variable declaration
            bool isPlanted = false;
            int fieldToHarvest;

            // checks that at least one field has been planted
            for (int i = 0; i < currentCrops.Length; i++)
            {
                if (currentCrops[i] != null)
                {
                    isPlanted = true;
                    break;
                }
            }

            // if it has, print the fields and ask the user which field they would like to harvest
            if (isPlanted)
            {
                Console.WriteLine("Which field would you like to harvest?");
                Console.WriteLine(this.BuildFieldList());
                fieldToHarvest = SmartConsole.GetValidNumericInput(">", 1, numberOfPlots) - 1;

                // check if they can harvest the field
                if (currentCrops[fieldToHarvest] != null)
                {
                    if (currentCrops[fieldToHarvest].CanHarvest)
                    {
                        // harvest and sell the Crop
                        this.Money += currentCrops[fieldToHarvest].SellingPrice;
                        SmartConsole.PrintSuccess(currentCrops[fieldToHarvest].Name + " sold for " + currentCrops[fieldToHarvest].SellingPrice);
                        currentCrops[fieldToHarvest] = null;
                    }
                    // otherwise, print that they can't
                    else
                    {
                        SmartConsole.PrintError("Field " + (fieldToHarvest + 1) + " must be done growing before it can be harvested!");
                    }
                }
                // otherwise, print that they can't
                else
                {
                    SmartConsole.PrintError("You must plant something in field " + (fieldToHarvest + 1) + " before it can be harvested!");
                }
            }
            // otherwise, print that they can't
            else
            {
                SmartConsole.PrintError("You must plant something before you can harvest!");
            }
        }

        // prints Farm stats, fields, and the potential earnings the Farm could make
        public void PrintStatus()
        {
            double potentialEarnings = 0;
            for (int i = 0; i < currentCrops.Length; i++)
            {
                if (currentCrops[i] != null && currentCrops[i].CanHarvest)
                {
                    potentialEarnings += currentCrops[i].SellingPrice;
                }
            }
            Console.WriteLine("Day {0} at {1} with {2:C2} on hand.", daysPassed, name, currentMoney);
            Console.WriteLine("We have {0:C2} potential earnings from the fields ready to harvest.", potentialEarnings);
            Console.WriteLine(BuildFieldList());
        }
    }
}
