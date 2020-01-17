using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        public Weather weather;
        public List<Customer> customers;
        private Random rand = new Random();
        string[] dayList = new string[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        public string day;

        public Day(int day)
        {
            this.weather = SetWeather();
            this.day = dayList[day % 7];
        }
        public Weather SetWeather()
        {
            int condition = rand.Next(5);
            return new Weather(condition);
        }
        public string GetForecast()
        {
            return $"{weather.condition} and {weather.temperature} degrees";
        }
    }
}
