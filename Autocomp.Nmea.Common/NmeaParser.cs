using Autocomp.Nmea.Common.NmeaFormats;
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
            if (msg.Header.Contains("GLL"))
                return new GLL(msg.Fields);

            else if(msg.Header.Contains("MWV"))
                return new MWV(msg.Fields);

            else
                throw new NotSupportedException("Nmea type not supported");

        }

        public static bool TryParse(NmeaMessage msg, out object result)
        {
            if (NmeaCrcCalculator.CrcIsCorrect(msg))
            {
                result = Parse(msg);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }


        public static double StringToLongitude(string value, string ewIndicator)
        {
            if (value == null || value.Length < 3)
                return double.NaN;

            double longitude = int.Parse(value.Substring(0, 3), CultureInfo.InvariantCulture)
                             + double.Parse(value.Substring(3), CultureInfo.InvariantCulture) / 60;

            if (ewIndicator == "W")
                longitude *= -1;

            return Math.Round(longitude,8);
        }

        public static double StringToLatitude(string value, string nsIndicator)
        {
            if (value == null || value.Length <2)
                return double.NaN;

            double latitude = int.Parse(value.Substring(0, 2), CultureInfo.InvariantCulture)
                            + double.Parse(value.Substring(2), CultureInfo.InvariantCulture) / 60;

            if (nsIndicator == "S")
                latitude *= -1;

            return Math.Round(latitude, 8);
        }

        public static TimeSpan StringToTimeSpan(string value)
        {
            if (value != null && value.Length < 6)
                return TimeSpan.Zero;

            return new TimeSpan(int.Parse(value.Substring(0, 2)), int.Parse(value.Substring(2, 2)), int.Parse(value.Substring(4, 2)));
        }

        public static double StringToDouble(string value)
        {
            double number = 0;

            double.TryParse(value,NumberStyles.Any ,CultureInfo.InvariantCulture, out number);

            return number;
        }
    }
}
