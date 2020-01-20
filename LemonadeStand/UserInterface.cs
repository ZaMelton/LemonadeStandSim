using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    static class UserInterface
    {

        public static string DecidePlayerCount()
        {
            string playerCount;

            Console.WriteLine("Select an option: ");
            Console.WriteLine("1) One player");
            Console.WriteLine("2) Two player");

            playerCount = Console.ReadLine();
            switch (playerCount)
            {
                case "1":
                    return "one";
                case "2":
                    return "two";
                default:
                    return DecidePlayerCount();
            }
        }

        public static string GetName()
        {
            Console.WriteLine("What is your name?");
            return Console.ReadLine();
        }

        public static int DecideLemons()
        {
            Console.WriteLine("How many lemons do you want per pitcher?");
            try
            {
                int amountOfLemons = Int32.Parse(Console.ReadLine());
                return amountOfLemons;
            }
            catch (Exception)
            {
                Console.WriteLine("Not a valid number, please try again.");
                return DecideLemons();
            }
        }

        public static int DecideSugarCubes()
        {
            Console.WriteLine("How many sugar cubes do you want per pitcher?");
            try
            {
                int amountOfSugarCubes = Int32.Parse(Console.ReadLine());
                return amountOfSugarCubes;
            }
            catch (Exception)
            {
                Console.WriteLine("Not a valid number, please try again.");
                return DecideSugarCubes();
            }
        }

        public static int DecideIceCubes()
        {
            Console.WriteLine("How many ice cubes do you want per cup?");
            try
            {
                int amountOfIceCubes = Int32.Parse(Console.ReadLine());
                return amountOfIceCubes;
            }
            catch (Exception)
            {
                Console.WriteLine("Not a valid number, please try again.");
                return DecideIceCubes();
            }
        }

        public static double DecidePrice()
        {
            Console.WriteLine("How much money do you want to sell each cup for? (Example: 0.30)");
            try
            {
                double pricePerCup = Double.Parse(Console.ReadLine());
                return pricePerCup;
            }
            catch (Exception)
            {
                Console.WriteLine("Not a valid price, please try again.");
                return DecidePrice();
            }
        }

        public static string DecideItemToBuy()
        {
            Console.WriteLine("What do you want to buy?");
            Console.WriteLine("1) Lemons");
            Console.WriteLine("2) Sugar Cubes");
            Console.WriteLine("3) Ice Cubes");
            Console.WriteLine("4) Cups");
            Console.WriteLine("5) I don't want to buy anything.");
            string itemChoice = Console.ReadLine();

            switch (itemChoice)
            {
                case "1":
                    return "lemon";

                case "2":
                    return "sugar cube";

                case "3":
                    return "ice cube";

                case "4":
                    return "cup";

                case "5":
                    Console.WriteLine("You have decided to not buy anything.");
                    return "nothing";

                default:
                    Console.WriteLine("Invalid input.");
                    return DecideItemToBuy();
            }
        }

        public static int DecideNumberOfItemsToBuy(string itemName)
        {
            switch (itemName)
            {
                case "lemon":
                    Console.WriteLine("How many lemons do you want to buy?");
                    try
                    {
                        int itemsPurchased = Int32.Parse(Console.ReadLine());
                        return itemsPurchased;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You didn't enter a number, please try again.");
                        return DecideNumberOfItemsToBuy(itemName);
                    }

                case "sugar cube":
                    Console.WriteLine("How many sugar cubes do you want to buy?");
                    try
                    {
                        int itemsPurchased = Int32.Parse(Console.ReadLine());
                        return itemsPurchased;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You didn't enter a number, please try again.");
                        return DecideNumberOfItemsToBuy(itemName);
                    }

                case "ice cube":
                    Console.WriteLine("How many ice cubes do you want to buy?");
                    try
                    {
                        int itemsPurchased = Int32.Parse(Console.ReadLine());
                        return itemsPurchased;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You didn't enter a number, please try again.");
                        return DecideNumberOfItemsToBuy(itemName);
                    }

                case "cup":
                    Console.WriteLine("How many cups do you want to buy?");
                    try
                    {
                        int itemsPurchased = Int32.Parse(Console.ReadLine());
                        return itemsPurchased;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You didn't enter a number, please try again.");
                        return DecideNumberOfItemsToBuy(itemName);
                    }
                case "nothing":
                    Console.WriteLine("You have decided to not purchase anything.");
                    return 0;

                default:
                    Console.WriteLine("Not a valid choice. Please select options 1 - 5");
                    return DecideNumberOfItemsToBuy(DecideItemToBuy());
            }
        }

        public static void SellCupMessage()
        {
            Console.WriteLine($"You sold a cup of lemonade!");
        }

        public static void DeniedSaleMessage()
        {
            Console.WriteLine("The customer decided they didn't want any.");
        }

        public static void PotentialCupsSold(Player player, int potentialCustomers)
        {
            Console.WriteLine($"You sold {player.cupsSold} to {potentialCustomers} potential customers.");
        }

        public static void LackIngredients()
        {
            Console.WriteLine("You don't have enough ingredients to make a pitcher of lemonade!");
        }

        public static void DisplayMoneyAndInventory(Player player)
        {
            Console.WriteLine($"Money: ${Math.Round(player.wallet.Money, 3)}");
            Console.WriteLine($"lemons: {player.inventory.lemons.Count}");
            Console.WriteLine($"sugar cubes: {player.inventory.sugarCubes.Count}");
            Console.WriteLine($"ice cubes: {player.inventory.iceCubes.Count}");
            Console.WriteLine($"cups: {player.inventory.cups.Count}");
            Console.WriteLine();
        }

        public static void DisplayMoney(Player player)
        {
            Console.WriteLine($"Money: ${Math.Round(player.wallet.Money, 3)}");
        }

        public static void DisplayCupsLeftInPitcher(Player player)
        {
            Console.WriteLine($"Cups left in pitcher: {player.pitcher.cupsLeftInPitcher}");
        }

        public static void DisplayCurrentDaysAndForecast(List<Day> days, int currentDay)
        {
            Console.WriteLine($"Day: {days[currentDay].day}");
            Console.WriteLine($"Weather: {days[currentDay].GetForecast()}");
        }

        public static void DisplayProfitsAndNextDayForecast(double dailyProfitOrLoss, string forecast)
        {
            Console.WriteLine();
            Console.WriteLine($"Your daily profit/loss was ${Math.Round(dailyProfitOrLoss, 3)}");
            Console.WriteLine(forecast);
        }

        public static void DisplayTotalProfitsOrLoss(double totalProfitOrLoss)
        {
            Console.WriteLine($"Your total gain or loss was: ${Math.Round(totalProfitOrLoss, 3)}");
            Console.ReadLine();
        }

        public static void DisplayPlayerName(Player player)
        {
            Console.WriteLine(player.name);
        }

        public static void SoldOutMessage()
        {
            Console.WriteLine("You're sold out!");
        }

        public static void ReadAndClear()
        {
            Console.ReadLine();
            Console.Clear();
        }
    }
}
