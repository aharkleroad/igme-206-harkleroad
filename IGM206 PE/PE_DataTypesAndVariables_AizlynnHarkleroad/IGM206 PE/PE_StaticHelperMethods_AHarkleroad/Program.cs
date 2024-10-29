/*
 * Aizlynn Harkleroad
 * 
 * PE _ Static Helper Methods
 * No known bugs or issues
 */

namespace PE_StaticHelperMethods_AHarkleroad
{
    internal class Program
    {
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // LEAVE THE REST OF THE CODE ALONE!
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// Helper written by Prof. Mesh
        /// Check if one number is a factor of another value
        /// </summary>
        /// <param name="factor">The factor to test</param>
        /// <param name="value">The value to check</param>
        /// <returns>True if value can be evenly divided by the factor</returns>
        public static bool IsFactorOf(int factor, int value)
        {
            // Return true if "factor" is smaller than "value"
            // and is evenly divisible into "value"
            return factor < value && value % factor == 0;
        }


        /// <summary>
        /// Input helper written by Prof. Mesh
        /// Uses the given string to prompt the user for input and set
        /// the color to cyan while they type.
        /// </summary>
        /// <param name="prompt">What to print before waiting for input</param>
        /// <returns>A trimmed version of what the user entered</returns>
        public static string GetPromptedInput(string prompt)
        {
            // Always print in white
            Console.ForegroundColor = ConsoleColor.White;

            // Print the prompt
            Console.Write(prompt + " ");

            // Switch color and get user input (trim too)
            Console.ForegroundColor = ConsoleColor.Cyan;
            string response = Console.ReadLine().Trim();

            // Switch back to white and then return response.
            Console.ForegroundColor = ConsoleColor.White;
            return response;
        }

        // checks if either number (a or b) is a factor of the other using IsFactorOf
        public static void CheckNumbers(int a, int b)
        {
            // if either one is a factor of the other, print that the numbers are awesome 
            if (IsFactorOf(a, b) || IsFactorOf(b, a))
            {
                Console.WriteLine(a + " & " + b + " are awesome numbers.");
            }
            // otherwise, print that they are ok
            else
            {
                Console.WriteLine(a + " & " + b + " are ok I guess.");
            }
        }

        // returns a secret code based on a name and two integers (a and b)
        public static int GetSecretCode(string name, int a, int b)
        {
            // secret code calculated by squaring the product of a and length of the name plus b
            // then adding the value of the last character of the name
            return (int)Math.Pow((name.Length + b) * a, 2) + name[name.Length-1];
        }

        // prints a user's name in upper case, the integers they inputted, and the secret code that results from this info
        public static void PrintAllInfo(string name, int a, int b)
        {
            Console.WriteLine("Your name is " + name.ToUpper() + ",");
            Console.WriteLine("your favorite numbers are " + a + " and " + b + ",");
            Console.WriteLine("and your secret code is " + GetSecretCode(name, a, b));
        }

        static void Main(string[] args)
        {
            // Setup variables
            string name = "";
            int a = 0;
            int b = 0;
            int choice = 0;

            // Get values for name, a, and b using GetPromptedInput and parsing if needed.
            // Fyi, lines that begin with // TODO: will appear in a VS task list for you!
            // https://docs.microsoft.com/en-us/visualstudio/ide/using-the-task-list
            name = GetPromptedInput("What is your name:").Trim();
            a = int.Parse(GetPromptedInput("Enter a whole number:"));
            b = int.Parse(GetPromptedInput("Enter another whole number:"));

            // Reformat the name
            name = name[0].ToString().ToUpper() + name.Substring(1, name.Length - 1).ToLower();

            // Print the menu
            Console.WriteLine("\nHello {0}, what would you like to do?\n" +
                "\t1 - Compare numbers\n" +
                "\t2 - Get my secret code\n" +
                "\t3 - Output all info",
                name);
            choice = int.Parse(GetPromptedInput(">"));
            Console.WriteLine();

            // Figure out what to do and do it
            switch (choice)
            {
                // Check numbers
                case 1:
                    // checks if each number is a factor of each other and prints a message
                    CheckNumbers(a, b);
                    break;

                // Get secret code
                case 2:
                    // calls GetSecretCode to create a code based on the user's name and integer input and prints the code
                    Console.WriteLine("Your secret code is " + GetSecretCode(name, a, b));
                    break;

                // Output all info
                // prints the user's name, the inputted numbers, and the results of choice 1 (check numbers) and 2 (get secret code)
                case 3:
                    // calls PrintAllInfo to print the user's name, the inputted numbers, and the results of GetSecretCode()
                    PrintAllInfo(name, a, b);
                    // checks if each number is a factor of the other and prints a message
                    CheckNumbers(a, b);
                    break;

                // Say goodbye for invalid choices
                default:
                    Console.WriteLine("That wasn't a valid choice. Goodbye.");
                    break;
            }

        }
    }
}
