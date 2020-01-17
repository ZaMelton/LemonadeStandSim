using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Alien : Customer
    {
        public Alien()
        {
            name = "Arbiter";
        }

        public override bool BuyLemonade()
        {
            //for testing purposes, will not always be true
            bool decision = DecideToBuyLemonade();
            return decision;
        }

        public override bool DecideToBuyLemonade()
        {
            return true;
        }
    }
}
