/*
 * Aizlynn Harkleroad
 * 
 * PE - Lists
 * No known bugs or issues
 */

namespace PE_Lists_AHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // variable declaration
            Random randomNumberGenerator = new Random();
            Player player1;
            Player player2;
            string command = "";
            List<string> stolenItems = new List<string>();

            stolenItems.Add("new data");
              stolenItems.Insert(stolenItems.Count, "new data");
            stolenItems.Insert(stolenItems.Count - 1, "new data");
             // stolenItems[stolenItems.Count] = "new data";
            stolenItems[stolenItems.Count - 1] = "new data";

            // prompt the user for player names and instantiate player objects with them
            Console.Write("Enter Player 1's name: ");
            player1 = new Player(Console.ReadLine().Trim());
            Console.Write("Enter Player 2's name: ");
            player2 = new Player(Console.ReadLine().Trim());
            Console.WriteLine();

            // prompt the user to enter the names of 5 items
            // add them to either player 1 or player 2's inventory based on a random number generator
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter an item: ");
                if (randomNumberGenerator.NextDouble() > 0.5)
                {
                    player1.AddToInventory(Console.ReadLine().Trim());
                }
                else
                {
                    player2.AddToInventory(Console.ReadLine().Trim());
                }
            }

            // print each player's current inventory
            player1.PrintInventory();
            Console.WriteLine();
            player2.PrintInventory();
            Console.WriteLine();

            // prompt the user to enter a command until they enter "quit"
            // the user can print player inventories, steal items, or add items to a player's inventory
            while (command != "quit")
            {
                Console.Write("Enter a command (print, steal, or quit) or an item: ");
                command = Console.ReadLine().Trim().ToLower();

                switch (command)
                {
                    // prints players' inventories
                    case "print":
                        player1.PrintInventory();
                        Console.WriteLine();
                        player2.PrintInventory();
                        break;
                    // steals an item at a given index from a specified player
                    case "steal":
                        Player stoleFrom;
                        int item;
                        string itemName;
                        Console.Write("Which player would you like to steal from (1 or 2)? ");
                        if (int.Parse(Console.ReadLine()) == 1)
                        {
                            stoleFrom = player1;
                        }
                        else
                        {
                            stoleFrom = player2;
                        }
                        Console.Write("Which item # would you like to steal from " + stoleFrom.Name + "? ");
                        item = int.Parse(Console.ReadLine());
                        itemName = stoleFrom.GetItemInSlot(item);
                        // if there is an item at that index for a given player, add the item to the list 
                        // of stolen items
                        if (itemName != null)
                        {
                            stolenItems.Add(itemName);
                        }
                        break;
                    // ends the program
                    case "quit":
                        break;
                    // adds any other input to a player's inventory
                    default:
                        if (randomNumberGenerator.NextDouble() > 0.5)
                        {
                            player1.AddToInventory(command);
                        }
                        else
                        {
                            player2.AddToInventory(command);
                        }
                        break;
                }
                Console.WriteLine();
            }

            // prints the stolen items
            Console.WriteLine("You stole " + stolenItems.Count + " item(s):");
            for (int i = 0; i < stolenItems.Count; i++)
            {
                Console.WriteLine("\t" + stolenItems[i]);
            }
        }
    }
}
