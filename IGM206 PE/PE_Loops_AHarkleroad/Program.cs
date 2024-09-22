/*
 * Aizlynn Harkleroad
 * 
 * PE - Loops
 * No known bugs or errors
 */

namespace PE_Loops_AHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // variable declaration
            int countDownFrom100 = 100;
            int countUpTo25 = 0;
            int boxWidth;
            int boxHeight;

            // print the numbers 0-5 using a for loop
            for (int i = 0; i <= 5; i++) 
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            // print the numbers 100-95 using a do/while loop
            do
            {
                Console.WriteLine(countDownFrom100);
                countDownFrom100--;
            }
            while (countDownFrom100 >= 95);
            Console.WriteLine();

            // print out multiples of 5 from 0-25 using a while loop
            while (countUpTo25 <= 25)
            {
                // checks if the number is a multiple of 5
                if (countUpTo25 % 5 == 0)
                {
                    Console.WriteLine(countUpTo25);
                }
                countUpTo25++;
            }
            Console.WriteLine();

            // prints a solid box based on dimensions inputted by the user
            Console.Write("Enter a width: ");
            boxWidth = int.Parse(Console.ReadLine());
            Console.Write("Enter a height: ");
            boxHeight = int.Parse(Console.ReadLine());
            // prints given number of rows (based on height output)
            for (int i = 0; i < boxHeight; i++)
            {
                // prints given number of columns (based on width input)
                for (int j = 0; j < boxWidth; j++)
                {
                    Console.Write("O");
                }
                // jumps to new line to start next row
                Console.WriteLine();
            }
            Console.WriteLine();

            // prints an empty box based on dimensions inputted by the user
            // prints an O if it is on the border of the rectangle
            for (int i = 0; i < boxHeight; i++)
            {
                // controls number of columns (based on width input)
                for (int j = 0; j < boxWidth; j++)
                {
                    // prints an O if it's the first or last row of the rectangle or first or last position in the row
                    if (i == 0 || i == boxHeight - 1 || j == 0 || j == boxWidth - 1)
                    {
                        Console.Write("O");
                    }
                    // prints a space if inside the rectangle
                    else
                    {
                        Console.Write(" ");
                    }
                }
                // jumps to new line to start next row
                Console.WriteLine();
            }
        }
    }
}
