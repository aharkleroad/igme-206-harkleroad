/*
 * Aizlynn Harkleroad
 * 
 * HW - Stats Analysis
 * No known bugs or issues
 */

namespace HW_StatsAnalysis_AHarkleroad
{
    internal class Program
    {
        // checks for any errors in user input for player stats
        // returns true if there are errors and false if there are not
        public static bool AreThereAnyErrors(int playerNumber, string name, int gamesPlayed, int gamesWon, int gamesLost, double timePlayed)
        {
            // declare and initialize variables
            // variables track if any of the errors are executed
            // if there are no errors, all variables should remain false
            bool hasEmptyName = false;
            bool isLessThanZero = false;
            bool isIncorrectSum = false;
            bool hasNotPlayed = false;
            // changes the text color of any errors printed to red
            Console.ForegroundColor = ConsoleColor.Red;

            // if the player name is empty (user only entered whitespace), print an error
            // then changes error tracking variable (hasEmptyName) to true
            if (name.Length == 0)
            {
                Console.WriteLine("ERROR: Invalid name for player " + playerNumber);
                hasEmptyName = true;
            }

            // if any of the numeric values are negative (impossible), print an error
            // then changes error tracking variable (isLessThanZero) to true
            if (gamesPlayed < 0 || gamesWon < 0 || gamesLost < 0 || timePlayed < 0)
            {
                Console.WriteLine("ERROR: Games and total play time must be non-negative numbers!");
                isLessThanZero = true;
            }

            // if the games won and lost do not sum to equal the total games played, print an error
            // then changes error tracking variable (isIncorrectSum) to true
            if (gamesPlayed != gamesLost + gamesWon)
            {
                Console.WriteLine("ERROR: The number of games won and lost does not match the total number of games played!");
                isIncorrectSum = true;
            }

            // if the "player" has played no games or spent no time playing the game
            // then changes error tracking variable (hasNotPlayed) to true
            if (gamesPlayed == 0 || timePlayed == 0)
            {
                Console.WriteLine("ERROR: No stats to calculate for a player with zero games or no playtime!");
                hasNotPlayed = true;
            }

            // if the input has any of these problems, stop the analysis
            if (hasEmptyName || isLessThanZero || isIncorrectSum || hasNotPlayed)
            {
                Console.WriteLine();
                Console.WriteLine("Cannot continue with analysis. Goodbye.");
                // changes the text color back to white for next run
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            // otherwise continue
            else
            {
                // changes the text color back to white to print the summary table
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }

        static void Main(string[] args)
        {
            // variable declaration for user input and calculated stats
            // user input
            string player1Name;
            string player2Name;
            int player1GamesPlayed;
            int player2GamesPlayed;
            int player1GamesWon;
            int player2GamesWon;
            int player1GamesLost;
            int player2GamesLost;
            double player1TimePlayed;
            double player2TimePlayed;
            // calculated stats
            double player1AverageGameTime;
            double player2AverageGameTime;
            double player1WinRate;
            double player2WinRate;
            // assigned by programmer
            // used as an argument in AreThereAnyErrors
            // Tracks which player we are gathering info and error checking for
            int whichPlayer = 1;

            // introduce program
            Console.WriteLine("======== STATS ANALYZER ========");
            Console.WriteLine();

            // gather player info from the user
            // collects player 1 names, games played, games lost and won, and time spent playing in hours
            Console.Write("Enter the name for Player 1: ");
            player1Name = Console.ReadLine().Trim();
            Console.Write("Enter the number of games " + player1Name + " played: ");
            player1GamesPlayed = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of games " + player1Name + " won: ");
            player1GamesWon = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of games " + player1Name + " lost: ");
            player1GamesLost = int.Parse(Console.ReadLine());
            Console.Write("Enter the total time played by " + player1Name + " in hours: ");
            player1TimePlayed = double.Parse(Console.ReadLine());

            // if there are any errors with the user input for player 1, skip the rest of the program
            if (AreThereAnyErrors(whichPlayer, player1Name, player1GamesPlayed, player1GamesWon, player1GamesLost, player1TimePlayed))
            {
                return;
            }

            Console.WriteLine();
            // updates the player we are gathering info for to player 2
            whichPlayer = 2;

            // gathers the same info from the user for player 2
            Console.Write("Enter the name for Player 2: ");
            player2Name = Console.ReadLine().Trim();
            Console.Write("Enter the number of games " + player2Name + " played: ");
            player2GamesPlayed = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of games " + player2Name + " won: ");
            player2GamesWon = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of games " + player2Name + " lost: ");
            player2GamesLost = int.Parse(Console.ReadLine());
            Console.Write("Enter the total time played by " + player2Name + " in hours: ");
            player2TimePlayed = double.Parse(Console.ReadLine());

            // if there are any errors with the user input for player 2, skip the rest of the program
            if (AreThereAnyErrors(whichPlayer, player2Name, player2GamesPlayed, player2GamesWon, player2GamesLost, player2TimePlayed))
            {
                return;
            }
            Console.WriteLine();

            // calculates each player's win rate and average time spent per game
            // converts games won to type double to avoid integer division
            player1WinRate = (double)player1GamesWon / player1GamesPlayed;
            player2WinRate = (double)player2GamesWon / player2GamesPlayed;
            // multiplies time played by 60 to get time in minutes
            player1AverageGameTime = (player1TimePlayed * 60) / player1GamesPlayed;
            player2AverageGameTime = (player2TimePlayed * 60) / player2GamesPlayed;

            // prints summary table
            // prints title
            Console.WriteLine("Summary Table:");
            // prints stats using string formatting
            // tabs used for spacing
            Console.WriteLine("\t\t\t\t{0}\t\t{1}", player1Name, player2Name);
            Console.WriteLine("\tGames Played:\t\t{0}\t\t{1}", player1GamesPlayed, player2GamesPlayed);
            Console.WriteLine("\tGames Won:\t\t{0}\t\t{1}", player1GamesWon, player2GamesWon);
            Console.WriteLine("\tGames Lost:\t\t{0}\t\t{1}", player1GamesLost, player2GamesLost);
            Console.WriteLine("\tTotal Time (hr):\t{0:F1}\t\t{1:F1}", player1TimePlayed, player2TimePlayed);
            Console.WriteLine("\tWin Rate:\t\t{0:P3}\t\t{1:P3}", player1WinRate, player2WinRate);
            Console.WriteLine("\tAverage Time (min):\t{0:F0}\t\t{1:F0}", player1AverageGameTime, player2AverageGameTime);
            Console.WriteLine();
            Console.WriteLine();

            // prints which player has the better win rate
            // if player 1's win rate is higher, print that they have the better win rate
            if (player1WinRate > player2WinRate)
            {
                Console.WriteLine(player1Name + " has a better win rate!");
            }
            // if player 2's win rate is higher, print that they have the better win rate
            else if (player1WinRate < player2WinRate)
            {
                Console.WriteLine(player2Name + " has a better win rate!");
            }
            // otherwise, print that the win rates are tied
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }
    }
}
