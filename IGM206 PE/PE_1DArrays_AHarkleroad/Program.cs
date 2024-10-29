/*
 * Aizlynn Harkleroad
 * 
 * PE - 1D Arrays
 * No known bugs or issues
 */

namespace PE_1DArrays_AHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ VARIABLES ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Some local variables to support playing with different
            // types of arrays in different ways.
            double[] scores = { 1, 1.23, 2, 2.34, 3, 3.45, 4, 4.56, 5, 5.67, 6, 6.78, 7, 7.89, 8, 8.90, 9, 9.01, 10 };
            int arraySize = 3;
            bool[] values = new bool[arraySize];
            double sum;
            double average;
            string name; // Yes, this is an array too! Strings use a char[] under the hood.
            const int MaxNum = 50; // This will always be >5
            int index;
            int[] fives;
            int trackMultiples = 0;



            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ FILL ARRAYS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Use a loop to prompt the user for a name that is at least 5 characters long

            // prompts the user for a name the first time
            Console.Write("Please enter a name that is at least 5 letters long: ");
            name = Console.ReadLine();
            // asks them for another name if it is less than five letters long
            while (name.Trim().Length < 5)
            {
                Console.WriteLine("That name is " + name.Trim().Length + " letters long.");
                Console.Write("Please enter a name that is at least 5 letters long: ");
                name = Console.ReadLine();
            }
            Console.WriteLine();

            // TODO: Figure out how many multiples of 5 there are between 5 and MaxNum (inclusive),
            //       initialize fives to have an array that will hold that many numbers,
            //       then use a loop to fill it

            // checks each number from 5 to MaxNum
            for (int i = 5; i <= MaxNum; i++)
            {
                // if it is divisible by five, the tracker is increased
                if (i % 5 == 0)
                {
                    trackMultiples++;
                }
            }
            // assigns the array fives the same number of elements as the number of multiples of five we found
            // elements = tracker
            fives = new int[trackMultiples];
            // check each number from 5 to MaxNum again
            for (int i = 5; i <= MaxNum; i++)
            {
                // if it is divisible by five, add it to the fives array
                if (i % 5 == 0)
                {
                    fives[(i-5)/5] = i;
                }
            }

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ CALCS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Use a loop to calculate the sum of all values in the scores array.

            sum = 0;
            // add each element of scores to sum
            for (int i = 0; i < scores.Length; i++)
            {
                sum += scores[i];
            }

            // TODO: Use the sum and size of the scores array to calculate the average
            average = sum / scores.Length;


            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ OUTPUT ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Without using Substring, print out every other character in the name
            //  (Use a loop and access the characters 1 by 1 instead)

            Console.Write("Nickname: ");
            // goes through each letter of the name
            for (int i = 0; i < name.Length; i++)
            {
                // if it is at an even index, print the letter
                // prints every other letter, starting with the first
                if (i % 2 == 0)
                {
                    Console.Write(name[i]);
                }
            }
            Console.WriteLine("\n");

            // TODO: Print the fives array all on 1 line

            Console.Write("Fives: ");
            // prints each element of fives one by one
            for (int i = 0; i < fives.Length; i++)
            {
                Console.Write(fives[i] + " ");
            }
            Console.WriteLine("\n");

            // TODO: Print out the sum and average of the scores as well as a list of all scores
            // that are divisible by 2
            Console.WriteLine("Total score: " + sum);
            Console.WriteLine("Average score: " + average);
            Console.WriteLine();
            Console.Write("Scores divisible by 2: ");
            // checks each element of scores
            for (int i = 0; i < scores.Length; i++)
            {
                // if they are even (divisible by 2) they are printed
                if (scores[i] % 2 == 0)
                {
                    Console.Write(scores[i] + " ");
                }
            }
        }
    }
}
