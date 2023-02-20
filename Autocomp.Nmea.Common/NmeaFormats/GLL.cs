using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocomp.Nmea.Common.NmeaFormats
{
    public class GLL
    {
        public double Latitude { get; }
        public double Longitude { get; }
        public TimeSpan UtcTime { get;  }

        public GLL(string[] values)
        {
            if (values != null && values.Length == 7)
            {
                Latitude = NmeaParser.StringToLatitude(values[0], values[1]);
                Longitude = NmeaParser.StringToLongitude(values[2], values[3]);
                UtcTime = NmeaParser.StringToTimeSpan(values[4]);
            }
            else
                throw new NotSupportedException("Invalid enter values.");
        }
    }
}
