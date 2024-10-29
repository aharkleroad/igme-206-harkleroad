/*
 * Code by Aizlynn Harkleroad
 * PE - Data Types and Variables
 * 
 * No known issues
 */
namespace PE_DataTypesAndVariables_AizlynnHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declare and initialize character name
            string name = "Jason";
            // declare, calculate, and initialize character's stats
            const int StartingSkillPoints = 50;
            // strength takes up 23% of character's skill points
            double strength = StartingSkillPoints * 0.23;
            // dexterity has half of strength's skill points
            double dexterity = strength / 2;
            // intelligence has 7 skill points
            int intelligence = 7;
            // health has a combination of dexterity and intelligence's skill points, minus 2
            double health = dexterity + intelligence - 2;
            // charisma has the remaining skill points
            double charisma = StartingSkillPoints - strength - dexterity - intelligence - health;
            // adds each character stat together to ensure 50 skill points have been distributed
            double totalSkillPoints = strength + dexterity + intelligence + health + charisma;
            
            // Print out character's name
            Console.WriteLine("Character name: " + name);
            // Provides whitespace for greater readability
            Console.WriteLine();
            // Print the characer's stats
            Console.WriteLine("Strength: " + strength);
            Console.WriteLine("Dexterity: " + dexterity);
            Console.WriteLine("Intelligence: " + intelligence);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Charisma: " + charisma);
            // Provides whitespace for greater readability
            Console.WriteLine();
            // Prints total points to verify that points have been distributed correctly
            Console.WriteLine("Total skill points: " + totalSkillPoints);
        }
    }
}
