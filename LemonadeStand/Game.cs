using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LemonadeStand
{
    public class Game
    {
        Player playerOne;
        Player playerTwo;
        List<Day> days;
        Store store;
        int currentDay;
        Random rand = new Random();

        public Game()
        {
            store = new Store();
            currentDay = 0;
        }

        public void SimulateGame()
        {
            string playerCountDecision = UserInterface.DecidePlayerCount();
            if (playerCountDecision == "one")
            {
                playerOne = new Player(UserInterface.GetName());
                days = SetDays();
                UserInterface.ReadAndClear();
                OnePlayerSim();
            }
            else
            {
                playerOne = new Player(UserInterface.GetName());
                playerTwo = new Player(UserInterface.GetName());
                days = SetDays();
                UserInterface.ReadAndClear();
                TwoPlayerSim();
            }
        }

        public void OnePlayerSim()
        {
            for (int i = 0; i < days.Count; i++)
            {
                PlayerTurn(playerOne);
                currentDay++;
            }

            UserInterface.DisplayTotalProfitsOrLoss(playerOne.totalProfitOrLoss);
        }

        public void TwoPlayerSim()
        {
            for(int i = 0; i < days.Count; i++)
            {
                PlayerTurn(playerOne);
                PlayerTurn(playerTwo);
                currentDay++;
            }

            UserInterface.DisplayPlayerName(playerOne);
            UserInterface.DisplayTotalProfitsOrLoss(playerOne.totalProfitOrLoss);

            UserInterface.DisplayPlayerName(playerTwo);
            UserInterface.DisplayTotalProfitsOrLoss(playerTwo.totalProfitOrLoss);
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
                return "There is no next day, therefore, there is no forecast....";
            }

            return $"Tomorrow will be {days[currentDay + 1].GetForecast()}";
        }

        public void BuyItems(Player player)
        {
            string itemName;
            do
            {
                UserInterface.DisplayMoneyAndInventory(player);

                itemName = UserInterface.DecideItemToBuy();
                if (itemName != "nothing")
                {
                    int itemsToBuy = UserInterface.DecideNumberOfItemsToBuy(itemName);
                    int itemsSold = store.SellItemToPlayer(player, itemsToBuy, itemName);
                    player.AddItemsToInventory(itemsSold, itemName);
                    UserInterface.ReadAndClear();
                }

            } while (itemName != "nothing");
        }

        public void DayOfSales(List<Customer> customers, List<Day> days, Player player)
        {
            //To go through 8 hours in a day
            for (int i = 1; i <= days[currentDay].hoursInDay; i++)
            {
                UserInterface.DisplayMoneyAndInventory(player);
                Console.WriteLine($"Hour {i}");
                //divide potential customers by number of hours in a day to give you a certain number of customers per hour
                for(int j = 0; j < (days[currentDay].potentialCustomers / days[currentDay].hoursInDay); j++)
                {
                    if (player.pitcher.cupsLeftInPitcher == 0)
                    {
                        if (!player.MakePitcher())
                        {
                            break;
                        }
                    }

                    int randomCustomer = rand.Next(0, customers.Count);
                    if (player.pitcher.cupsLeftInPitcher > 0 && player.inventory.cups.Count > 0 && player.inventory.iceCubes.Count > 0)
                    {
                        player.SellLemonade(customers[randomCustomer].BuyLemonade(days[currentDay].weather, player, rand));
                        Thread.Sleep(100);
                    }
                    else
                    {
                        UserInterface.SoldOutMessage();
                        break;
                    }
                }
                UserInterface.ReadAndClear();
            }
        }

        public void PlayerTurn(Player player)
        {
            UserInterface.DisplayCurrentDaysAndForecast(days, currentDay);

            BuyItems(player);

            UserInterface.ReadAndClear();
            UserInterface.DisplayMoneyAndInventory(player);
            Console.WriteLine();
            UserInterface.DisplayCurrentDaysAndForecast(days, currentDay);
            
            player.DecideRecipe();

            player.MakePitcher();
            Console.Clear();

            DayOfSales(days[currentDay].customers, days, player);
            UserInterface.PotentialCupsSold(player, days[currentDay].potentialCustomers);
            UserInterface.DisplayCupsLeftInPitcher(player);

            UserInterface.DisplayMoney(player);

            player.dayEndMoney = player.wallet.Money;
            player.dailyProfitOrLoss = player.dayEndMoney - player.dayStartMoney;
            player.totalProfitOrLoss += player.dailyProfitOrLoss;

            UserInterface.DisplayProfitsAndNextDayForecast(player.dailyProfitOrLoss, GetForecast(currentDay));
            UserInterface.ReadAndClear();

            player.cupsSold = 0;
        }
    }
}
