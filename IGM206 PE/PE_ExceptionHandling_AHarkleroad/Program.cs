/*
 * Aizlynn Harkleroad
 * 
 * PE - Exception Handling and TryParse
 * No known bugs or issues
 */

namespace PE_ExceptionHandling_AHarkleroad
{
    internal class Program
    {
        /// <summary>
        /// Helper method to prompt the user to enter a number. If their
        /// response isn't a valid int or isn't in the desired range, reprompt
        /// </summary>
        /// <param name="prompt">The string to use in the initial prompt</param>
        /// <param name="min">The minimum accepted value (inclusive)</param>
        /// <param name="max">The maximum accepted value (inclusive)</param>
        /// <returns>The final, valid, user-entered value.</returns>
        public static int GetValidIntegerInput(string prompt, int min, int max)
        {
            // TODO: Activity 2: Refactor this to use TryParse!
            // declare variables
            int result;
            bool success = int.TryParse(GetPromptedInput(prompt), out result);
            // if the user input is not in the given range or can not be parsed, print a message telling them to enter different input
            while (result < min || result > max || !success)
            {
                success = int.TryParse(
                    GetPromptedInput(
                            String.Format("Please enter a valid whole number between {0} and {1}:",
                            min,
                            max)
                        ), out result
                    );
            }
            // once the input is valid, return it
            return result;
        }

        /// <summary>
        /// Given a reference to an array of possible choices, keep prompting
        /// the user until they enter a valid option
        /// NOTE: Validation is case insensitive!
        /// </summary>
        /// <param name="prompt">The prompt to use</param>
        /// <param name="choices">The valid options</param>
        /// <returns>The final valid choice</returns>
        public static string GetPromptedChoice(string prompt, string[] choices)
        {
            string result = GetPromptedInput(prompt);

            // We haven't taught using Predicates in parameters. There are ways to implement
            // this with what you've learned so far, but I didn't feel like making you worry about
            // anything not related to exceptions or TryParse for this PE.
            // https://learn.microsoft.com/en-us/dotnet/api/system.array.exists?view=net-7.0
            while (!Array.Exists(choices, element => element.ToUpper() == result.ToUpper()))
            {
                result = GetPromptedInput(prompt);
            }
            return result;
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

        static void Main(string[] args)
        {
            // variable declaration
            string choice;
            int a = 0;
            int b = 0;
            string[] validChoices = { "T", "Q" };

            do
            {
                // TODO: Activity 1: Add exception handling to detect potential run-time errors

                // Get two numbers in different ranges:
                try
                {
                    // calls GetValidIntegerInput to get one number between 0 & 10 and one between 20 & 30
                    a = GetValidIntegerInput("\nA [0,10] : ", 0, 10);
                    b = GetValidIntegerInput("\nB [20,30]:", 20, 30);

                    // by uncommenting the two lines below, you can test the divide by zero and format exception exception catching
                    // otherwise, GetValidIntegerInput handles the errors with the current ranges
                    // a = int.Parse(GetPromptedInput("\nA [0,10] : "));
                    // b = int.Parse(GetPromptedInput("\nB [20,30] : "));

                    // performs different arithmentic operations with the given numbers and displays the results
                    Console.WriteLine($"\n{a} + {b} = {a + b}");
                    Console.WriteLine($"{a} - {b} = {a - b}");
                    Console.WriteLine($"{a} * {b} = {a * b}");
                    Console.WriteLine($"{a} / {b} = {a / b}");

                    // checked() forces the runtime to detect
                    // issues instead of dealing with it by resulting in max int
                    Console.WriteLine($"{a} * {int.MaxValue} = {checked(a * int.MaxValue)}");
                }

                // stops a crash when a value is too large for the variable type it is assigned to and prints an error message
                catch (OverflowException exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(a + " * " + int.MaxValue + " = A bad idea :)");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                // stops a crash when a value is divided by zero and prints an error message
                catch (DivideByZeroException exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(a + " can not be divided by zero!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                // stops a crash when a value is assigned to an improper type
                catch (FormatException exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input was not in correct format, must be a whole number.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                choice = GetPromptedChoice("\n[T]est again or [Q]uit?", validChoices);
            }
            // repeats as long as the user wishes (as long as they don't enter Q)
            while (choice.ToUpper() != "Q");
        }
    }
}
