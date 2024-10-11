using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_FileIO_AHarkleroad
{
    internal class Player
    {
        // field declaration
        private string name;
        private int health;
        private int strength;

        // Player constructor
        public Player(string name, int strength, int health)
        {
            this.name = name;
            this.strength = strength;
            this.health = health;
        }

        // Player properties
        public string Name
        {
            get { return name; }
        }

        public int Health
        {
            get { return health; }
        }

        public int Strength
        {
            get { return strength; }
        }

        // returns a string of all of a player's stats, including name, strength, and health
        public override string ToString()
        {
            return String.Format("Player: {0}. Strength {1}, Health {2}.", Name, Strength, Health);
        }
    }
}
