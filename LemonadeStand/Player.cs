using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        public string name;
        public Inventory inventory;
        public Wallet wallet;
        public Recipe recipe;
        public Pitcher pitcher;

        public Player(string name)
        {
            this.name = name;
            wallet = new Wallet(20);
            inventory = new Inventory();
            recipe = new Recipe();
            pitcher = new Pitcher();
        }

        public void DecideRecipe()
        {
            recipe.ChangeRecipe(DecideLemons(), DecideSugarCubes(), DecideIceCubes(), DecidePrice());
        }

        public int DecideLemons()
        {
            Console.WriteLine("How many lemons do you want per pitcher?");
            try
            {
                int amountOfLemons = Int32.Parse(Console.ReadLine());
                return amountOfLemons;
            }
            catch(Exception)
            {
                Console.WriteLine("Not a valid number, please try again.");
                return DecideLemons();
            }
        }

        public int DecideSugarCubes()
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

        public int DecideIceCubes()
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

        public double DecidePrice()
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

<<<<<<< HEAD
        public int BuyItemsFromStore(string itemChoice)
        {
            switch (itemChoice)
            {
                case "1":
                    Console.WriteLine("How many lemons do you want to buy?");
                    try
                    {
                        int lemonsPurchased = Int32.Parse(Console.ReadLine());
                        return lemonsPurchased;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You didn't enter a number, please try again.");
                        return BuyItemsFromStore(itemChoice);
                    }
                default:
                    Console.WriteLine("Not a valid choice. Please select options 1 - 4");
                    return BuyItemsFromStore(itemChoice);
            }

        }

        public void AddLemonsToInventory(int lemonsBought)
        {
            for (int i = 0; i < lemonsBought; i++)
            {
                inventory.lemons.Add(new Lemon());
            }
        }

        public void SellLemonade(bool customerDecision)
        {
            if (customerDecision)
            {
                wallet.Money += recipe.pricePerCup;
                pitcher.cupsLeftInPitcher -= 1;
=======
        public void MakePitcher()
        {
            if (CheckInventory(Lemon.name))
            {
                for (int i = 0; i < recipe.amountOfLemons; i++)
                {
                    inventory.lemons.Remove(inventory.lemons[0]);
                }
            }
            if (CheckInventory(SugarCube.name))
            {
                for (int j = 0; j < recipe.amountOfSugarCubes; j++)
                {
                    inventory.sugarCubes.Remove(inventory.sugarCubes[0]);
                }
            }
            pitcher.cupsLeftInPitcher = 10;
        }

        public bool CheckInventory(string itemName)
        {
            switch (itemName)
            {
                case "lemon":
                    {
                        if (inventory.lemons.Count < recipe.amountOfLemons)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                case "ice cube":
                    {
                        if (inventory.iceCubes.Count < recipe.amountOfIceCubes)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                case "sugar cube":
                    {
                        if (inventory.sugarCubes.Count < recipe.amountOfSugarCubes)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                case "cup":
                    {
                        if (inventory.cups.Count < 1)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                default:
                    {
                        Console.WriteLine("An item name is spelled wrong.");
                        return false;
                    }
>>>>>>> 19b96dfda10d00103ae98cfebc4b2f6541bb2d40
            }
        }
    }
}
