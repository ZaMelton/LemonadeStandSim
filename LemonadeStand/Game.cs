using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        Player player;
        List<Day> days;
        int currentDay;

        public Game()
        {
            player = new Player(GetName());
            days = SetDays();
            currentDay = 0;
        }
        public string GetName()
        {
            Console.WriteLine("What is your name?");
            return Console.ReadLine();
        }
        public List<Day> SetDays()
        {
            int numOfDays;
            List<Day> dayList = new List<Day>();
            Console.WriteLine("How many days would you like to play?");
            try
            {
                numOfDays = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("That is not a number of days.");
                return SetDays();
            }
            for (int i = 0; i < numOfDays; i++)
            {
                dayList.Add(new Day());
            }
            return dayList;
        }
    }
}
