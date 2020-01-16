using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        public string name;

        public Customer(string name)
        {
            this.name = name;
        }

        public bool BuyLemonade()
        {
            //for testing purposes, will not always be true
            bool decision = true;
            return decision;
        }
    }
}
