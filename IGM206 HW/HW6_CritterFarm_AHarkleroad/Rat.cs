using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_CritterFarm
{
    internal class Rat : Critter
    {
        // parameterized Constructor that instantiates a Cat using its name, type, and the
        // default values in the base Critter constructor
        public Rat(string name) : base(name, CritterType.Rat, 4, 2) { }

        // parameterized Constructor that instantiates a Cat using a given name, hunger level, boredom
        // level, and its CritterType
        public Rat(string name, int hunger, int boredom) :
            base(name, CritterType.Rat, hunger, boredom) { }

        // overriden method that determines a Rat's mood based on their hunger and boredom levels
        protected override void UpdateMood()
        {
            int mood = (this.Hunger * 2) + this.Boredom;
            if (mood < GenFrustrationLvl)
            {
                this.mood = CritterMood.Happy;
            }
            else if (mood < GenAngryLvl)
            {
                this.mood = CritterMood.Frustrated;
            }
            else
            {
                this.mood = CritterMood.Angry;
            }
        }

        // Rat specific method that reduces their boredom and hunger
        public void Chew()
        {
            this.Boredom -= 2;
            this.Hunger -= 1;
            Console.WriteLine("{0} also gets joy out of chewing up their bedding!", this.name);
        }
    }
}
