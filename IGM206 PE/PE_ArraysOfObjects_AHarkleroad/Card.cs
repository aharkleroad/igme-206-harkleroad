using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_ArraysOfObjects_AHarkleroad
{
    internal class Card
    {
        // field declaration
        private int value;
        private string suite;

        // Card constructor
        // creates a card with a given suite and value
        public Card(int value, string suite)
        {
            this.value = value;
            this.suite = suite;
        }

        // prints a card's suite and value
        // if the value is 1 or 11-13, print the corresponding card title rather than the value
        public void Print()
        {
            // value 1 = ace
            if (value == 1)
            {
                Console.WriteLine("Ace of " + suite);
            }
            // value 2-10 = number card
            else if (value > 1 && value <= 10)
            {
                Console.WriteLine(value + " of " + suite);
            }
            // value 11 = Jack
            else if (value == 11)
            {
                Console.WriteLine("Jack of " + suite);
            }
            // value 12 = Queen
            else if (value == 12)
            {
                Console.WriteLine("Queen of " + suite);
            }
            // value 13 = King
            else if (value == 13)
            {
                Console.WriteLine("King of " + suite);
            }
        }
    }
}
