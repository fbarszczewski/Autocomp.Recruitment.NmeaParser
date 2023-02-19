using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocomp.Nmea.Common.NmeaFormats
{
    public class MWV
    {
        public int Angle { get; private set; }
        public string Reference { get; private set; }
        public int Speed { get; private set; }
        public string Units { get; private set; }
    }
}
