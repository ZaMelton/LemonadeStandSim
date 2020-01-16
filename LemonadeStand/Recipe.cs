using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Recipe
    {
        int amountOfLemons;
        int amountOfSugarCubes;
        int amountOfIceCubes;
        double pricePerCup;

        public Recipe()
        {
            amountOfLemons = 4;
            amountOfSugarCubes = 4;
            amountOfIceCubes = 4;
            pricePerCup = 0.15;
        }

        public void ChangeRecipe(int newAmountOfLemons, int newAmountOfSugarCubes, int newAmountOfIceCubes, double newPricePerCup)
        {
            amountOfLemons = newAmountOfLemons;
            amountOfSugarCubes = newAmountOfSugarCubes;
            amountOfIceCubes = newAmountOfIceCubes;
            pricePerCup = newPricePerCup;
        }
    }
}
