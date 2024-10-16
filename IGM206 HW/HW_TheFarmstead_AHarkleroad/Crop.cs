using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_TheFarmstead_AHarkleroad
{
    internal class Crop
    {
        // Crop field declaration
        private string name;
        private int growthTime;
        private double cost;
        private int daysLeft;

        /// <summary>
        /// Initializes a new instance of the Crop class as a copy of another crop.
        /// </summary>
        /// <param name="other">The crop to copy.</param>
        // TODO: Leverage constructor chaining here to use the parameterized constructor!
        public Crop(Crop other) : this(other.name, other.growthTime, other.cost)
        {
            // No code here!
        }

        // parameterized Crop constructor
        public Crop(string name, int growthTime, double cost)
        {
            this.name = name;
            this.growthTime = growthTime;
            this.cost = cost;
            this.daysLeft = growthTime;
        }

        // Crop properties
        // returns the Crop's name
        public string Name
        {
            get { return name; }
        }

        // returns the Crop's cost
        public double Cost
        {
            get { return cost; }
        }

        // returns the Crop's selling price
        public double SellingPrice
        {
            get { return cost * growthTime; }
        }

        // returns if a Crop can be harvested
        public bool CanHarvest
        {
            get { if (daysLeft > 0) return false; return true; }
        }

        // Crop methods
        // decrements the number of days a Crop must grow until it can be harvested
        public void DayPassed()
        {
            daysLeft--;
        }

        // prints information about a Crop
        // if it can be harvested, print its selling price
        // otherwise, print the days left until it can be harvested
        public override string ToString()
        {
            if (daysLeft <= 0)
            {
                return String.Format("{0} ready to harvest for {1:C2}", name, this.SellingPrice);
            }
            else
            {
                return String.Format("{0} has {1} days left to harvest", name, daysLeft);
            }
        }
    }
}
