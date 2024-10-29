using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Polymorphism_Demo.Shapes
{
    internal class Rectangle : Shape
    {
        // Must have height and length to define a rectangle
        private double length;
        private double height;

        // Create a new rectangle using the base constructor to save the type
        // then initializes rectangle specific fields, length and height
        public Rectangle(double length, double height) : base("rectangle")
        {
            this.length = length;
            this.height = height;
        }

        // Implement CalculateArea correctly for a rectangle
        // area = length * height
        public override double CalculateArea()
        {
            return length * height;
        }

        // Implement the Area property as well
        public override double Area
        {
            get
            {
                return length * height;
            }
        }
    }
}
