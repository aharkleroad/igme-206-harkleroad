using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Polymorphism_Demo.Shapes
{
    internal class Triangle : Shape
    {
        // Must have height and base length to define a triangle
        private double baseLength;
        private double height;

        // Create a new triangle using the base constructor to save the type
        // then initializes triangle specific fields, baseLength and height
        public Triangle(double baseSide, double height) : base("triangle")
        {
            this.baseLength = baseSide;
            this.height = height;
        }

        // Implement CalculateArea correctly for a triangle
        // area = 1/2 base * height
        public override double CalculateArea()
        {
            return 0.5 * baseLength * height;
        }

        // Implement the Area property as well
        public override double Area
        {
            get
            {
                return 0.5 * baseLength * height;
            }
        }
    }
}
