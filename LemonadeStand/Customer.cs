using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    abstract class Customer
    {
        public string name;

        public abstract bool BuyLemonade();

        public abstract bool DecideToBuyLemonade();

    }
}
