/*
 * Aizlynn Harkleroad
 * No known bugs or errors
 */

namespace HW_CharacterStory_AizlynnHarkleroad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // declares and initializes characters' stats
            string characterName = "Perseus";
            int maxHealth = 100;
            int currentHealth = 100;
            double strength = 11.5;
            int strikes = 3;
            int remainingSnakes = 42;

            // prints character introduction and stats
            Console.WriteLine("---Introduction---");
            Console.WriteLine("This is " + characterName + ", the greek hero of legend!");
            Console.WriteLine();
            Console.WriteLine("---Starting Character Stats---");
            Console.WriteLine("Max Health: " + maxHealth);
            Console.WriteLine("Current Health: " + currentHealth);
            Console.WriteLine("Strength: " + strength);
            Console.WriteLine("Strikes Left: " + strikes);
            Console.WriteLine("Snakes Remaining: " + remainingSnakes);

            // character actions and calculations, attack 1
            // calculates how many snakes each attack removes and adjusts the snake count
            Console.WriteLine();
            Console.WriteLine("---The Story---");
            Console.WriteLine(characterName + " sees Medusa in the reflection of his shield and strikes at her," +
                " removing " + strength * 2 + " snakes from her head");
            remainingSnakes -= (int)(strength * 2);
            // strength reduced in relation to which strike was completed
            strength = strength % strikes;
            // number of possible strikes decreased
            strikes -= 1;
            Console.WriteLine(characterName + " can now only perform " + strikes + " more strikes!");
            Console.WriteLine("The difficult attack tires " + characterName + " tremendously and brings his" +
                " strength down to " + strength);
            Console.WriteLine("Then Medusa attacks, dealing " + remainingSnakes * 3 + " damage");
            // health adjusted based on number of snakes left to attack
            currentHealth = maxHealth - (remainingSnakes * 3);
            Console.WriteLine(characterName + "'s health is reduced to " + currentHealth);

            // prints conclusion and final stats
            Console.WriteLine();
            Console.WriteLine("---Conclusion---");
            Console.WriteLine("Using the last of his strength " + characterName + " lashes out with his sword " +
                "for the final time, decapitating the beast.");
            // adjusts strike count based on strike performed in the conclusion
            strikes -= 1;
            Console.WriteLine("Although the battle was close, he emerges victorious.");
            Console.WriteLine();
            Console.WriteLine("---Final Character Stats---");
            Console.WriteLine("Max Health: " + maxHealth);
            Console.WriteLine("Current Health: " + currentHealth);
            Console.WriteLine("Strength: " + strength);
            Console.WriteLine("Strikes Left: " + strikes);
            Console.WriteLine("Snakes Remaining: " + remainingSnakes);
        }
    }
}
