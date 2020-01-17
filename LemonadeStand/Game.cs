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

            string itemName;
            do
            {
                itemName = player.DecideItemToBuy();
                if(itemName != "nothing")
                {
                    int itemsToBuy = player.BuyItemsFromStore(itemName);
                    store.SellItemToPlayer(player, itemsToBuy, itemName);
                    player.AddItemsToInventory(itemsToBuy, itemName);
                    Console.WriteLine(player.wallet.Money); 
                }

                Console.WriteLine();
                Console.WriteLine($"lemons: {player.inventory.lemons.Count}");
                Console.WriteLine($"sugar cubes: {player.inventory.sugarCubes.Count}");
                Console.WriteLine($"ice cubes: {player.inventory.iceCubes.Count}");
                Console.WriteLine($"cups: {player.inventory.cups.Count}");

            } while (itemName != "nothing");

            player.DecideRecipe();

            player.MakePitcher();
            Console.WriteLine($"lemons: {player.inventory.lemons.Count}");
            Console.WriteLine($"sugar cubes: {player.inventory.sugarCubes.Count}");

            player.SellLemonade(customer.BuyLemonade());
            Console.WriteLine($"ice cubes: {player.inventory.iceCubes.Count}");
            Console.WriteLine($"cups: {player.inventory.cups.Count}");
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
                dayList.Add(new Day(i));
            }
            return dayList;
        }
        public string GetForecast(int currentDay)
        {
            return $"Tomorrow will be {days[currentDay + 1].GetForecast()}";
        }
    }
}
