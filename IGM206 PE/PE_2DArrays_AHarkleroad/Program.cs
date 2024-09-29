/*
 * Aizlynn Harkleroad
 * 
 * PE - 2D Arrays
 * No known bugs or issues
 */

namespace PE_2DArrays_AHarkleroad
{
    internal class Program
    {
        // fills each element of a 2D array with numbers
        // assigns the first element the value given, with the value of each subsequent element increasing by 1
        public static void Fill2DArray(int[,] array, int startNum)
        {
            // for statements used to access each element
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for(int column = 0; column < array.GetLength(1); column++)
                {
                    array[row, column] = startNum;
                    startNum++;
                }
            }
        }

        // prints the labels for and elements of a 2D array
        // maintains the size of the array in the printing (ex: 2 x 3)
        public static void Print2DArray(int[,] array)
        {
            // prints the labels for the columns
            Console.Write("\t");
            for (int column = 1; column <= array.GetLength(1); column++)
            {
                Console.Write("Col " + column + "\t");
            }
            Console.WriteLine();
            // prints row labels and each element
            for (int row = 0; row < array.GetLength(0); row++)
            {
                Console.Write("Row " + (row + 1) + ":\t");
                for (int column = 0; column < array.GetLength(1); column++)
                {
                    Console.Write(array[row, column] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            // Init a 2D array of 2 x 4 elements with sequential values
            int[,] integerArray = new int[2, 4];
            Fill2DArray(integerArray, 5);

            // Print values in the array
            Print2DArray(integerArray);
        }
    }
}
