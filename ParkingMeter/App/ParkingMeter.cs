using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMeter.App
{
    public class ParkingMeter
    {
        public TimeSpan GetTimeLeft(double money)
        {
            TimeSpan duration = new TimeSpan(0);

            if (money >= 1 && money < 2)
            {
                duration = new TimeSpan(0, 20, 0);
            }
            else if (money >= 2 && money < 3)
            {
                duration = new TimeSpan(1, 0, 0);
            }
            else if (money >= 3 && money < 5)
            {
                duration = new TimeSpan(2, 0, 0);
            }
            else if (money >= 5 && money < 8)
            {
                duration = new TimeSpan(12, 0, 0);
            }
            else if (money >= 8)
            {
                duration = new TimeSpan(24, 0, 0);
            }

            return duration;
        }

        public DateTime DisplayTimeLeft(DateTime now, TimeSpan duration)
        {
            DateTime startingDate = DateTime.MinValue;

            if (now.Hour <= 8)
            {
                startingDate = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0);
            }

            return startingDate.Add(duration);
        }
    }
}
