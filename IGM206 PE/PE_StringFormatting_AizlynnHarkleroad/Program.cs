namespace PE_StringFormatting_AizlynnHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // variable declaration and assignment
            string name;
            string title;
            string nameWithTitle;
            double wallet;
            int health = 100;
            string action;
            int actionHealthReq;
            string item;
            double itemCost;
            const string StatsUpdateTemplate = "{0}, you now have {1} health and {2:C} remaining.";

            // gathers starting info about the adventurer and prints greeting using string formatting
            Console.Write("What is your name, brave adventurer? ");
            name = Console.ReadLine();
            Console.Write("What is your title? ");
            title = Console.ReadLine();
            Console.Write("How much money are you carrying? $");
            wallet = double.Parse(Console.ReadLine());
            // defines nameWithTitle
            nameWithTitle = String.Format("{0} the {1}", name, title);
            Console.WriteLine("Welcome {0}!", nameWithTitle);
            Console.WriteLine();

            // asks player what they want to do next and the cost of that action and updates stats
            Console.Write("What do you want to do next? ");
            action = Console.ReadLine();
            Console.Write("How much health does it take to do this? ");
            actionHealthReq = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Ok, let's see you {0}!", action);
            health -= actionHealthReq;
            // prints stat updates after the action is taken
            Console.WriteLine(StatsUpdateTemplate, nameWithTitle, health, wallet);
            Console.WriteLine();

            // asks player what they want to buy and the cost of the product and updates stats
            Console.Write("What do you want to buy? ");
            item = Console.ReadLine();
            Console.Write("How much does it normally cost? $");
            itemCost = double.Parse(Console.ReadLine()) * 1.1;
            Console.WriteLine();
            Console.WriteLine("You bought {0} for {1:C3}!", item, itemCost);
            wallet -= itemCost;
            // prints stat updates after the product is bought
            Console.WriteLine(StatsUpdateTemplate, nameWithTitle, health, wallet);
        }
    }
}
