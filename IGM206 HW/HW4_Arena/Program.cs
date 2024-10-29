/***
 * Aizlynn Harkleroad
 * 
 * HW 4 - The Arena
 * Write-up: https://docs.google.com/document/d/15Rl0oXwNXdGze8p5HcrZ8n4y78oiubW5pbkJei2YTPI/edit?usp=sharing
 *
 * Primary upgrades:
 *  1. 2 (Enemy Customization)
 *  2. 6 (Power Ups)
 *  
 * Optional extra upgrades:
 *  3.
 *  4.
 *  
 * Known Bugs: None
 * 
 * Other notes: None
 * 
 */
using System;
using System.Xml.Linq;

namespace HW4_Arena
{
    /// <summary>
    /// Primary class for the console app. Main() will be run on program launch. Other helper methods are
    /// also defined that Main() will need. It's your job to finish them!
    /// 
    /// Do NOT change anything except where explicitly marked with a TODO comment!
    /// See the comments through this program AND read the assignment write-up for details.
    /// </summary>
    internal class Program
    {
        // *** These constants are defined for you to make your code more readable AND help ensure it works
        //     with the code given to you. Do NOT change these!

        // Constants for the tile types
        private const char Empty = ' ';
        private const char Wall = '#';
        private const char Enemy = 'E';
        private const char Player = '@';
        private const char PlayerStart = '0';
        private const char Exit = '1';
        // Created for primary upgrade 6 (power-ups)
        private const char Potion = '!';

        // Constants for directions
        private const char Up = 'w';
        private const char Down = 's';
        private const char Left = 'a';
        private const char Right = 'd';

        // Player stat indices
        private const int Strength = 0;
        private const int Dexterity = 1;
        private const int Constitution = 2;
        private const int Health = 3;

        // Possible fight outcomes
        private const int Win = 0;
        private const int Lose = 1;
        private const int Run = 2;
        private const int Draw = 3;

        // *** Other constants
        // TODO: It's okay to tweak these numbers a bit to balance your game and/or add new ones.
        // (But don't delete what is here. Main needs some of them!)
        const int EnemySpacing = 6;
        const int MaxPoints = 10;
        const int HealthMult = 5;
        const int DamageMult = 5;
        const int EnemyAttack = 5;
        const int EnemyMaxHealth = 50;

        /// <summary>
        /// DO NOT CHANGE ANY CODE IN MAIN!!!
        /// 
        /// But it's definitely worth reading it to get an understanding of 
        /// how/when your methods will be called.
        /// 
        /// AND it's okay to *temporarily* comment out chunks of code until 
        /// you're ready for them to run to make it easier to test other things.
        /// </summary>
        static void Main(string[] args)
        {
            // ** SETUP **
            // Player's name
            string name;

            // Stats - to make it easier to pass these around between methods, all 4 stats are
            // in a single array with elements in the order [Strength, Dexterity, Constitution, Health]
            // Constants are defined above to help with this.
            int[] stats = new int[4];

            // Define the variable to refer to the final arena
            char[,] arena;

            // Track the player's location as [row, col] (NOT x, y)
            int[] playerLoc = {1, 1};

            // Is the game still running?
            bool stillPlaying = true;

            // How many enemies are left?
            int numEnemies;

            // ** GET PLAYER STATS & BUILD ARENA **
            // Welcome & get stats 
            name = GetPlayerInfo(stats);

            // Build & print the Arena
            arena = BuildArena(out numEnemies);

            // Enemy Customization
            // create an array to hold different enemy health multipliers
            // will be accessed in Fight() when a battle starts

            // ** GAME LOOP **
            while (stillPlaying)
            {
                // ** PRINT EVERYTHING **

                // Clear the console and then print the arena
                Console.Clear();
                PrintArena(arena, playerLoc);
                Console.WriteLine(
                    $"\n{name}, your stats are: " +
                    $"Strength {stats[Strength]}, " +
                    $"Dexterity {stats[Dexterity]}, " +
                    $"Constitution {stats[Constitution]}, " +
                    $"Health {stats[Health]}");

                // ** DETECT MOVEMENT **

                // Get the desired direction
                char direction = SmartConsole.GetPromptedChoice(
                        $"\n Where would you like to go? {Up}/{Left}/{Down}/{Right} >",
                        new char[] { Up, Left, Down, Right });
                Console.WriteLine();

                // Figure out what is there, but don't move yet
                int[] nextLoc = { playerLoc[0], playerLoc[1] };
                switch (direction)
                {
                    case Up:
                        nextLoc[0]--; // row--
                        break;

                    case Down:
                        nextLoc[0]++; // row++
                        break;

                    case Left:
                        nextLoc[1]--; // col --
                        break;

                    case Right:
                        nextLoc[1]++; // col ++
                        break;
                }

                // ** TAKE ACTION **
                // Act based on what is in the next location (row, col)
                switch(arena[nextLoc[0], nextLoc[1]])
                {
                    // 6. Power Ups
                    // add a case "potion" that adds to a health
                    case Potion:
                        Console.WriteLine("\nYou picked up a health potion!");
                        // increases player health by a maximum of 3
                        // does not go over the max health determined by a player's constitution
                        if (stats[Health] + 3 < stats[Constitution] * HealthMult)
                        {
                            stats[Health] += 3;
                            Console.WriteLine("Your health increases by three, it is now {0}.", stats[Health]);
                        }
                        else
                        {
                            stats[Health] = stats[Constitution] * HealthMult;
                            Console.WriteLine("Your health increased to your max health of {0}.", stats[Health]);
                        }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        // gets rid of the potion, so they can't use it again
                        arena[nextLoc[0], nextLoc[1]] = Empty;
                        break;

                    // Do nothing. We're stuck.
                    case Wall:
                        Console.WriteLine("\n You can't go there...");
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;

                    // Move to that spot
                    case Empty:
                        playerLoc = nextLoc;
                        break;

                    // Launch a new fight and determine how to proceed based on the result
                    case Enemy:
                        switch(Fight(stats))
                        {
                            // Take over the enemy's spot if we win
                            case Win:
                                playerLoc = nextLoc;
                                arena[playerLoc[0], playerLoc[1]] = Empty;
                                numEnemies--;
                                break;

                            // A loss or draw is game over
                            case Lose:
                            case Draw:
                                stillPlaying = false;
                                break;

                            // Run back to the start and regain half health
                            case Run:
                                Console.WriteLine("You retreat to the starting area of the arena to heal up.");
                                playerLoc = new int[] { 1, 1 };
                                stats[Health] += (stats[Constitution] * HealthMult)/2;
                                stats[Health] = Math.Clamp(stats[Health], 0, stats[Constitution] * HealthMult); // cap at max health
                                break;
                        }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;

                    case Exit:
                        if(numEnemies > 0)
                        {
                            Console.WriteLine("You must defeat all enemies before you can escape.");
                        }
                        else
                        {
                            Console.WriteLine("You made it to the exit! Congratulations!");
                            stillPlaying = false;
                        }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }

        }

        /// <summary>
        /// Given a reference to the player's current stats, launch a new fight
        /// </summary>
        /// <param name="stats">A reference to an int[] containing [Strength, Dexterity, Constitution, Health]</param>
        /// <returns>The result of the fight using an int code. See the constants at the top of Program.cs</returns>
        
        // this method models a fight between the player and different enemies
        // use a while loop to start the battle and a series of if/else statements to handle player actions
        // if/else will also handle winning and losing
        // loop continues until the fight has ended and returns the result to main
        private static int Fight(int[] stats)
        {
            // TODO: Implement the Fight method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // local variable declaration
            string action;
            int outcome = -10;
            // needed to generate primary upgrade 2 (enemy customization)
            double[] enemyHealthMultipliers = new double[] { 0.5, 1, 2, 3 };
            Random enemyHealthModifier = new Random();
            int currentEnemyHealth = (int)(EnemyMaxHealth * enemyHealthMultipliers[enemyHealthModifier.Next(0,4)]);
            int playerDamage;
            int enemyDamage;
            Console.WriteLine("A goblin attacks you!");
            Console.WriteLine();

            // while the fight has not been completed (no one has won, lost, or run away) prompt for user input using GetPromptedInput
            // if they attack, both the enemy and the player do damage
            // if they run, the encounter ends and the player returns to the arena
            // if the input isn't recognized, only the enemy attacks
            while (outcome != Win && outcome != Lose && outcome != Draw && outcome != Run)
            {
                Console.WriteLine("Your current health is {0}, the goblin's health is {1}", stats[Health], currentEnemyHealth);
                action = SmartConsole.GetPromptedInput("What would you like to do? Attack/Run >").ToLower();
                switch (action)
                {
                    // player attacks
                    case "attack":
                        playerDamage = stats[Strength] * DamageMult;
                        Console.WriteLine("You attack the goblin, doing {0} damage!", playerDamage);
                        currentEnemyHealth -= playerDamage;
                        // prevents enemy from doing negative damage when player dexterity is too high
                        if (EnemyAttack - stats[Dexterity] >= 0)
                        {
                            enemyDamage = EnemyAttack - stats[Dexterity];
                        }
                        else
                        {
                            enemyDamage = 0;
                        }
                        Console.WriteLine("The goblin hits you for {0} damage!", enemyDamage);
                        stats[Health] -= enemyDamage;

                        // checks if the player has won, lost, or tied against the enemy
                        if (currentEnemyHealth <= 0 && stats[Health] > 0)
                        {
                            Console.WriteLine("You won!");
                            outcome = Win;
                        }
                        else if (currentEnemyHealth <= 0 && stats[Health] <= 0)
                        {
                            Console.WriteLine("Both you and the goblin have no remaining health. You draw, but you lose the game!");
                            outcome = Draw;
                        }
                        else if (stats[Health] <= 0)
                        {
                            Console.WriteLine("You lose!");
                            outcome = Lose;
                        }
                        Console.WriteLine();
                        break;
                    // player runs
                    case "run":
                        Console.WriteLine("You retreat to the arena.");
                        outcome = Run;
                        Console.WriteLine();
                        break;
                    // any other input
                    default:
                        Console.WriteLine("Your input was not recognized, but the goblin doesn't care.");
                        // prevents enemy from doing negative damage when player dexterity is too high
                        if (EnemyAttack - stats[Dexterity] >= 0)
                        {
                            enemyDamage = EnemyAttack - stats[Dexterity];
                        }
                        else
                        {
                            enemyDamage = 0;
                        }
                        Console.WriteLine("The goblin hit you for {0} damage!", enemyDamage);
                        stats[Health] -= enemyDamage;
                        // checks if the player has lost
                        if (stats[Health] <= 0)
                        {
                            Console.WriteLine("You lose! Be more careful about your input next time.");
                            outcome = Lose;
                        }
                        Console.WriteLine();
                        break;
                }
            }
            return outcome; // replace this. it's just so the starter code compiles.
            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Get the player's name & stats. Stats are loaded into the provided array and
        /// the name is returned.
        /// </summary>
        /// <param name="statsArray">A reference int[4] array that this method will put data into</param>
        /// <returns>The player's name</returns>
        
        // Will prompt the user for their name using GetPromptedInput
        // then use GetValidIntegerInput to collect their stats
        // All stats must be assigned a value of 1 or greater and must not sum to more than the max
        // skill points
        // Then health will be updated and their name returned
        private static string GetPlayerInfo(int[] statsArray)
        {
            // TODO: Implement the GetPlayerInfo method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // local variable declaration
            int pointsRemaining = MaxPoints;
            // prompts for the user's name and explains the stat allocation
            string name = SmartConsole.GetPromptedInput("Welcome, please enter your name >");
            Console.WriteLine("Hello, {0}. I'll need a bit more information from you before we can start.", name);
            Console.WriteLine("You have {0} points to build your character and three attributes to allocate them to.", MaxPoints);
            Console.WriteLine();

            // prompts the user to enter number between 1 and 2 less than the number of points currently unassigned,
            // ensuring each stat is assigned at least 1 point
            // assigns this value to their strength stat
            statsArray[Strength] = SmartConsole.GetValidIntegerInput("How many points would you like to allocate to Strength? >", 
                1, MaxPoints - (Constitution - Strength));
            pointsRemaining -= statsArray[Strength];
            Console.WriteLine("You have {0} points remaining.", pointsRemaining);
            Console.WriteLine();

            // prompts the user to enter number between 1 and 1 less than the number of points currently unassigned,
            // ensuring each stat is assigned at least 1 point
            // assigns this value to their dexterity stat
            statsArray[Dexterity] = SmartConsole.GetValidIntegerInput("How many points would you like to allocate to Dexterity? >",
                1, pointsRemaining - (Constitution - Dexterity));
            pointsRemaining -= statsArray[Dexterity];
            Console.WriteLine("You have {0} points remaining.", pointsRemaining);
            Console.WriteLine();

            // prompts the user to enter number between 1 the number of points currently unassigned, ensuring each stat is assigned at least 1 point
            // assigns this value to their constitution stat
            statsArray[Constitution] = SmartConsole.GetValidIntegerInput("How many points would you like to allocate to Constitution? >",
                1, pointsRemaining);
            pointsRemaining -= statsArray[Constitution];
            // calculates their health
            statsArray[Health] = statsArray[Constitution] * HealthMult;
            Console.WriteLine("You left {0} point(s) unused.", pointsRemaining);
            Console.WriteLine();

            return name;
            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Given a reference to a 2d array variable (that will be null to start):
        /// - Prompt for the desired size and initialize the array
        /// - Put walls along all borders
        /// - Evenly space enemies every few tiles (vert & hor)
        /// - Put empty cells everywhere else
        /// - Place the player start in the top left
        /// - Place an exit in the bottom right
        /// </summary>
        /// <param name="numEnemies">An out param to store the total number of enemies created</param>
        /// <returns>A reference to the final 2d arena</returns>
        
        // prompt the player for the desired arena size using GetValidIntegerInput
        // then create a 2D array based on the input 
        // use a series of nested for loops to access each element in the array
        // then set that element using a series of if/else statements

        // 6. Power Ups
        // additionally, add a power up to an otherwise blank space
        private static char[,] BuildArena(out int numEnemies)
        {
            // Start by setting numEnemies to 0. Increment this whenever you create
            // an enemy and the out param will work just fine. :)
            numEnemies = 0;

            // TODO: Implement the BuildArena method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // prompts the user to give the dimensions of the arena using GetValidIntegerInput (each side is between 10 and 50 elements long)
            int width = SmartConsole.GetValidIntegerInput("How wide should the arena be? (Enter a value from 10 - 50) >", 10, 50);
            int height = SmartConsole.GetValidIntegerInput("How tall should the arena be? (Enter a value from 10 - 50) >", 10, 50);
            char[,] arena = new char[width, height]; 
            // declares variables needed for primary upgrade 6 (power-ups)
            Random potionPosition = new Random();
            int potionHeight;
            int potionWidth;

            // iterates through each element of the arena array
            for (int tall = 0; tall < height; tall++)
            {
                for (int wide = 0; wide < width; wide++)
                {
                    // we are at the border of the arena, so there is a wall in the space
                    if (wide == 0 || tall == 0 || wide == width - 1 || tall == height - 1)
                    {
                        arena[wide, tall] = Wall;
                    }
                    // we are at the top left corner of the arena (within the walls), so the player start is here
                    else if (wide == 1 && tall == 1)
                    {
                        arena[wide, tall] = PlayerStart;
                    }
                    // we are at the bottom right corner of the arena (within the walls), so the exit is here
                    else if(wide == width - 2 && tall == height - 2)
                    {
                        arena[wide, tall] = Exit;
                    }
                    // we are a multiple of enemy spacing away from the top wall and the left wall, so an enemy is here
                    else if (wide % EnemySpacing == 0 && tall % EnemySpacing == 0)
                    {
                        arena[wide, tall] = Enemy;
                        numEnemies++;
                    }
                    // we are anywhere else, so it is empty space
                    else
                    {
                        arena[wide, tall] = Empty;
                    }
                }
            }

            // generate the location of a potion randomly
            do
            {
                potionHeight = potionPosition.Next(1, height - 2);
                potionWidth = potionPosition.Next( 1, width - 2);
            }
            // if the location is not occupied, place a potion there
            // otherwise, generate a new location
            while (arena[potionWidth, potionWidth] != Empty);
            arena[potionHeight, potionWidth] = Potion;

            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // All done
            return arena;
        }

        /// <summary>
        /// Given a reference to a 2d arena and the player's current location, 
        /// print every character using the correct colors.
        /// </summary>
        /// <param name="arena">A reference to the arena to print. This could be ANY size.</param>
        /// <param name="playerLoc">The player's location in a 1d array with element [row, col]</param>

        // this function prints the current state if the arena
        // uses a series of nested loops to access each element of the array
        // it then prints that element in the assigned color using a series of if/else statements
        // if the player character is in a given space, print their character instead
        private static void PrintArena(char[,] arena, int[] playerLoc)
        {
            // TODO: Implement the PrintArena method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            for (int tall = 0; tall < arena.GetLength(1); tall++)
            {
                for (int wide = 0; wide < arena.GetLength(0); wide++)
                {
                    // the player is at this location, so print the player character
                    if (playerLoc[0] == wide && playerLoc[1] == tall)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(Player);
                    }
                    // we are at a wall, so print the wall character
                    else if (arena[wide, tall] == Wall)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Wall);
                    }
                    // we are at the player start, so print the player start
                    else if (arena[wide, tall] == PlayerStart)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(PlayerStart);
                    }
                    // we are at the exit, so print the exit
                    else if (arena[wide, tall] == Exit)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(Exit);
                    }
                    // there is an enemy here so print the enemy
                    else if (arena[wide, tall] == Enemy)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Enemy);
                    }
                    // there is a potion here so print the potion
                    else if (arena[wide, tall] == Potion)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(Potion);
                    }
                    // there is nothing here, so print an empty space
                    else
                    {
                        Console.Write(Empty);
                    }
                }
                // move to the next line
                Console.WriteLine();
            }
            // reset the text color
            Console.ForegroundColor = ConsoleColor.White;
            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }
    }
}