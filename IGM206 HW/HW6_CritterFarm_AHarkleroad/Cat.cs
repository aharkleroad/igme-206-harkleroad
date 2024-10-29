using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_CritterFarm
{
    internal class Cat : Critter
    {
        // parameterized Constructor that instantiates a Cat using its name, type, and the
        // default values in the base Critter constructor
        public Cat(string name) : base (name, CritterType.Cat, 3, 0) { }

        // parameterized Constructor that instantiates a Cat using a given name, hunger level, boredom
        // level, and its CritterType
        public Cat(string name, int hunger, int boredom) :
            base(name, CritterType.Cat, hunger, boredom) { }

        // overridden method that determines a Rat's mood based on their hunger and boredom level
        protected override void UpdateMood()
        {
            int mood = this.Hunger + (2 * this.Boredom);
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
    }
}
