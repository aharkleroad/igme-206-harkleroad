using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Polymorphism_Demo.Pets
{
    // new subclass of Pet
    internal class Bird : Pet
    {
        // parameterized Bird constructor
        // calls the base constructor to set the rat's name, birthday, and type
        public Bird(string name, DateTime birthday)
            : base(name, birthday, "bird")
        {
        }

        // overrides Pet's Speak() method so that the bird can tweet
        public override void Speak()
        {
            Console.WriteLine(this.Name + " says TWEET.");
        }

        // Birds also fly
        // If Pet has a virtual Fly, this one will need to override
        // in order for polymorphism to work
        //public override void Fly(int loops)
        public void Fly(int loops)
        {
            for (int i = 0; i < loops; i++)
            {
                Console.Write("FLAP! ");
            }
            Console.WriteLine();
        }
    }
}
