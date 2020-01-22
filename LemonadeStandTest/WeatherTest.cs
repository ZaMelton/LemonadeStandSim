using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;

namespace LemonadeStandTest
{
    [TestClass]
    public class WeatherTest
    {
        Random rand = new Random();
        [TestMethod]
        public void SetTemperature_ConditionIsRainy_TemperatureIs50To65()
        {
            //Arrange
            Weather weather = new Weather(0, rand);
            int actual;
            bool inRange;

            //Act
            weather.SetTemperature(rand);
            actual = weather.temperature;
            inRange = (actual <= 65 && actual >= 50);

            //Assert
            Assert.IsTrue(inRange);
        }
        [TestMethod]
        public void SetTemperature_ConditionIsCloudy_TemperatureIs55To75()
        {
            //Arrange
            Weather weather = new Weather(1, rand);
            int actual;
            bool inRange;

            //Act
            weather.SetTemperature(rand);
            actual = weather.temperature;
            inRange = (actual <= 75 && actual >= 55);

            //Assert
            Assert.IsTrue(inRange);
        }
        [TestMethod]
        public void SetTemperature_ConditionIsSunny_TemperatureIs70To95()
        {
            //Arrange
            Weather weather = new Weather(2, rand);
            int actual;
            bool inRange;

            //Act
            weather.SetTemperature(rand);
            actual = weather.temperature;
            inRange = (actual <= 95 && actual >= 70);

            //Assert
            Assert.IsTrue(inRange);
        }
        [TestMethod]
        public void SetTemperature_ConditionIsWindy_TemperatureIs50To80()
        {
            //Arrange
            Weather weather = new Weather(3, rand);
            int actual;
            bool inRange;

            //Act
            weather.SetTemperature(rand);
            actual = weather.temperature;
            inRange = (actual <= 80 && actual >= 50);

            //Assert
            Assert.IsTrue(inRange);
        }
        [TestMethod]
        public void SetConditionTest_IndexIs0_ConditionIsRainy()
        {
            //Arrange
            Weather weather = new Weather(0,rand);
            string expected = "Rainy";
            string actual;

            //Act
            actual = weather.SetConditionTest(0,rand);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetConditionTest_IndexIs1_ConditionIsCloudy()
        {
            //Arrange
            Weather weather = new Weather(1, rand);
            string expected = "Cloudy";
            string actual;

            //Act
            actual = weather.SetConditionTest(1, rand);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetConditionTest_IndexIs2_ConditionIsSunny()
        {
            //Arrange
            Weather weather = new Weather(2, rand);
            string expected = "Sunny";
            string actual;

            //Act
            actual = weather.SetConditionTest(2, rand);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetConditionTest_IndexIs3_ConditionIsWindy()
        {
            //Arrange
            Weather weather = new Weather(3, rand);
            string expected = "Windy";
            string actual;

            //Act
            actual = weather.SetConditionTest(3, rand);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
