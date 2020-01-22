using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Kid : Customer
    {
        public Kid()
        {
            name = "Timmy";
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
                        chanceToBuy += rand.Next(70, 171);
                        break;
                    }
                case ("Cloudy"):
                    {
                        chanceToBuy += rand.Next(80, 181);
                        break;
                    }
                case ("Sunny"):
                    {
                        chanceToBuy += rand.Next(99, 200);
                        break;
                    }
                case ("Windy"):
                    {
                        chanceToBuy += rand.Next(65, 166);
                        break;
                    }
            }
            if (player.recipe.pricePerCup > .25)
            {
                chanceToBuy -= 100;
            }
            else if (player.recipe.pricePerCup > .20)
            {
                chanceToBuy -= 25;
            }
            return (chanceToBuy >= 100);
        }
    }
}
