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


    }
}
