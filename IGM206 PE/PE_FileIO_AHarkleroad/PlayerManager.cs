using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_FileIO_AHarkleroad
{
    internal class PlayerManager
    {
        // variable declaration
        private string fileName;
        List<Player> players = new List<Player>();

        // creates a player object and adds it to the player list
        public void CreatePlayer(string name, int strength, int health)
        {
            Player player = new Player(name, strength, health);
            players.Add(player);
            Console.WriteLine("Added {0} to the list.", player.Name);
        }

        // prints each player in the playerManager list by calling ToString()
        public void Print()
        {
            // if there are players in the list, it prints them
            if (players.Count != 0)
            {
                foreach (Player player in players)
                {
                    Console.WriteLine(player.ToString());
                }
            }
            // otherwise, prints an error message
            else
            {
                Console.WriteLine("No players yet, please load them from the file.");
            }
        }

        // takes player info from the given file and adds it to the playerManager list
        public void Load()
        {
            // variable declaration
            fileName = "../../../players.txt";
            StreamReader playerInfo = null;
            string[] playerArray;
            String playerData;

            // if there are any players in the playerManager list, it deletes them
            if (players.Count != 0)
            {
                players.Clear();
            }

            try
            {
                playerInfo = new StreamReader(fileName);
                playerData = playerInfo.ReadLine();
                // if there is any text in the file read each line
                if (playerData != null)
                {
                    while (playerData != null)
                    {
                        playerArray = playerData.Split(',');
                        CreatePlayer(playerArray[0], int.Parse(playerArray[1]), int.Parse(playerArray[2]));
                        playerData = playerInfo.ReadLine();
                    }
                    Console.WriteLine("All data read successfully and all players added to the list.");
                    Console.WriteLine("{0} players created", players.Count);
                }
                // otherwise print an error
                else
                {
                    Console.WriteLine("File is empty.");
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine("There is no player data to load.");
            }

            // if the StreamReader has been opened, close it
            if (playerInfo != null)
            {
                playerInfo.Close();
            }
        }

        // saves players from the playerManager list to the given file
        public void Save()
        {
            // variable declaration
            fileName = "../../../players.txt";
            StreamWriter playerInfo = null;
            string playerDataSave = "";

            try
            {
                // if there are any player in the playerManager list, save each player to a new line in a single string
                if (players.Count != 0)
                {
                    playerInfo = new StreamWriter(fileName);
                    foreach (Player player in players)
                    {
                        playerInfo.WriteLine(player.Name + "," + player.Strength + "," + player.Health);
                    }
                    // write the string (and all player info) to the file
                    playerInfo.Write(playerDataSave);
                    Console.WriteLine("All data saved to the file successfully.");
                }
                // otherwise print an error message
                else
                {
                    Console.WriteLine("There is no player data yet.");
                }
            }

            catch(Exception e)
            {
                Console.WriteLine("Error saving to file {0}: {1}", fileName, e.Message);
            }

            // if the StreamReader has been opened, close it
            if (playerInfo != null)
            {
                playerInfo.Close();
            }
        }
    }
}
