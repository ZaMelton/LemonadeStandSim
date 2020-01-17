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

        public string SellItemToPlayer(Player player, int itemsToSell, string itemName)
        {
            switch (itemName)
            {
                case "lemon":
                    for (int i = 0; i < itemsToSell; i++)
                    {
                        player.wallet.Money -= pricePerLemon;
                    }
                    return itemName;

                case "sugar cube":
                    for (int i = 0; i < itemsToSell; i++)
                    {
                        player.wallet.Money -= pricePerSugarCube;
                    }
                    return itemName;

                case "ice cube":
                    for (int i = 0; i < itemsToSell; i++)
                    {
                        player.wallet.Money -= pricePerIceCube;
                    }
                    return itemName;

                case "cup":
                    for (int i = 0; i < itemsToSell; i++)
                    {
                        player.wallet.Money -= pricePerCup;
                    }
                    return itemName;

                default:
                    Console.WriteLine("something wrong with sell item to player method");
                    return " ";
            }
        }
    }
}
