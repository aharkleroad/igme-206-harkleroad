﻿//****************************************************************
// DO NOT modify anything in this file *EXCEPT* where marked
// explicitly with TODO comments!
//****************************************************************
using static System.Net.Mime.MediaTypeNames;

namespace GDP_Exam_1
{
    /// <summary>
    /// Inherits from item and adds data & behavior specific for foods
    /// </summary>
    // TODO: Make this inherit from item
    class Food : Item
    {
        // NO additional fields are permitted.
        private int numServings;
        private double lbsPerServing;

        /// <summary>
        /// TODO: Override the Item class's required abstract Weight
        /// property. The returned weight of a food is:
        ///     number of servings * weight per serving
        /// </summary>
        // overloads the Item abstract property Weight to get the food's weight
        public override double Weight 
        {
            get { return numServings * lbsPerServing; } 
        }

        /// <summary>
        /// TODO: Add a parameterized constructor using the constructor
        /// calls in Main & the writeup as a guide for what this constructor
        /// must do. Leverage the base class constructor as needed.
        /// </summary>
        /// 

        // parameterized Food constructor that leverages the Item constructor to set a food's name
        public Food(string name, int numServings, double lbsPerServing) : base(name)
        {
            this.numServings = numServings;
            this.lbsPerServing = lbsPerServing;
        }

        /// <summary>
        /// Eats a serving of food
        /// </summary>
        public void Eat()
        {
            if(numServings > 0)
            {
                // TODO: Uncomment once Food inherits from item correctly
                Console.WriteLine("Mmmm I ate a serving of " + this.Name);
                numServings--;
            }
            else
            {
                // TODO: Uncomment once Food inherits from item correctly
                Console.WriteLine(":( There's no " + Name + " left to eat.");
            }
        }

        /// <summary>
        /// TODO: Override ToString to leverage the base class ToString 
        /// and add on the amount of damage this weapon does.
        /// </summary>
        /// 
        // leverages Item's ToString() method and overloads it to print a food's info
        public override string ToString()
        {
            return base.ToString() + String.Format(" and has {0} servings", numServings);
        }

    }
}
