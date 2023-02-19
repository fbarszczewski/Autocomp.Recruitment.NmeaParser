using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocomp.Nmea.Common.NmeaFormats
{
    public class GLL
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public TimeSpan UtcTime { get; private set; }

        public GLL(string[] values)
        {
            if (values !=null && values.Length == 7)
            {
                Latitude = NmeaParser.StringToLatitude(values[0], values[1]);
                Longitude = NmeaParser.StringToLongitude(values[2], values[3]);
                UtcTime = NmeaParser.StringToTimeSpan(values[4]);
            }
        }
    }
}
