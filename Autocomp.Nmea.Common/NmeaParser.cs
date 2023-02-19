using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocomp.Nmea.Common
{
    public static class NmeaParser
    {

        public static object Parse(NmeaMessage msg)
        {
            return null;
        }

        public static bool TryParse(NmeaMessage msg, out object result)
        {
            result = null;

            return false;
        }

        public static double StringToLongitude(string value, string ewIndicator)
        {
            if (value == null || value.Length < 3)
                return double.NaN;

            double longitude = int.Parse(value.Substring(0, 3), CultureInfo.InvariantCulture)
                             + double.Parse(value.Substring(3), CultureInfo.InvariantCulture) / 60;

            if (ewIndicator == "W")
                longitude *= -1;

            return longitude;
        }

        public static double StringToLatitude(string value, string nsIndicator)
        {
            if (value == null || value.Length <2)
                return double.NaN;

            double latitude = int.Parse(value.Substring(0, 2), CultureInfo.InvariantCulture)
                            + double.Parse(value.Substring(2), CultureInfo.InvariantCulture) / 60;

            if (nsIndicator == "S")
                latitude *= -1;

            return latitude;
        }

        public static TimeSpan StringToTimeSpan(string value)
        {
            if (value != null && value.Length < 6)
                return TimeSpan.Zero;

            return new TimeSpan(int.Parse(value.Substring(0, 2)), int.Parse(value.Substring(2, 2)), int.Parse(value.Substring(4, 2)));
        }

        public static int StringToInt(string value)
        {
            int number = 0;

            int.TryParse(value, out number);

            return number;
        }
    }
}
