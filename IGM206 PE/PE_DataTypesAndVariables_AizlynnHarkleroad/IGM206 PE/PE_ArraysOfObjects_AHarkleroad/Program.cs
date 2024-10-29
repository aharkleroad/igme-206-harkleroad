/*
 * Aizlynn Harkleroad
 * 
 * PE - Arrays of Objects
 * No known issues or bugs
 */

namespace PE_ArraysOfObjects_AHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // creates a new Deck object
            Deck deck = new Deck();

            // prints the new deck
            // should include one of each traditional card
            Console.WriteLine("Your deck:");
            deck.Print();
            Console.WriteLine();

            // randomly deals the number of cards the user requests from this deck
            Console.Write("Enter a number of cards to deal (1-52): ");
            deck.Deal(int.Parse(Console.ReadLine()));
        }
    }   
}
