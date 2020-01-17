using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        Player player;
        List<Day> days;
        Store store;
        int currentDay;

        public Game()
        {
            player = new Player(GetName());
            store = new Store();
            days = SetDays();
            currentDay = 0;
        }

        public void SimulateGame()
        {
            //everything in here is currently for testing purposes
            Customer customer = new Customer("Phil Collins");

            //This will go into its own method later/////////
            Console.WriteLine("What do you want to buy?");
            Console.WriteLine("1) Lemons");
            Console.WriteLine("2) Sugar Cubes");
            Console.WriteLine("3) Ice Cubes");
            Console.WriteLine("4) Cups");
            Console.WriteLine("5) I don't want to buy anything.");
            string itemChoice = Console.ReadLine();
            string itemName = "";
            if(itemChoice == "1")
            {
                itemName = "lemon";
            }
            if (itemChoice == "2")
            {
                itemName = "sugar cube";
            }
            if (itemChoice == "3")
            {
                itemName = "ice cube";
            }
            if (itemChoice == "4")
            {
                itemName = "cups";
            }

            ///////////////////////////////////////////

            int itemsToBuy = player.BuyItemsFromStore(itemChoice);
            store.SellItemToPlayer(player, itemsToBuy);
            player.AddItemsToInventory(itemsToBuy, itemName);
            Console.WriteLine($"lemons: {player.inventory.lemons.Count}");
            Console.WriteLine($"sugar cubes: {player.inventory.sugarCubes.Count}");
            Console.WriteLine($"ice cubes: {player.inventory.iceCubes.Count}");
            Console.WriteLine($"cups: {player.inventory.cups.Count}");

            player.DecideRecipe();

            player.MakePitcher();
            Console.WriteLine($"lemons: {player.inventory.lemons.Count}");
            Console.WriteLine($"sugar cubes: {player.inventory.sugarCubes.Count}");
            Console.WriteLine($"ice cubes: {player.inventory.iceCubes.Count}");
            Console.WriteLine($"cups: {player.inventory.cups.Count}");

            player.SellLemonade(customer.BuyLemonade());
            Console.WriteLine($"Cups left in pitcher: {player.pitcher.cupsLeftInPitcher}");

            Console.WriteLine($"Money: {player.wallet.Money}");
            //////////////////////////////////////////
        }

        public string GetName()
        {
            Console.WriteLine("What is your name?");
            return Console.ReadLine();
        }

        public List<Day> SetDays()
        {
            int numOfDays;
            List<Day> dayList = new List<Day>();
            Console.WriteLine("How many days would you like to play?");
            try
            {
                numOfDays = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("That is not a number of days.");
                return SetDays();
            }
            for (int i = 0; i < numOfDays; i++)
            {
                dayList.Add(new Day());
            }
            return dayList;
        }
    }
}
