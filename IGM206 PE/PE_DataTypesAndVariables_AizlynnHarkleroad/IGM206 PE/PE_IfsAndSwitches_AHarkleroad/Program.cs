/*
 * Aizlynn Harkleroad
 * PE - Ifs & Switches
 * No known bugs or issues
 */

namespace PE_IfsAndSwitches_AHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // initializes variables
            int userMathAnswer;
            int firstNumber;
            int secondNumber;
            int thirdNumber;
            char multipleChoice;

            // asks the user to input the answer to a math question (6 * 7)
            Console.Write("What is 6 * 7? ");
            userMathAnswer = int.Parse(Console.ReadLine());

            // the input is 42 (correct)
            if (userMathAnswer == 42)
            {
                Console.WriteLine("Correct!");
            }
            // the input is anything else
            else
            {
                Console.WriteLine("No, sorry, it's 42.");
            }
            Console.WriteLine();

            // prompts the user to enter 3 numbers in ascending order
            // parses each to an int
            Console.WriteLine("Enter three numbers in -ascending- order:");
            Console.Write("1: ");
            firstNumber = int.Parse(Console.ReadLine());
            Console.Write("2: ");
            secondNumber = int.Parse(Console.ReadLine());
            Console.Write("3: ");
            thirdNumber = int.Parse(Console.ReadLine());

            // the first number is smaller than the second, which is smaller than the third
            // numbers in ascending order
            if ((firstNumber < secondNumber) && (secondNumber < thirdNumber))
            {
                Console.WriteLine("That's correct!");
            }
            // the first number is larger than the second, which is larger than the third
            // numbers in descending order
            else if ((firstNumber > secondNumber) && (secondNumber > thirdNumber))
            {
                Console.WriteLine("That's backwards!");
            }
            // numbers in a random order
            else
            {
                Console.WriteLine("That's wrong!");
            }
            Console.WriteLine();

            // prompts the user to answer a multiple choice question and parses the answer to a char
            Console.WriteLine("Why are calico (tri-colored) cats almost all female?");
            Console.WriteLine("\ta. Only female cats can be orange");
            Console.WriteLine("\tb. Male calico kittens are rejected by their mothers");
            Console.WriteLine("\tc. The gene for fur color is on the X chromosome");
            Console.WriteLine("\td. Trick question, they aren't");
            multipleChoice = char.Parse(Console.ReadLine().ToLower().Trim());
            // switch based on their input determines the response
            switch (multipleChoice)
            {
                // the wrong answer was selected
                case 'a':
                case 'b':
                case 'd':
                    Console.WriteLine("Wrong. The gene that controls fur color is on the X chromosome, " +
                        "\nso male cats are normally only able to have two fur colors at once.");
                    break;
                // the user answered correctly
                case 'c':
                    Console.WriteLine("You're right!");
                    break;
                // the user inputted something that wasn't an option
                default:
                    Console.WriteLine("That's wasn't even an answer!");
                    break;
            }
        }
    }
}
