﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_CritterFarm
{
    internal class Dog : Critter
    {
        // parameterized Constructor that instantiates a Cat using its name, type, and the
        // default values in the base Critter constructor
        public Dog(string name) : base(name, CritterType.Dog, 1, 2) { }

        // parameterized Constructor that instantiates a Cat using a given name, hunger level, boredom
        // level, and its CritterType
        public Dog(string name, int hunger, int boredom) :
            base(name, CritterType.Dog, hunger, boredom) { }

        // overriden method that determines a Rat's mood based on their hunger and boredom levels
        protected override void UpdateMood()
        {
            int mood = this.Hunger + this.Boredom;
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
