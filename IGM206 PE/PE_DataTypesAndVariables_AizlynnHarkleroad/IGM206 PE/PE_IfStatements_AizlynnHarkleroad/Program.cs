/*
 * Aizlynn Harkleroad
 * PE - If Statements
 * No known bugs or issues
 */

using System.Numerics;

namespace PE_IfStatements_AizlynnHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             *          --- Animal Crosssing NPC Scenario Table ---
             *     Scenario #   |    Character senses    |      Character reacts
             *          1       |       catch fish       |  The villager applaudes you for a successful catch!
             *          2       |      hit with net      |  The villager angrily tells you to knock it off.
             *          3       |          gift          |  Shirt: The villager says that your gift is sooooo their style!
             *                  |   --> shirt or peach   |  Peach: The villager thanks you for the snack.
             *                  |                        |  Unexpected: The villager is disgusted and asks you why you gave them this.
             *     Unexpected   |           N/A          |  The villager goes about their business and seems to not notice you.
             */

            // variable declaration
            string userInput;

            // prompts user to enter what an NPC sees/experiences
            Console.Write("What does the Animal Crossing villager sense? ");
            userInput = Console.ReadLine().ToLower().Trim();
            // the player catches a fish (scenario 1)
            if (userInput == "catch fish")
            {
                Console.WriteLine("The villager applaudes you for a successful catch!");
            }
            // the player hits the NPC with their net (scenario 2)
            else if (userInput == "hit with net")
            {
                Console.WriteLine("The villager angrily tells you to knock it off.");
            }
            // the player gives a gift to the NPC (scenario 3)
            else if (userInput == "gift")
            {
                Console.Write("What do you give the villager (shirt or peach)? ");
                userInput = Console.ReadLine().ToLower().Trim();
                // the player gifts a shirt
                if(userInput == "shirt")
                {
                    Console.WriteLine("The villager says that your gift is sooooo their style!");
                }
                // the player gifts a peach
                else if (userInput == "peach")
                {
                    Console.WriteLine("The villager thanks you for the snack.");
                }
                // the player gifts anything else
                else
                {
                    Console.WriteLine("The villager is disgusted and asks you why you gave them this.");
                }
            }
            // the player takes any other action (unexpected scenario)
            else
            {
                Console.WriteLine("The villager goes about its business and seems to not notice you.");
            }
        }
    }
}
