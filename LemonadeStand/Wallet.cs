using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Wallet
    {
        double money;

        public Wallet(double money)
        {
            this.money = money;
        }

        public double Money
        {
            get => money;

            set
            {
                if(value <= 0)
                {
                    money = 0;
                }
                else
                {
                    money = value;
                }
            }
        }
    }
}
