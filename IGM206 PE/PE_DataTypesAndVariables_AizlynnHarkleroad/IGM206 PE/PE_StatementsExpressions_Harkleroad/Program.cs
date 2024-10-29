/*
 * Aizlynn Harkeroad
 * PE - Statements and Expressions
 */

namespace PE_StatementsExpressions_Harkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prints the character's name
            Console.WriteLine("Character: Jackson");

            //  Allocates 20% of the character's total points (50 points total) to 1st stat (Strength)
            Console.WriteLine("Strength: " + (50 * 0.2));

            //  Allocates half of the points from the 1st stat to 2nd stat (Dexterity)
            Console.WriteLine("Dexterity: " + ((50 * 0.2) / 2));

            //  Allocates seven points to the 3rd stat (Wisdom)
            Console.WriteLine("Wisdom: " + 7);

            //  Allocates a number of points to the 4th stat (Constitution) that is the sum of the 2nd and 3rd stats points minus 2
            Console.WriteLine("Constitution: " + ((((50 * 0.2) / 2) + 7) - 2));

            //  Gives all remaining points to the 5th stat (Charisma)
            Console.WriteLine("Charisma: " + (50 - ((50 * 0.2) + // subtract Strength
                ((50 * 0.2) / 2) +                             // subtract Dexterity
                7 +                                            // subtract Wisdom
                ((((50 * 0.2) / 2) + 7) - 2)))                 // subtract Constitution
            );

            // Prints the character's total points
            Console.WriteLine("Point Total: 50");
        }
    }
}
