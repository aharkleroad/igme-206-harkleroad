/*
 * Aizlynn Harkleroad
 * No known issues
 */

namespace PE_CastingMathDocumentation_AizlynnHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // variable declaration and assignment
            String playerName = "Frankie";
            int totalHoursPlayed = 274;
            // represents 2 points in 2D space
            int xCoordinatePoint1 = -13;
            int yCoordinatePoint1 = 51;
            int xCoordinatePoint2 = 17;
            int yCoordinatePoint2 = 28;
            double distance;
            // holds 2 floating point numbers
            float numberA = 7.9f;
            float numberB = 2.25f;
            // performs floating point and integer addition
            float numberSum = numberA + numberB;
            int wholeNumberSum = (int)numberA + (int)numberB;
            int degrees = 60;
            double radians = degrees * (Math.PI / 180);

            // prints addition calculations
            Console.WriteLine("--- ADDITION ---");
            Console.WriteLine("Number A: " + numberA);
            Console.WriteLine("Number B: " + numberB);
            Console.WriteLine(numberA + " + " + numberB + " = " + numberSum);
            Console.WriteLine("Now I'll just add the whole number parts.");
            Console.WriteLine((int)numberA + " + " + (int)numberB + " = " + wholeNumberSum);
            Console.WriteLine();
            // prints and performs division and modulus calculations
            Console.WriteLine("--- DIVISION and MODULUS ---");
            Console.WriteLine(playerName + " has played a game for " + totalHoursPlayed + " hours.");
            Console.WriteLine("They have played for " + (totalHoursPlayed / 24) + " days and " + (totalHoursPlayed % 24) + " hours.");
            Console.WriteLine();
            // prints and performs trig calculations
            Console.WriteLine("--- SINE and COSINE ---");
            Console.WriteLine(degrees + " degrees is " + radians + " radians.");
            Console.WriteLine("The sine is " + Math.Sin(radians));
            Console.WriteLine("The cosine is " + Math.Cos(radians));
            Console.WriteLine();
            // prints two points
            Console.WriteLine("--- DISTANCE ---");
            Console.WriteLine("Point One: (" + xCoordinatePoint1 + "," + yCoordinatePoint1 + ")");
            Console.WriteLine("Point Two: (" + xCoordinatePoint2 + "," + yCoordinatePoint2 + ")");
            // computes distance between the points based on distance formula and prints
            distance = Math.Sqrt(Math.Pow(xCoordinatePoint2 - xCoordinatePoint1, 2) + Math.Pow(yCoordinatePoint2 - yCoordinatePoint1, 2));
            Console.WriteLine("The distance between the points is " + distance);
            Console.WriteLine();
            // rounds the distance two ways and prints it
            Console.WriteLine("--- ROUNDING ---");
            Console.WriteLine("The distance is " + distance + ", which is approximately " + Math.Round(distance) + " units, or " +
               Math.Round(distance, 3) + " to be more precise.");
        }
    }
}
