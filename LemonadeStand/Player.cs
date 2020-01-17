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
            catch (Exception)
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

        public int BuyItemsFromStore(string itemChoice)
        {
            switch (itemChoice)
            {
                case "1":
                    Console.WriteLine("How many lemons do you want to buy?");
                    try
                    {
                        int itemsPurchased = Int32.Parse(Console.ReadLine());
                        return itemsPurchased;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You didn't enter a number, please try again.");
                        return BuyItemsFromStore(itemChoice);
                    }

                case "2":
                    Console.WriteLine("How many sugar cubes do you want to buy?");
                    try
                    {
                        int itemsPurchased = Int32.Parse(Console.ReadLine());
                        return itemsPurchased;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You didn't enter a number, please try again.");
                        return BuyItemsFromStore(itemChoice);
                    }

                case "3":
                    Console.WriteLine("How many ice cubes do you want to buy?");
                    try
                    {
                        int itemsPurchased = Int32.Parse(Console.ReadLine());
                        return itemsPurchased;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You didn't enter a number, please try again.");
                        return BuyItemsFromStore(itemChoice);
                    }

                case "4":
                    Console.WriteLine("How many cups do you want to buy?");
                    try
                    {
                        int itemsPurchased = Int32.Parse(Console.ReadLine());
                        return itemsPurchased;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You didn't enter a number, please try again.");
                        return BuyItemsFromStore(itemChoice);
                    }
                case "5":
                    Console.WriteLine("You have decided to not purchase anything.");
                    return 0;

                default:
                    Console.WriteLine("Not a valid choice. Please select options 1 - 4");
                    return BuyItemsFromStore(itemChoice);
            }
        }

        public void AddItemsToInventory(int itemsBought, string itemType)
        {
            switch (itemType)
            {
                case "lemon":
                    {
                        for (int i = 0; i < itemsBought; i++)
                        {
                            inventory.lemons.Add(new Lemon());
                        }
                        break;
                    }
                case "ice cube":
                    {
                        for (int i = 0; i < itemsBought; i++)
                        {
                            inventory.iceCubes.Add(new IceCube());
                        }
                        break;
                    }
                case "sugar cube":
                    {
                        for (int i = 0; i < itemsBought; i++)
                        {
                            inventory.sugarCubes.Add(new SugarCube());
                        }
                        break;
                    }
                case "cup":
                    {
                        for (int i = 0; i < itemsBought; i++)
                        {
                            inventory.cups.Add(new Cup());
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("An item name is spelled wrong.");
                        break;
                    }
            }
        }

        public void SellLemonade(bool customerDecision)
        {
            if (customerDecision)
            {
                if(inventory.iceCubes.Count >= recipe.amountOfIceCubes)
                {
                    wallet.Money += recipe.pricePerCup;
                    pitcher.cupsLeftInPitcher -= 1;
                    Console.WriteLine("You sold a cup of lemonade!");
                    for (int i = 0; i < recipe.amountOfIceCubes; i++)
                    {
                        inventory.iceCubes.Remove(inventory.iceCubes[0]);
                    }
                }
            }
        }
        public void MakePitcher()
        {
            if (CheckInventory(new Lemon()) && CheckInventory(new SugarCube()))
            {
                for (int i = 0; i < recipe.amountOfLemons; i++)
                {
                    inventory.lemons.Remove(inventory.lemons[0]);
                }
                for (int j = 0; j < recipe.amountOfSugarCubes; j++)
                {
                    inventory.sugarCubes.Remove(inventory.sugarCubes[0]);
                }
                pitcher.cupsLeftInPitcher = 10;
            }
        }

        public bool CheckInventory(Item item)
        {
            switch (item.name)
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
            }
        }
    }
}