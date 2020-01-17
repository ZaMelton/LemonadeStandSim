using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        public string condition;
        public int temperature;
        private List<string> weatherConditions = new List<string> { "Rainy", "Cloudy", "Sunny", "Windy"};
        public string predictedForecast;


        public Weather(int condition, Random rand)
        {
            this.condition = weatherConditions[condition];
            this.temperature = SetTemperature(rand);
        }
        public int SetTemperature(Random rand)
        {
            switch (condition)
            {
                case ("Rainy"):
                    return rand.Next(50, 66);
                case ("Cloudy"):
                    return rand.Next(55, 76);
                case ("Sunny"):
                    return rand.Next(70, 96);
                case ("Windy"):
                    return rand.Next(50, 81);
                default:
                    Console.WriteLine("DEV MESSAGE: You set the weather condition wrong");
                    return 0;
            }
        }
    }
}
