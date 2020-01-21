using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            Game sim = new Game();

            sim.SimulateGame();
            Console.ReadLine();
        }
    }
}
