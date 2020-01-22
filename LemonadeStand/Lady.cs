using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Lady : Customer
    {
        public Lady()
        {
            name = "Karen";
        }

        public override bool BuyLemonade(Weather weather, Player player, Random rand)
        {
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
                        chanceToBuy += rand.Next(20, 121);
                        break;
                    }
                case ("Cloudy"):
                    {
                        chanceToBuy += rand.Next(40, 141);
                        break;
                    }
                case ("Sunny"):
                    {
                        chanceToBuy += rand.Next(95, 196);
                        break;
                    }
                case ("Windy"):
                    {
                        chanceToBuy += rand.Next(50, 151);
                        break;
                    }
            }
            if (player.recipe.pricePerCup > .50)
            {
                chanceToBuy -= 80;
            }
            else if (player.recipe.pricePerCup > .35)
            {
                chanceToBuy -= 15;
            }
            return (chanceToBuy >= 100);
        }
    }
}
