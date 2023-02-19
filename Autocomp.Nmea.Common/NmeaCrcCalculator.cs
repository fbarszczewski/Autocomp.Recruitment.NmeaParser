using System;

namespace Autocomp.Nmea.Common
{
    public static class NmeaCrcCalculator
    {
        public static byte CRC(NmeaMessage msg)
        {
            return CRC(msg, msg.Format);
        }

        public static byte CRC(NmeaMessage msg, NmeaFormat format)
        {
            byte crc = 0;

            if (!string.IsNullOrEmpty(msg.Header))
            {
                for (int i = 0; i < msg.Header.Length; i++)
                {
                    crc ^= (byte)msg.Header[i];
                }
            }

            if (msg.Fields != null)
            {
                foreach (string field in msg.Fields)
                {
                    crc ^= Convert.ToByte(format.Separator);
                    if (!string.IsNullOrEmpty(field))
                    {
                        for (int i = 0; i < field.Length; i++)
                        {
                            crc ^= (byte)field[i];
                        }
                    }
                }
            }

            return crc;
        }
        /// <summary>
        /// Checks if nmea string is correct
        /// </summary>
        /// <param name="nmeaString"></param>
        /// <returns></returns>
        public static bool IsCorrect(string nmeaString)
        {
            //checks if string looks like nmea string & check sum can be checked
            if (!nmeaString.Contains("$") || !nmeaString.Contains("*") || nmeaString.Length == nmeaString.LastIndexOf("*"))
                return false;

            //calculate checksum
            int checksum = Convert.ToByte(nmeaString[nmeaString.IndexOf('$') + 1]);
            for (int i = nmeaString.IndexOf('$') + 2; i < nmeaString.IndexOf('*'); i++)
                checksum ^= Convert.ToByte(nmeaString[i]);
            //return true if actual checksum match checksum provided in string 
            return checksum.ToString("X2") == nmeaString.Substring(nmeaString.IndexOf("*") + 1);
        }
    }
}
