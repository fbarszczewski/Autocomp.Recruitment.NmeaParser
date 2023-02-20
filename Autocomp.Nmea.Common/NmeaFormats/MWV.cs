using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocomp.Nmea.Common.NmeaFormats
{
    public class MWV
    {
        public double Angle { get; }
        public string Reference { get; }
        public double Speed { get;}
        public string Units { get; }

        public MWV(string[] values)
        {
            if (values != null && values.Length == 5)
            {
                Angle = NmeaParser.StringToDouble(values[0]);

                if (values[1] == "T")
                    Reference = "Theoretical";
                else if (values[1] == "R")
                    Reference = "Relative";
                else
                    Reference = values[1];

                Speed = NmeaParser.StringToDouble(values[2]);

                Units = values[3];
            }
            else
                throw new NotSupportedException("Invalid enter values.");

        }
    }
}
