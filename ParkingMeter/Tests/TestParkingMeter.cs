using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingMeter.App;

namespace ParkingMeter.Tests
{
    [TestFixture]
    public class TestParkingMeter
    {
        private App.ParkingMeter _parkingMeter;

        DateTime _startingDate;

        [SetUp]
        public void SetUp()
        {
            _parkingMeter = new App.ParkingMeter();
            _startingDate = new DateTime(2013, 7, 5, 7, 0, 0);
        }

        [Test]
        public void ParkingMeter_GetMoney_WeekDay_LowerThan1euro_Return0min()
        {
            double money = 0.5;
            TimeSpan endDate = _parkingMeter.GetTimeLeft(money);

            Assert.AreEqual(endDate, new TimeSpan(0,0,0));
        }

        [Test]
        public void ParkingMeter_GetMoney_WeekDay_1euros_Return20min() 
        {
            double money = 1.0;
            TimeSpan endDate = _parkingMeter.GetTimeLeft(money);

            Assert.AreEqual(endDate, new TimeSpan(0, 20, 0));
        }

        [Test]
        public void ParkingMeter_GetMoney_WeekDay_Between1and2euros_Return20min()
        {
            double money = 1.50;
            TimeSpan endDate = _parkingMeter.GetTimeLeft(money);

            Assert.AreEqual(endDate, new TimeSpan(0, 20, 0));
        }

        [Test]
        public void ParkingMeter_GetMoney_WeekDay_2euros_Return1h()
        {
            double money = 2.0;
            TimeSpan endDate = _parkingMeter.GetTimeLeft(money);

            Assert.AreEqual(endDate, new TimeSpan(1, 0, 0));
        }

        [Test]
        public void ParkingMeter_GetMoney_WeekDay_Between2and3euros_Return1h()
        {
            double money = 2.50;
            TimeSpan endDate = _parkingMeter.GetTimeLeft(money);

            Assert.AreEqual(endDate, new TimeSpan(1, 0, 0));
        }

        [Test]
        public void ParkingMeter_GetMoney_WeekDay_3euros_Return2h()
        {
            double money = 3;
            TimeSpan endDate = _parkingMeter.GetTimeLeft(money);

            Assert.AreEqual(endDate, new TimeSpan(2, 0, 0));
        }

        [Test]
        public void ParkingMeter_GetMoney_WeekDay_Between3and5euros_Return2h()
        {
            double money = 4;
            TimeSpan endDate = _parkingMeter.GetTimeLeft(money);

            Assert.AreEqual(endDate, new TimeSpan(2, 0, 0));
        }

        [Test]
        public void ParkingMeter_GetMoney_WeekDay_5euros_Return12h()
        {
            double money = 5;
            TimeSpan endDate = _parkingMeter.GetTimeLeft(money);

            Assert.AreEqual(endDate, new TimeSpan(12, 0, 0));
        }

        [Test]
        public void ParkingMeter_GetMoney_WeekDay_Between5and8euros_Return12h()
        {
            double money = 7;
            TimeSpan endDate = _parkingMeter.GetTimeLeft(money);

            Assert.AreEqual(endDate, new TimeSpan(12, 0, 0));
        }

        [Test]
        public void ParkingMeter_GetMoney_WeekDay_8euros_Return1day()
        {
            double money = 8;
            TimeSpan endDate = _parkingMeter.GetTimeLeft(money);

            Assert.AreEqual(endDate, new TimeSpan(24, 0, 0));
        }

        [Test]
        public void ParkingMeter_GetMoney_WeekDay_MoreThan8euros_Return1day()
        {
            double money = 10;
            TimeSpan endDate = _parkingMeter.GetTimeLeft(money);

            Assert.AreEqual(endDate, new TimeSpan(24, 0, 0));
        }

        [Test]
        public void ParkingMeter_GetMoney_WeekDayAt7h_20min_Return8h20min()
        {
            TimeSpan duration = new TimeSpan(0,20,0);
            DateTime endDate = _parkingMeter.DisplayTimeLeft(_startingDate, duration);

            Assert.AreEqual(endDate, _startingDate.Add(new TimeSpan(1, 20, 0)), "end");
        }
    }
}
