// ------------------------------------------------------------------
// DO NOT MODIFY ANY CODE IN THIS FILE EXCEPT:
// - To implement file loading & saving
// - To change the critter types available
// ------------------------------------------------------------------

namespace HW6_CritterFarm
{
    /// <summary>
    /// TODO: Add your own summary of this class!
    /// 
    /// The CritterManager class holds a list of all the current Critters that have been created for the user.
    /// It is able to take input from a file, create Critter objects, and add them to its list by accessing 
    /// Critter constructors if a valid Critter can be made with the data provided.
    /// It can also set up Critters from user input, rather than files.
    /// Additionally, the class keeps track of which Critter is the "active Critter", ie. which Critter the
    /// user is interacting with, to update its boredom and hunger stats correctly using Critter properties 
    /// and methods.
    /// </summary>
    class CritterManager
    {
        // ----------------------------------------------------------------------
        // Fields
        // ----------------------------------------------------------------------

        /// <summary>
        /// List to hold all of the critters by leveraging polymorphism
        /// </summary>
        private List<Critter> critterList;

        /// <summary>
        /// Reference to the current active critter
        /// </summary>
        private Critter activeCritter;

        /// <summary>
        /// The filename to use when loading/saving critters
        /// </summary>
        private string filename;

        /// <summary>
        /// Generator for any pseuod-random numbers needed
        /// </summary>
        private Random rng = new Random();

        // ----------------------------------------------------------------------
        // Properties
        // ----------------------------------------------------------------------

        /// <summary>
        /// Return the NAME of the current active critter or return null if
        /// one isn't active
        /// </summary>
        public String ActiveCritter 
        {
            get 
            {
                if (activeCritter != null)
                {
                    return activeCritter.Name;
                }
                else
                {
                    return null!; // The ! tells the compiler to ignore warnings about a possible null value.
                }
            } 
        }

        // ----------------------------------------------------------------------
        // Default Constructor
        // ----------------------------------------------------------------------

        /// <summary>
        /// Default constructor to initialize the list and active critter
        /// </summary>
        public CritterManager(string filename)
        {
            critterList = new List<Critter>();
            activeCritter = null!; // The ! tells the compiler to ignore warnings about a possible null value.
            this.filename = filename;
        }

        // ---------------------------------------------------------------------------------------------------------------
        // Critter setup via user input
        // ---------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Initial setup of critters. 
        /// Prompts a user for a number of critters, then their names,
        /// then adds newly instantiated critters to the critter list.
        /// All critters start with 0 hunger and 0 boredom.
        /// 
        /// TODO: Review SetupCritters() 
        /// THIS METHOD IS DONE FOR YOU so that you have examples of how to TryParse an enum type and
        /// use a switch statement with enums. You'll have to do both yourself when loading from a file!
        /// </summary>
        public void SetupCritters()
        {
            // Ask user for number of critters and their names
            int numberCritters = SmartConsole.GetValidNumericInput(
                "How many critters should your farm contain (1-5)?",
                1, 5);

            // Gather information about critter names from user,
            //   then create new Critter into the list
            for (int i = 0; i < numberCritters; i++)
            {
                string name = SmartConsole.GetPromptedInput("\nEnter critter " + (i + 1) + " name:");
                string typeString = SmartConsole.GetPromptedInput("What type of critter is "+name+" (Cat, Dog, or Rat)?");
                CritterType type = CritterType.Cat;

                // Enums work with a TryParse too! :)
                while (!Enum.TryParse<CritterType>(typeString, true, out type) // true as the middle param tells TryParse to ignore case
                    || !Enum.IsDefined(typeof(CritterType), type))
                        // TryParse accepts ints that aren't actually valid for this
                        // enum. Using IsDefined checks them before allowing the loop
                        // to proceed.
                {
                    SmartConsole.PrintWarning("Sorry, I don't know how to take care of a "+typeString+".\n");
                    typeString = SmartConsole.GetPromptedInput("What type of critter is " + name + " (Cat, Dog, or Rat)?");
                }

                // Create the correct type of critter
                // TODO: If you don't use Cat, Dog, & Horse as your critter types, fix the setup method

                // The switch statement cases and constructor calls below need to match YOUR critter types
                // TODO: Uncomment this once your child classes exist.
                
                switch (type)
                {
                    case CritterType.Cat:
                        critterList.Add(new Cat(name));
                        break;

                    case CritterType.Dog:
                        critterList.Add(new Dog(name));
                        break;

                    case CritterType.Rat:
                        critterList.Add(new Rat(name));
                        break;

                    default:
                        // shouldn't happen
                        SmartConsole.PrintError(String.Format("Not sure how to create {0} with a type of {1}", name, typeString));
                        i--; // Didn't actually add a critter so go back 1 with our lcv and try again.
                        break;
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------------------
        // Critter file loading and saving
        // ---------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Loads critter data from a file
        /// If there are no saved critters, calls SetupCritters() to allow user to
        /// enter their own critters.
        /// If file data exists, populates critterList with critters built from
        /// the file's data.
        /// </summary>
        public void LoadCrittersFromFile()
        {
            // This method will use a StreamReader to read from a file and create Critter objects.
            // It will utilize a try/catch block to catch fatal errors and use TryParse and
            // if/else statements to ensure each line has good data before it is used to instantiate
            // a Critter object
            // It will then close the StreamReader if the file has been opened
            // ********************************
            // File name: critters.txt
            // File structure (sample line):
            // type|name|hunger #|boredom #
            // ********************************

            // TODO: Implement LoadCrittersFromFile()
            // variable declaration for entire method
            StreamReader reader = null;

            try
            {
                // local variable declaration if the file can be opened
                reader = new StreamReader(filename);
                string line = reader.ReadLine();
                int critterCounter = 0;
                // reads all the lines in the file
                while (line != null)
                {
                    // local variable declaration if there is another line
                    int hunger;
                    int boredom;
                    string[] lineArray = line.Split('|');
                    CritterType type = CritterType.Cat;
                    // if the critter type isn't valid, print an error message
                    if (!Enum.TryParse<CritterType>(lineArray[0], true, out type) 
                    || !Enum.IsDefined(typeof(CritterType), type))
                    {
                        SmartConsole.PrintWarning(String.Format("{0}s aren't supported yet. " +
                            "Skipping this line: {1}", lineArray[0], line));
                    }

                    //CritterType type = CritterType.Cat;

                    //// Enums work with a TryParse too! :)
                    //while (!Enum.TryParse<CritterType>(typeString, true, out type) // true as the middle param tells TryParse to ignore case
                    //    || !Enum.IsDefined(typeof(CritterType), type))
                    //    // TryParse accepts ints that aren't actually valid for this
                    //    // enum. Using IsDefined checks them before allowing the loop
                    //    // to proceed.

                        // if the data for the critter isn't valid, print an error message
                    else if (!int.TryParse(lineArray[2], out hunger) 
                        || !int.TryParse(lineArray[3], out boredom))
                    {
                        SmartConsole.PrintWarning(String.Format("Corrupt data. " +
                            "Skipping this line: {0}", line));
                    }
                    // create a critter of the correct type and add it to the list
                    else
                    {
                        Critter critter;
                        if (type == CritterType.Cat)
                        {
                            critter = new Cat(lineArray[1], hunger, boredom);
                        }
                        else if (type == CritterType.Dog)
                        {
                            critter = new Dog(lineArray[1], hunger, boredom);
                        }
                        else
                        {
                            critter = new Rat(lineArray[1], hunger, boredom);
                        }
                        critterList.Add(critter);
                        critterCounter++;
                    }
                    line = reader.ReadLine();
                }
                SmartConsole.PrintSuccess(String.Format("{0} critters loaded successfully.", critterCounter));
            }
            // catch exeptions opening or creating the file
            catch (Exception e)
            {
                SmartConsole.PrintError("Critter save file doesn't exist or can't be opened." +
                    "\n\nYou'll need to set up a new critter farm.");
                Console.WriteLine();
                SetupCritters();
            }

            // closes the file if it has been opened
            if (reader != null)
            {
                reader.Close();
            }
        }


        /// <summary>
        /// Saves critter data to a file.
        /// If there are no saved critters, writes "No critters saved."
        /// If critters do exist, writes their data to the file.
        /// </summary>
        public void SaveCrittersToFile()
        {
            // This method will use a StreamWriter to write Critter objects to a file in the correct
            // format.
            // It will utilize a try/catch block to catch fatal errors
            // It will then close the StreamWriter if the file has been opened
            // ********************************
            // File name: critters.txt
            // File structure (sample line):
            // type|name|hunger #|boredom #
            // ********************************

            // TODO: Implement SaveCrittersToFile()
            // variable declaration
            StreamWriter writer = null;

            // attempts to open and save to a given file
            try
            {
                writer = new StreamWriter(filename);
                foreach (Critter critter in critterList)
                {
                    writer.WriteLine(critter.Type + "|" + critter.Name + "|" + critter.Hunger + "|"
                        + critter.Boredom);
                }
            }
            // prints an error message if there is an issue opening or accessing it
            catch (Exception e)
            {
                SmartConsole.PrintError("Error saving to file: " + e.Message);
            }

            // closes the file if it has been opened
            if (writer != null)
            {
                writer.Close();
            }
        }

        // ---------------------------------------------------------------------------------------------------------------
        // Critter Control Methods
        // ---------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Sets the active critter to one of the critters in the critter list.
        /// </summary>
        /// <param name="critterName">Name of critter to set the active critter to</param>
        /// <returns>Whether this operation was successful</returns>
        public bool ChooseCritter(string critterName)
        {
            // Determine if the Critter exists in the list
            // And set it as active
            activeCritter = null!; // The ! tells the compiler to ignore warnings about a possible null value.
            for (int i = 0; i < critterList.Count; i++)
            {
                if (critterList[i].Name == critterName)
                {
                    activeCritter = critterList[i];
                }
            }

            // Let Main know whether this was successful
            return activeCritter != null;
        }

        /// <summary>
        /// Retrieves a list of the names of all current critters
        /// </summary>
        /// <returns>List of names of all critters</returns>
        public List<string> GetCritterNames()
        {
            List<string> critterNames = new List<string>();
            for (int i = 0; i < critterList.Count; i++)
            {
                critterNames.Add(critterList[i].Name);
            }
            return critterNames;
        }

        // ---------------------------------------------------------------------------------------------------------------
        // Critter Actions
        // ---------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Feeds the active critter 4 units of food.
        /// </summary>
        public void FeedCritter()
        {
            if (activeCritter == null)
            {
                return;
            }

            Console.WriteLine("Feeding your critter...");
            activeCritter.Eat();
        }


        /// <summary>
        /// Plays with the active critter for 4 fun units.
        /// </summary>
        public void PlayWithCritter()
        {
            if (activeCritter == null)
            {
                return;
            }

            Console.WriteLine("Playing with your critter...");
            activeCritter.Play();
        }


        /// <summary>
        /// Talks with the active critter.
        /// </summary>
        public void TalkToCritter()
        {
            if (activeCritter == null)
            {
                return;
            }

            Console.WriteLine("Talking to your critter...");
            activeCritter.Talk();
        }


        /// <summary>
        /// Simulates time passing for every critter for every "round" of user actions.
        /// </summary>
        public void TimePassing()
        {
            foreach (Critter c in critterList)
            {
                c.PassTime();
                // TODO: Update this to call any child specific methods as well.
                //       For example, in the demo, time passing calls the
                //       the CauseMischeif method on any cats 25% of the time

                // if the Critter is a Rat, there is a 25% chance it will chew
                if (c is Rat)
                {
                    int randomChance = rng.Next(0, 20);
                    if (randomChance < 5)
                    {
                        ((Rat)c).Chew();
                    }
                }
            }
        }

        /// <summary>
        /// Prints critter data about every critter in the list.
        /// Helpful for testing. 
        /// </summary>
        public void PrintCritters()
        {
            // Get string representation of every Critter in the list
            for(int i = 0; i < critterList.Count; i++)
            {
                Console.WriteLine("{0} ({2}): {1}", 
                    i + 1,
                    critterList[i],
                    critterList[i].Type);
            }
        }
    }
}
