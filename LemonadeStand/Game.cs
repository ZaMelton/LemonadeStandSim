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
            currentDay = 1;
        }

        public void SimulateGame()
        {
            double dailyProfitOrLoss = 0;
            double totalProfitOrLoss = 0;
            //everything in here is currently for testing purposes/////////////////////////////////
            Customer oldMan = new OldMan();
            for(int i = 0; i < days.Count; i++)
            {
                Console.WriteLine($"Day: {currentDay}");
                string itemName;
                double dayStartMoney = player.wallet.Money;
                double dayEndMoney;
                do
                {
                    Console.WriteLine($"Money: ${Math.Round(player.wallet.Money, 3)}");
                    Console.WriteLine($"lemons: {player.inventory.lemons.Count}");
                    Console.WriteLine($"sugar cubes: {player.inventory.sugarCubes.Count}");
                    Console.WriteLine($"ice cubes: {player.inventory.iceCubes.Count}");
                    Console.WriteLine($"cups: {player.inventory.cups.Count}");
                    Console.WriteLine();
                    itemName = player.DecideItemToBuy();
                    if (itemName != "nothing")
                    {
                        int itemsToBuy = player.BuyItemsFromStore(itemName);
                        int itemsSold = store.SellItemToPlayer(player, itemsToBuy, itemName);
                        player.AddItemsToInventory(itemsSold, itemName);
                        Console.WriteLine($"Money: ${Math.Round(player.wallet.Money, 3)}");
                        Console.ReadLine();
                        Console.Clear();
                    }

                } while (itemName != "nothing");

                Console.ReadLine();
                Console.Clear();
                player.DecideRecipe();

                player.MakePitcher();
                Console.WriteLine($"lemons: {player.inventory.lemons.Count}");
                Console.WriteLine($"sugar cubes: {player.inventory.sugarCubes.Count}");

                bool decision = oldMan.DecideToBuyLemonade();
                player.SellLemonade(oldMan.BuyLemonade(decision));
                Console.WriteLine($"ice cubes: {player.inventory.iceCubes.Count}");
                Console.WriteLine($"cups: {player.inventory.cups.Count}");
                Console.WriteLine($"Cups left in pitcher: {player.pitcher.cupsLeftInPitcher}");

                Console.WriteLine($"Money: ${Math.Round(player.wallet.Money, 3)}");

                dayEndMoney = player.wallet.Money;
                dailyProfitOrLoss = dayEndMoney - dayStartMoney;
                totalProfitOrLoss += dailyProfitOrLoss;
                Console.WriteLine();
                Console.WriteLine($"Your daily profit/loss was ${dailyProfitOrLoss}");
                Console.ReadLine();
                Console.Clear();

                currentDay++;
            }

            Console.WriteLine($"Your total gain or loss was: ${totalProfitOrLoss}");

            ////////////////////////////////////////////////////////////////////////
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
