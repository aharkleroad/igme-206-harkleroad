/*
 * Aizlynn Harkleroad
 * 
 * PE - Guessing Game
 * No known issues or bugs
 */

namespace PE_GuessingGame_AHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // declare variables
            bool isParsable;
            int turn = 0;
            int guess;
            Random randomNumberGenerator = new Random();
            // generate a random number for the user to guess between 0 and 100 and print it
            int numberToGuess = randomNumberGenerator.Next(0, 101);
            Console.WriteLine(numberToGuess);
            Console.WriteLine();

            // Prompt the user to guess the random number
            while (turn < 8)
            {
                turn++;
                Console.Write("Turn #" + turn + ": Guess a number between 0 and 100 (inclusive): ");
                isParsable = int.TryParse(Console.ReadLine(), out guess);
                // if the guess is not an integer or not between 0 and 100, print that it's an invalid input
                // do not count the guess as one of their 8 turns
                if (!isParsable || guess < 0 || guess > 100)
                {
                    Console.WriteLine("Invalid guess - try again");
                    turn--;
                }
                // if they guess a number lower than the random number, tell them the guess was too low
                else if (guess < numberToGuess)
                {
                    Console.WriteLine("Too low");
                }
                // if they guess a number higher than the random number, tell them the guess was too high
                else if (guess > numberToGuess)
                {
                    Console.WriteLine("Too high");
                }
                // if they get the number right, tell them and end the program
                else
                {
                    Console.WriteLine("Correct! You won in " + turn + " turns.");
                    return;
                }
                Console.WriteLine();
            }
            // if they don't guess it in 8 turns, tell them what the number was
            Console.WriteLine("You ran out of turns. The number was " + numberToGuess + ".");
        }
    }
}
