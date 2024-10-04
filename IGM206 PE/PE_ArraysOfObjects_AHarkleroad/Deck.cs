using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_ArraysOfObjects_AHarkleroad
{
    internal class Deck
    {
        // field declaration
        private Random rng;
        private Card[] cards;

        // Deck constructor
        // initializes field values and populates the deck's card array with
        // the traditional cards in a 52 card set
        public Deck()
        {
            rng = new Random();
            cards = new Card[52];
            string cardSuite;
            int cardNumber = 0;

            // nested loop creates 52 unique cards
            // iterates through this loop 4 times, creating all cards of 1 of the 4 suites
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    cardSuite = "hearts";
                }
                else if (i == 1)
                {
                    cardSuite = "diamonds";
                }
                else if (i == 2)
                {
                    cardSuite = "spades";
                }
                else
                {
                    cardSuite = "clubs";
                }
                // assigns each card of a given suite a value of 1-13
                for (int j = 1; j <= 13; j++)
                {
                    cards[cardNumber] = new Card(j, cardSuite);
                    cardNumber++;
                }
            }
        }

        // prints each card in the deck
        public void Print()
        {
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].Print();
            }
        }
       
        // deals a number of cards equal to the given amount
        // determines which card is dealt using a random number generator to generate an index in 
        // the deck's cards array
        public void Deal(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                cards[rng.Next(0,52)].Print();
            }
        }
    }
}
