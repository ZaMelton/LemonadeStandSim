using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Weather
    {
        public string condition;
        public int temperature;
        private List<string> weatherConditions;

        public Weather(Random rand)
        {
            weatherConditions = new List<string> { "Rainy", "Cloudy", "Sunny", "Windy" };
            this.condition = SetCondition(rand);
            this.temperature = SetTemperature(rand);
        }
        public Weather(int condition, Random rand)
        {
            weatherConditions = new List<string> { "Rainy", "Cloudy", "Sunny", "Windy" };
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
        public string SetCondition(Random rand)
        {
            int index = GetIndex(rand);
            return weatherConditions[index];
        }
        public string SetConditionTest(int index, Random rand)
        {
            return weatherConditions[index];
        }
        public int GetIndex(Random rand)
        {
            return rand.Next(3);
        }
    }
}
