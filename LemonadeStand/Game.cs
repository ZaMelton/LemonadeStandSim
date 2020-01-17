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
        Random rand = new Random();

        public Game()
        {
            player = new Player(GetName());
            store = new Store();
            days = SetDays();
            currentDay = 0;
        }

        public void SimulateGame()
        {
            double dailyProfitOrLoss;
            double totalProfitOrLoss = 0;

            ////////Still testing this all out///////////////////////////////////
            
            Customer oldMan = new OldMan();

            for(int i = 0; i < days.Count; i++)
            {
                UserInterface.DisplayCurrentDaysAndForecast(days, currentDay);
                string itemName;
                double dayStartMoney = player.wallet.Money;
                double dayEndMoney;
                do
                {
                    UserInterface.DisplayMoneyAndInventory(player);
                    itemName = UserInterface.DecideItemToBuy();
                    if (itemName != "nothing")
                    {
                        int itemsToBuy = UserInterface.BuyItemsFromStore(itemName);
                        int itemsSold = store.SellItemToPlayer(player, itemsToBuy, itemName);
                        player.AddItemsToInventory(itemsSold, itemName);
                        UserInterface.ReadAndClear();
                    }

                } while (itemName != "nothing");

                UserInterface.ReadAndClear();
                UserInterface.DisplayMoneyAndInventory(player);
                player.DecideRecipe();

                player.MakePitcher();
                Console.Clear();

                for(int j = 0; j < 30; j++)
                {
                    if(player.pitcher.cupsLeftInPitcher == 0)
                    {
                        if (!player.MakePitcher())
                        {
                            break;
                        }
                    }
                    if(player.pitcher.cupsLeftInPitcher > 0)
                    {
                        ///Still need to fix this so its not always an old man
                        player.SellLemonade(oldMan.BuyLemonade());
                    }
                }

                UserInterface.SellCupMessage(player);
                UserInterface.DisplayCupsLeftInPitcher(player);

                UserInterface.DisplayMoney(player);

                dayEndMoney = player.wallet.Money;
                dailyProfitOrLoss = dayEndMoney - dayStartMoney;
                totalProfitOrLoss += dailyProfitOrLoss;

                string forecast = GetForecast(currentDay);
                UserInterface.DisplayProfitsAndNextDayForecast(days, currentDay, dailyProfitOrLoss, forecast);
                UserInterface.ReadAndClear();

                currentDay++;
                player.cupsSold = 0;
            }
            Console.WriteLine($"Your total gain or loss was: ${totalProfitOrLoss}");
            Console.ReadLine();
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
                dayList.Add(new Day(i, rand));
            }
            return dayList;
        }

        public string GetForecast(int currentDay)
        {
            if(currentDay == days.Count - 1)
            {
                return "There is no next day................... Because you said so.";
            }

            return $"Tomorrow will be {days[currentDay + 1].GetForecast()}";
        }
    }
}
