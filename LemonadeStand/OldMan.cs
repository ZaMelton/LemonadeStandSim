using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class OldMan : Customer
    {
        public OldMan()
        {
            name = "Tom Brady";
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
                        chanceToBuy += rand.Next(30,131);
                        break;
                    }
                case ("Cloudy"):
                    {
                        chanceToBuy += rand.Next(75, 176);
                        break;
                    }
                case ("Sunny"):
                    {
                        chanceToBuy += rand.Next(90, 191);
                        break;
                    }
                case ("Windy"):
                    {
                        chanceToBuy += rand.Next(60, 161);
                        break;
                    }
            }

            if (player.recipe.pricePerCup > 5)
            {
                chanceToBuy -= 100;
            }
            else if (player.recipe.pricePerCup <= .15)
            {
                chanceToBuy += 100;
            }
            else if (player.recipe.pricePerCup > .75)
            {
                chanceToBuy -= 65;
            }
            return (chanceToBuy >= 100);
        }

    }
}
