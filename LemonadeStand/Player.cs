using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        string name;
        Inventory inventory;
        Wallet wallet;
        Recipe recipe;
        Pitcher pitcher;

        public Player(string name)
        {
            this.name = name;
            wallet = new Wallet(20);
            inventory = new Inventory();
            recipe = new Recipe();
            pitcher = new Pitcher();
        }

        public void DecideRecipe()
        {
            recipe.ChangeRecipe(DecideLemons(), DecideSugarCubes(), DecideIceCubes(), DecidePrice());
        }

        public int DecideLemons()
        {
            Console.WriteLine("How many lemons do you want per pitcher?");
            try
            {
                int amountOfLemons = Int32.Parse(Console.ReadLine());
                return amountOfLemons;
            }
            catch(Exception)
            {
                Console.WriteLine("Not a valid number, please try again.");
                return DecideLemons();
            }
        }

        public int DecideSugarCubes()
        {
            Console.WriteLine("How many sugar cubes do you want per pitcher?");
            try
            {
                int amountOfSugarCubes = Int32.Parse(Console.ReadLine());
                return amountOfSugarCubes;
            }
            catch (Exception)
            {
                Console.WriteLine("Not a valid number, please try again.");
                return DecideSugarCubes();
            }
        }

        public int DecideIceCubes()
        {
            Console.WriteLine("How many ice cubes do you want per cup?");
            try
            {
                int amountOfIceCubes = Int32.Parse(Console.ReadLine());
                return amountOfIceCubes;
            }
            catch (Exception)
            {
                Console.WriteLine("Not a valid number, please try again.");
                return DecideIceCubes();
            }
        }

        public double DecidePrice()
        {
            Console.WriteLine("How much money do you want to sell each cup for? (Example: 0.30)");
            try
            {
                double pricePerCup = Double.Parse(Console.ReadLine());
                return pricePerCup;
            }
            catch (Exception)
            {
                Console.WriteLine("Not a valid price, please try again.");
                return DecidePrice();
            }
        }
    }
}
