/*
 * Aizlynn Harkleroad
 * 
 * PE - File IO
 * No known bugs or issues
 */

namespace PE_FileIO_AHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // variable declaration
            PlayerManager manager = new PlayerManager();
            string input = "";

            // until the player enters quit, prompt them for input
            while (input != "quit")
            {
                Console.Write("Create, print, save, load, or quit? >> ");
                input = Console.ReadLine().Trim().ToLower();

                switch (input)
                {
                    // creates a Player object and adds it to the list
                    case "create":
                        string name;
                        bool isInteger;
                        int strength;
                        int health;

                        Console.Write("What is the player's name? ");
                        name = Console.ReadLine().Trim();
                        Console.Write("What is the player's strength? ");
                        isInteger = int.TryParse(Console.ReadLine(), out strength);
                        while (isInteger == false) 
                        {
                            Console.Write("Strength must be a whole number. What is the player's strength? ");
                            isInteger = int.TryParse(Console.ReadLine(), out strength);
                        }
                        Console.Write("What is the player's health? ");
                        isInteger = int.TryParse(Console.ReadLine(), out health);
                        while (isInteger == false)
                        {
                            Console.Write("Health must be a whole number. What is the player's health? ");
                            isInteger = int.TryParse(Console.ReadLine(), out health);
                        }

                        manager.CreatePlayer(name, strength, health);
                        Console.WriteLine();
                        break;
                    // prints each player that has been created 
                    case "print":
                        manager.Print();
                        Console.WriteLine();
                        break;
                    // saves all the current players to a file
                    case "save":
                        manager.Save();
                        Console.WriteLine();
                        break;
                    // loads the players saved to the file to the list
                    case "load":
                        manager.Load();
                        Console.WriteLine();
                        break;
                    // ends the program
                    case "quit":
                        Console.WriteLine("Goodbye!");
                        break;
                    // prints an error
                    default:
                        Console.WriteLine("Invalid input, please enter create, print, save, load, or quit.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
