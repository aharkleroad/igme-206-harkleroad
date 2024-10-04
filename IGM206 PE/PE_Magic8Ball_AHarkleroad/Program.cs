/*
 * Aizlynn Harkleroad
 * 
 * PE - Magic 8 Ball
 * No known bugs or issues
 */

namespace PE_Magic8Ball_AHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // variable declaration
            string eightBallOwner;
            string action;

            // prompts the user to enter the name of the owner of the magic 8 ball
            // then constructs a magic 8 ball object using that name
            Console.Write("Who owns this Magic 8 Ball? ");
            eightBallOwner = Console.ReadLine();
            MagicEightBall magicEightBall = new MagicEightBall(eightBallOwner);
            Console.WriteLine();

            // lets the user ask a question to the 8 ball or print how many questions have been asked
            // by taking input from them
            // repeats until the user asks to quit
            do
            {
                Console.WriteLine("What would you like to do? ");
                Console.Write("You can ‘shake’ the ball, get a ‘report’, or ‘quit’: ");
                action = Console.ReadLine().Trim().ToLower();
                
                // switch depends on user input
                switch (action)
                {
                    // asks the 8 ball a question and gets/prints the response using ShakeBall()
                    case "shake":
                        Console.Write("What is your question? ");
                        Console.ReadLine();
                        Console.WriteLine("The Magic 8 Ball says: " + magicEightBall.ShakeBall());
                        Console.WriteLine();
                        break;
                    // prints how many times the given 8 ball has been asked a question using Report()
                    case "report":
                        Console.WriteLine(magicEightBall.Report());
                        Console.WriteLine();
                        break;
                    // prints a goodbye and causes the program and loop to end
                    case "quit":
                        Console.WriteLine("Goodbye!");
                        Console.WriteLine();
                        break;
                    // the user entered an unexpected value
                    // prints that the input isn't recognized
                    default:
                        Console.WriteLine("I do not recognize that response.");
                        Console.WriteLine();
                        break;
                }
            }
            // ends the loop after the user inputs quit
            while (action != "quit");
        }
    }
}
