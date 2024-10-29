/*
 * Aizlynn Harkleroad
 * PE - Input & Parsing
 * No known bugs or issues
 */

namespace PE_InputAndParsing_AizlynnHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // variable declaration
            string playerName;
            int totalHoursPlayed;
            int xCoordinatePoint1;
            int yCoordinatePoint1;
            int xCoordinatePoint2;
            int yCoordinatePoint2;
            double numberA;
            double numberB;
            double degrees;
            double radians;
            string rawUserInput;
            // not required by assignment write up but needed to save distance calculation for rounding
            double distance;

            // prompts the user for 2 numbers
            Console.WriteLine("--- ADDITION ---");
            Console.Write("What is the first number? ");
            rawUserInput = Console.ReadLine();
            numberA = double.Parse(rawUserInput);
            Console.Write("What is the second number? ");
            rawUserInput = Console.ReadLine();
            numberB = double.Parse(rawUserInput);
            // performs addition with the provided numbers
            Console.WriteLine(numberA + " + " + numberB + " = " + (numberA + numberB));
            Console.WriteLine("Now I'll just add the whole number parts.");
            Console.WriteLine((int)numberA + " + " + (int)numberB + " = " + ((int)numberA + (int)numberB));
            Console.WriteLine();

            // prompts for a player's name and how many hours they've logged in a game
            Console.WriteLine("--- DIVISION and MODULUS ---");
            Console.Write("What is that player's name? ");
            playerName = Console.ReadLine();
            Console.Write("How many hours have they logged? ");
            rawUserInput = Console.ReadLine();
            totalHoursPlayed = int.Parse(rawUserInput);
            // prints the info and calculates how many days and hours the user played for
            Console.WriteLine(playerName + " has played a game for " + totalHoursPlayed + " hours.");
            Console.WriteLine("They have played for " + (totalHoursPlayed / 24) + " days and " + (totalHoursPlayed % 24) + " hours.");
            Console.WriteLine();

            // prompts for an angle in degrees from the user
            Console.WriteLine("--- SINE and COSINE ---");
            Console.Write("Enter an angle in degrees: ");
            rawUserInput = Console.ReadLine();
            degrees = double.Parse(rawUserInput);
            // calculates and prints the angle in radians and it's sine and cosine
            radians = degrees * (Math.PI / 180);
            Console.WriteLine(degrees + " degrees is " + radians + " radians.");
            Console.WriteLine("The sine is " + Math.Sin(radians));
            Console.WriteLine("The cosine is " + Math.Cos(radians));
            Console.WriteLine();

            // prompts user for the coordinates of two points
            Console.WriteLine("--- DISTANCE and ROUNDING ---");
            Console.Write("Enter Point 1 X: ");
            rawUserInput = Console.ReadLine();
            xCoordinatePoint1 = int.Parse(rawUserInput);
            Console.Write("Enter Point 1 Y: ");
            rawUserInput = Console.ReadLine();
            yCoordinatePoint1 = int.Parse(rawUserInput);
            Console.Write("Enter Point 2 X: ");
            rawUserInput = Console.ReadLine();
            xCoordinatePoint2 = int.Parse(rawUserInput);
            Console.Write("Enter Point 2 Y: ");
            rawUserInput = Console.ReadLine();
            yCoordinatePoint2 = int.Parse(rawUserInput);
            // prints the two points and computes distance between them
            Console.WriteLine("Point One: (" + xCoordinatePoint1 + ", " + yCoordinatePoint1 + ")");
            Console.WriteLine("Point Two: (" + xCoordinatePoint2 + ", " + yCoordinatePoint2 + ")");
            distance = Math.Sqrt(Math.Pow(xCoordinatePoint2 - xCoordinatePoint1, 2) + Math.Pow(yCoordinatePoint2 - yCoordinatePoint1, 2));
            Console.WriteLine("The distance between the points is " + distance);
            // rounds the distance two ways and prints it
            Console.WriteLine("The distance is " + distance + ", which is approximately " + Math.Round(distance) + " units, or " +
               Math.Round(distance, 3) + " to be more precise.");
        }
    }
}
