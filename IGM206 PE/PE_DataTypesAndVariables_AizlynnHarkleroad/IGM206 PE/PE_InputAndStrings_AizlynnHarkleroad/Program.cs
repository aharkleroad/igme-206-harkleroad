/*
 * Aizlynn Harkleroad
 * No known bugs or errrors
 */

namespace PE_InputAndStrings_AizlynnHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // variable declaration
            String name;
            String favoriteColor;
            String petName;
            String favoriteBand;

            // prompts for and gathers user info
            Console.Write("What is your name? ");
            name = Console.ReadLine();
            Console.WriteLine("Welcome " + name + "!");
            Console.Write("What is your favorite color? ");
            favoriteColor = Console.ReadLine();
            Console.Write("What is your pet's name? ");
            petName = Console.ReadLine();
            Console.Write("What is your favorite band? ");
            favoriteBand = Console.ReadLine();
            Console.WriteLine();

            // uses string properties and methods to analyze information with spaces between each line
            Console.WriteLine("Your name is " + name.Length + " letters long");
            Console.WriteLine("and " + (name.Length - petName.Length) + " letters longer than " + petName + "'s name.");
            Console.WriteLine();
            Console.WriteLine("I wonder if " + petName.ToUpper() + " and " + favoriteBand.ToUpper() +
                " like " + favoriteColor.ToUpper() + " as much as you do?");
            Console.WriteLine();
            // creates new name
            Console.WriteLine("Maybe I should just call you " + name.ToUpper()[0] + favoriteColor.ToLower()[0] + favoriteColor.ToLower()[1] +
                petName.ToLower()[0] + petName.ToLower()[1] + favoriteBand.ToLower()[0] + favoriteBand.ToLower()[1] + "?");
        }
    }
}