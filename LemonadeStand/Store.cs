using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        double pricePerLemon;
        double pricePerSugarCube;
        double pricePerIceCube;
        double pricePerCup;

        public Store()
        {
            pricePerLemon = 0.15;
            pricePerSugarCube = 0.02;
            pricePerIceCube = 0.01;
            pricePerCup = 0.04;
        }

        public int SellItemToPlayer(Player player, int itemsToSell, string itemName)
        {
            int itemsSold = 0;

            switch (itemName)
            {
                case "lemon":
                    for (int i = 0; i < itemsToSell; i++)
                    {
                        if(player.wallet.Money > pricePerLemon)
                        {
                            player.wallet.Money -= pricePerLemon;
                            itemsSold++;
                        }
                        else
                        {
                            Console.WriteLine($"You only had enough money to buy {itemsSold} lemons.");
                            break;
                        }
                    }
                    return itemsSold;

                case "sugar cube":
                    for (int i = 0; i < itemsToSell; i++)
                    {
                        if(player.wallet.Money > pricePerSugarCube)
                        {
                            player.wallet.Money -= pricePerSugarCube;
                            itemsSold++;
                        }
                        else
                        {
                            Console.WriteLine($"You only had enough money to buy {itemsSold} sugar cubes.");
                            break;
                        }
                    }
                    return itemsSold;

                case "ice cube":
                    for (int i = 0; i < itemsToSell; i++)
                    {
                        if (player.wallet.Money > pricePerIceCube)
                        {
                            player.wallet.Money -= pricePerIceCube;
                            itemsSold++;
                        }
                        else
                        {
                            Console.WriteLine($"You only had enough money to buy {itemsSold} ice cubes.");
                            break;
                        }
                    }
                    return itemsSold;

                case "cup":
                    for (int i = 0; i < itemsToSell; i++)
                    {
                        if (player.wallet.Money > pricePerCup)
                        {
                            player.wallet.Money -= pricePerCup;
                            itemsSold++;
                        }
                        else
                        {
                            Console.WriteLine($"You only had enough money to buy {itemsSold} cups.");
                            break;
                        }
                    }
                    return itemsSold;

                default:
                    Console.WriteLine("something wrong with sell item to player method");
                    return 0;
            }
        }
    }
}
