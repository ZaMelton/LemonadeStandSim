using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;

namespace LemonadeStandTest
{
    [TestClass]
    public class DayTest
    {
        Random rand = new Random();
        [TestMethod]
        public void GetForecast_ConditionWindyTemperature60Degrees_OutputWindyAnd60()
        {
            //Arragne
            Day day = new Day(2,rand);
            string expected = "Windy and 60 degrees";
            string actual;

            //Act
            actual = day.GetForecastTest("Windy",60);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
