using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LemonadeStand
{
    public class Day
    {
        public Weather weather;
        public List<Customer> customers;
        string[] dayList;
        public string day;
        public int potentialCustomers;
        public int hoursInDay;

        public Day(int day, Random rand)
        {
            dayList = new string[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            customers = new List<Customer> { new Lady(), new OldMan(), new Kid(), new Alien() };
            this.weather = SetWeather(rand);
            this.day = dayList[day % 7];
            potentialCustomers = 40;
            hoursInDay = 8;
        }
        public Weather SetWeather(Random rand)
        {
           return new Weather(rand);
        }
        public string GetForecast()
        {
            return $"{weather.condition} and {weather.temperature} degrees";
        }
        public string GetForecastTest(string condition, int temperature)
        {
            return $"{condition} and {temperature} degrees";
        }
    }
}
