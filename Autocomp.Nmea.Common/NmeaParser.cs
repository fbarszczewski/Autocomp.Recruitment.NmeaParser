using System;
using System.Collections.Generic;
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
            return 0;
        }

        public static double StringToLatitude(string value, string nsIndicator)
        {
            return 0;
        }

        public static TimeSpan StringToTimeSpan(string value)
        {
            return new TimeSpan();
        }
    }
}
