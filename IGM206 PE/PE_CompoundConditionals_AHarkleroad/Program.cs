/*
 * Aizlynn Harkleroad
 * PE - Compound Conditionals
 * No known issues or bugs
 */

using System;

namespace PE_CompoundConditionals_AHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ~~ Instructions ~~
            //
            // Only add code where clearly marked with:
            //
            //  - ADD CODE HERE
            //        - Areas you'll need to replace with multiple new statements)
            //
            //  - true /* REPLACE THIS */
            //        - Areas you'll where you'll replace the hard-coded 'true' with a compound 
            //          conditional to make the if work correctly

            /****************************************************************************
            * Problem # 1
            ****************************************************************************/
            int population;
            int superHeroes;
            int aliens;

            // Print the header
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n** Problem #1 **");

            // Prompt for current number of people, aliens, and superheroes on Earth and parse the data
            Console.Write("What is the current population of Earth? ");
            population = int.Parse(Console.ReadLine());
            Console.Write("How many superheroes are alive and working? ");
            superHeroes = int.Parse(Console.ReadLine());
            Console.Write("How many aliens have invaded Earth? ");
            aliens = int.Parse(Console.ReadLine());

            // Use compound conditionals and an appropriate if-else statement to
            // determine the correct response.

            // The human population is less than aliens and 2 or fewer superheroes
            // DOOMED
            if (population < aliens && superHeroes <= 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The world is doomed!");
            }

            // Otherwise, there's hope!
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("There's hope for the world!");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            /****************************************************************************
            * Problem # 2
            ****************************************************************************/
            // Constants to make the if conditions more readable
            const int BiggerThanBreadbox = 1;
            const int SmallerThanBreadbox = 2;
            const int Animal = 1;
            const int Fruit = 2;
            const int Mineral = 3;

            // Variables you'll need
            int answer1;
            int answer2;

            // Print the header
            Console.WriteLine("\n\n** Problem #2 **");

            // Ask the user to enter the answer to two questions about the
            // properties (material and size) of an object they are thinking of as numbers
            // Then parse their responses to integers
            Console.WriteLine("Let's play 20 questions! Well... 2 questions.");
            Console.WriteLine("Think of any object and I will tell you what it is.");
            Console.Write(" - Question 1. Is it animal(1), fruit(2), or mineral(3)? ");
            answer1 = int.Parse(Console.ReadLine());
            Console.Write(" - Question 2. Is it bigger than a breadbox? yes(1), or no(2)? ");
            answer2 = int.Parse(Console.ReadLine());

            // Use compound conditionals and an appropriate if-else statement to
            // determine the correct response.
            Console.ForegroundColor = ConsoleColor.Green;

            // WOLF
            // User answered 1 and 1, so object is an animal and larger than a breadbox
            if (answer1 == Animal && answer2 == BiggerThanBreadbox)
            {
                Console.WriteLine("I guess you are thinking of a wolf!");
            }

            // SQUIRREL
            // User answered 1 and 2, so object is an animal and smaller than a breadbox
            else if (answer1 == Animal && answer2 == SmallerThanBreadbox)
            {
                Console.WriteLine("I guess you are thinking of a squirrel!");
            }

            // WATERMELON
            // User answered 2 and 1, so object is a fruit and larger than a breadbox
            else if (answer1 == Fruit && answer2 == BiggerThanBreadbox)
            {
                Console.WriteLine("I guess you are thinking of a watermelon!");
            }

            // KIWI
            // User answered 2 and 2, so object is a fruit and smaller than a breadbox
            else if (answer1 == Fruit && answer2 == SmallerThanBreadbox)
            {
                Console.WriteLine("I guess you are thinking of a kiwi!");
            }

            // CAR
            // User answered 3 and 1, so object is a mineral and larger than a breadbox
            else if (answer1 == Mineral && answer2 == BiggerThanBreadbox)
            {
                Console.WriteLine("I guess you are thinking of a car!");
            }

            // PAPERCLIP
            // User answered 3 and 2, so object is a mineral and smaller than a breadbox
            else if (answer1 == Mineral && answer2 == SmallerThanBreadbox)
            {
                Console.WriteLine("I guess you are thinking of a paperclip!");
            }

            // Anything else...
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice given");
            }
            Console.ForegroundColor = ConsoleColor.White;

            /****************************************************************************
            * Problem # 3
            ****************************************************************************/
            string month;
            int day;

            // Print the header
            Console.WriteLine("\n\n** Problem #3 **");

            // Prompt for user's birth month and day and format/parse the data
            Console.Write("What is your birth month? ");
            month = Console.ReadLine().ToLower().Trim();
            Console.Write("On which day were you born? ");
            day = int.Parse(Console.ReadLine());

            // Use compound conditionals and an appropriate if-else statement to
            // determine the correct response.
            Console.ForegroundColor = ConsoleColor.Green;
            // Their birth month is not January or February
            // Unknown astrological sign
            if (month != "january" && month != "february")
            {
                Console.WriteLine("Sorry, I don't know your sign.");
            }

            // Born in January, from the 1st - 19th
            // Capricorn
            else if (month == "january" && (day > 0 && day <= 19))
            {
                Console.WriteLine("Your sign is Capricorn.");
            }

            // Born in January, from the 20th - the 31st or, born in February, from the 1st - 18th
            // Aquarius
            else if (month == "january" && (day > 19 && day <= 31) || month == "february" && (day > 0 && day <= 18))
            {
                Console.WriteLine("Your sign is Aquarius.");
            }

            // Born in February, from the 19th - 29th
            // Pisces
            else if (month == "february" && (day > 18 && day <= 29))
            {
                Console.WriteLine("Your sign is Pisces.");
            }

            // Invalid day given, not part of the birth month
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid birthdate!");
            }
        }
    }
}
