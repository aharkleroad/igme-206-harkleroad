using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Polymorphism_Demo.Pets
{
    // new subclass of Pet
    internal class Rat : Pet
    {
        // parameterized Rat constructor
        // calls the base constructor to set the rat's name, birthday, and type
        public Rat(string name, DateTime birthday)
            : base(name, birthday, "rat")
        {
        }

        // overrides Pet's Speak() method so that the rat can squeak
        public override void Speak()
        {
            Console.WriteLine(this.Name + " says SQUEAK.");
        }
    }
}
