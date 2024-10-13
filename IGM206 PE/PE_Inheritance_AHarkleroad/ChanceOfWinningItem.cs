using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMenus
{
    internal class ChanceOfWinningItem : MenuItem
    {
        // ~~~ FIELDS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private int attempts;
        private int options;

        // ~~~ PROPERTIES ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // None specific to this child class

        // ~~~ CONSTRUCTORS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // keyword, description, and action text initialized by parent constructor
        // subclass specific attempts and options initialized in local constructor
        public ChanceOfWinningItem(int attempts, int options)
            : base("CHANCE", "Get the probability of winning a random guessing game", 
                  "The chance of winning a guessing game with " + options + " options and " + attempts + " guess(es) is: ")
        {
            this.attempts = attempts;
            this.options = options;
        }

        // ~~~ OVERRIDES from Object ~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // None specific to this child class

        // ~~~ METHODS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // The child class can do as much as it likes when overriding!
        // returns the probability of winning a guessing game with a given number of options and guesses
        public override void Run()
        {
            // Setup
            Console.WriteLine(actionText + "{0:P2}", ((double)attempts/options));
        }
    }
}
