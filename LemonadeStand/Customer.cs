using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class Customer
    {
        public string name;

        public abstract bool BuyLemonade(Weather weather, Player player, Random rand);

        public abstract bool DecideToBuyLemonade(Weather weather, Player player, Random rand);

    }
}
