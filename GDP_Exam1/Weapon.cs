//****************************************************************
// DO NOT modify anything in this file *EXCEPT* where marked
// explicitly with TODO comments!
//****************************************************************
namespace GDP_Exam_1
{
    /// <summary>
    /// Inherits from item and adds data & behavior specific for weapons
    /// </summary>
    // TODO: Make this inherit from item
    class Weapon : Item
    {
        // NO additional fields or properties are permitted.
        private double weight;
        private int damage;

        /// <summary>
        /// Return how much damage this weapon can do
        /// </summary>
        public int Damage { get { return damage; } }

        /// <summary>
        /// TODO: Add the Item class's required abstract Weight
        /// property.
        /// </summary>
        // inherited and overriden method from Item superclass
        public override double Weight 
        { 
            get { return weight; } 
        }

        /// <summary>
        /// TODO: Add a parameterized constructor using the constructor
        /// calls in Main & the writeup as a guide for what this constructor
        /// must do. Leverage the base class constructor as needed.
        /// </summary>
        /// 
        // weapon constructor that uses Item constructor to set the weapon's name
        public Weapon(string name, int damage, double weight) : base(name)
        {
            this.damage = damage;
            this.weight = weight;
        }

        /// <summary>
        /// TODO: Override ToString to leverage the base class ToString 
        /// and add on the amount of damage this weapon does.
        /// </summary>
        /// 
        // leverages Item's ToString() method and overloads it to print a weapon's info
        public override string ToString()
        {
            return base.ToString() + String.Format(", {0} damage", damage);
        }
    }
}
