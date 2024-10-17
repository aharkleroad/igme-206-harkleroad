//****************************************************************
// DO NOT modify anything in this file *EXCEPT* where marked
// explicitly with TODO comments!
//****************************************************************
namespace GDP_Exam_1
{
    /// <summary>
    /// A standalone class to hold Item object instances
    /// </summary>
    class Inventory
    {
        // NO additional fields are permitted.
        private List<Item> items = new List<Item>();

        /// <summary>
        /// Return the number of items within the
        /// inventory's list. Nothing can be changed.
        /// </summary>
        public int NumberItems
        {
            // TODO: Complete the property
            get 
            {
                return items.Count;
            }
        }

        /// <summary>
        /// TODO: Complete the AddItem method to add a provided Item reference
        /// into the inventory list
        /// </summary>
        /// 
        // adds the item to the end of the inventory list
        public void AddItem(Item itemToAdd)
        {
            items.Add(itemToAdd);
        }

        /// <summary>
        /// TODO: Complete the PrintSummary method to print the number of items
        /// in the inventory and then a summary of each item.
        /// </summary>
        /// 
        // prints the number of items in the inventory and a description of each
        public void PrintSummary()
        {
            Console.WriteLine("The inventory currently has {0} item(s):", this.NumberItems);
            foreach (Item item in items)
            {
                Console.WriteLine("\t" + item.ToString());
            }
            Console.WriteLine("Total weight: {0}", this.CalculateTotalWeight());
            Console.WriteLine("Total damage from weapons(s): {0}", this.CalculateTotalDamage());
        }


        /// <summary>
        /// TODO: Complete the CalculateTotalWeight method to return the total
        /// weight of all items in the inventory
        /// </summary>
        /// 
        // gets the total weight of all the items in the inventory using the Weight property
        private double CalculateTotalWeight()
        {
            double total = 0;
            foreach (Item item in items)
            {
                total += item.Weight;
            }
            return total;
        }

        /// <summary>
        /// TODO: Complete CalculateTotalWeight method to return the total
        /// damage of all weapons in the inventory
        /// </summary>
        /// 
        // calculates the total damage of all the items in the inventory
        // only adds to damage if the item is a weapon
        private double CalculateTotalDamage()
        {
            double total = 0;
            foreach (Item item in items)
            {
                if (item is Weapon)
                {
                    total += ((Weapon)item).Damage;
                }
            }
            return total;
        }

        /// <summary>
        /// Loads items from a file line by line
        /// </summary>
        public void LoadItems(string filename)
        {
            // creates StreamReader
            StreamReader input = null;

            // TODO: Add exception handling
            try
            {
                input = new StreamReader(filename);
                string line = null;
                // new local variables for Item creation
                string[] lineArray = null;
                Item item;
                while ((line = input.ReadLine()) != null)
                {
                    // TODO: For each line, seperate the data and create
                    // new Food or Weapon objects appropriately
                    lineArray = line.Split('~');
                    // creates a weapon object if it's a weapon and a food object if it's a food, then adds it to the inventory
                    if (lineArray[0] == "Weapon") 
                    {
                        item = new Weapon(lineArray[1], int.Parse(lineArray[2]), double.Parse(lineArray[3]));
                    }
                    else
                    {
                        item = new Food(lineArray[1], int.Parse(lineArray[2]), double.Parse(lineArray[3]));
                    }
                    items.Add(item);
                }
            }
            // catches any exceptions while reading
            catch (Exception e)
            { 
                Console.WriteLine("Uh oh: " + e.Message);
            }

            // closes StreamWriter, even if there was an exception
            if (input != null)
            {
                input.Close();
            }
        }
    }
}
