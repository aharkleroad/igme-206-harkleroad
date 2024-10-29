using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Lists_AHarkleroad
{
    internal class Player
    {
        // variable declaration
        private string name;
        private List<string> inventory;

        // returns a Player's name
        public string Name
        {
            get { return name; }
        }

        // constructs a Player
        public Player(string name)
        {
            this.name = name;
            inventory = new List<string>();
        }

        // adds an item to a Player's inventory and prints a message
        public void AddToInventory(string item) 
        { 
            inventory.Add(item);
            Console.WriteLine("Item '" + item + "' added to " + name + "'s inventory.");
        }

        // returns an item from a given index in a Player's inventory and removes it from
        // the list if it exists 
        // otherwise returns null
        public string GetItemInSlot(int index)
        {
            string saveItem;
            if (index < 0 || index > inventory.Count - 1)
            {
                Console.WriteLine(index + " was not a valid item #!");
                return null;
            }
            else
            {
                saveItem = inventory.ElementAt(index);
                Console.WriteLine(saveItem + " stolen from slot " + index + " in " + name + "'s inventory!");
                inventory.RemoveAt(index);
                return saveItem;
            }
        }

        // prints a player's inventory
        public void PrintInventory()
        {
            Console.WriteLine(name + "'s Inventory:");
            foreach (string item in inventory)
            {
                Console.WriteLine("\t- " + item);
            }
        }
    }
}
