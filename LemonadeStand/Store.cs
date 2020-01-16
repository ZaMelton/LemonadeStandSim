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

        //Make method for all item and not just singular items?
        public void SellItemToPlayer(Player player, int itemsToSell)
        {
            for(int i = 0; i < itemsToSell; i++)
            {
                player.wallet.Money -= pricePerLemon;
            }
        }
    }
}
