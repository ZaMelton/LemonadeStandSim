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

        public override bool BuyLemonade(Weather weather, Player player, Random rand)
        {
            //for testing purposes, will not always be true
            bool decision = DecideToBuyLemonade(weather, player, rand);
            return decision;
        }

        public override bool DecideToBuyLemonade(Weather weather, Player player, Random rand)
        {
            int chanceToBuy = 0;
            switch (weather.condition)
            {
                case ("Rainy"):
                    {
                        chanceToBuy += rand.Next(80, 181);
                        break;
                    }
                case ("Cloudy"):
                    {
                        chanceToBuy += rand.Next(60, 161);
                        break;
                    }
                case ("Sunny"):
                    {
                        chanceToBuy += rand.Next(50, 151);
                        break;
                    }
                case ("Windy"):
                    {
                        chanceToBuy += rand.Next(15, 116);
                        break;
                    }
            }
            return (chanceToBuy >= 100);
        }
    }
}
