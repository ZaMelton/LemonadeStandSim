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

        public string DecideItemToBuy()
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

        public int BuyItemsFromStore(string itemName)
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
                        return BuyItemsFromStore(itemName);
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
                        return BuyItemsFromStore(itemName);
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
                        return BuyItemsFromStore(itemName);
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
                        return BuyItemsFromStore(itemName);
                    }
                case "nothing":
                    Console.WriteLine("You have decided to not purchase anything.");
                    return 0;

                default:
                    Console.WriteLine("Not a valid choice. Please select options 1 - 5");
                    return BuyItemsFromStore(DecideItemToBuy());
            }
        }

        public void AddItemsToInventory(int itemsPurchased, string itemType)
        {
            switch (itemType)
            {
                case "lemon":
                    {
                        for (int i = 0; i < itemsPurchased; i++)
                        {
                            inventory.lemons.Add(new Lemon());
                        }
                        Console.WriteLine($"lemons: {inventory.lemons.Count}");
                        break;
                    }
                case "ice cube":
                    {
                        for (int i = 0; i < itemsPurchased; i++)
                        {
                            inventory.iceCubes.Add(new IceCube());
                        }
                        Console.WriteLine($"ice cubes: {inventory.iceCubes.Count}");
                        break;
                    }
                case "sugar cube":
                    {
                        for (int i = 0; i < itemsPurchased; i++)
                        {
                            inventory.sugarCubes.Add(new SugarCube());
                        }
                        Console.WriteLine($"sugar cubes: {inventory.sugarCubes.Count}");
                        break;
                    }
                case "cup":
                    {
                        for (int i = 0; i < itemsPurchased; i++)
                        {
                            inventory.cups.Add(new Cup());
                        }
                        Console.WriteLine($"cups: {inventory.cups.Count}");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("An item name is spelled wrong.");
                        break;
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

        public void SellLemonade(bool customerDecision)
        {
            if (customerDecision)
            {
                if(inventory.iceCubes.Count >= recipe.amountOfIceCubes)
                {
                    wallet.Money += recipe.pricePerCup;
                    pitcher.cupsLeftInPitcher -= 1;
                    inventory.cups.Remove(inventory.cups[0]);
                    Console.WriteLine("You have sold a cup!");
                    for (int i = 0; i < recipe.amountOfIceCubes; i++)
                    {
                        inventory.iceCubes.Remove(inventory.iceCubes[0]);
                    }
                    
                }
            }
        }
    }
}