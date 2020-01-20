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
        public int cupsSold;

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
            recipe.ChangeRecipe(UserInterface.DecideLemons(), UserInterface.DecideSugarCubes(), UserInterface.DecideIceCubes(), UserInterface.DecidePrice());
            Console.ReadLine();
            Console.Clear();
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
                        break;
                    }
                case "ice cube":
                    {
                        for (int i = 0; i < itemsPurchased; i++)
                        {
                            inventory.iceCubes.Add(new IceCube());
                        }
                        break;
                    }
                case "sugar cube":
                    {
                        for (int i = 0; i < itemsPurchased; i++)
                        {
                            inventory.sugarCubes.Add(new SugarCube());
                        }
                        break;
                    }
                case "cup":
                    {
                        for (int i = 0; i < itemsPurchased; i++)
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

        public bool MakePitcher()
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
                return true;
            }
            else
            {
                UserInterface.LackIngredients();
                return false;
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
                if(inventory.iceCubes.Count >= recipe.amountOfIceCubes && inventory.cups.Count > 0)
                {
                    pitcher.cupsLeftInPitcher -= 1;
                    inventory.cups.Remove(inventory.cups[0]);
                    //loop to remove ice cubes
                    for (int i = 0; i < recipe.amountOfIceCubes; i++)
                    {
                        inventory.iceCubes.Remove(inventory.iceCubes[0]);
                    }

                    UserInterface.SellCupMessage();
                    wallet.Money += recipe.pricePerCup;
                    cupsSold++;
                }
            }
            else
            {
                UserInterface.DeniedSaleMessage();
            }
        }
    }
}