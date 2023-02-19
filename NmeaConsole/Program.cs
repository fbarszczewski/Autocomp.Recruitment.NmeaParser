using Autocomp.Nmea.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NmeaConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //$GPGLL,3953.88008971,N,10506.75318910,W,034138.00,A,D*7A
            //$GNGLL,3150.788156,N,11711.922383,E,062735.00,A,A*76
            //$GPGLL,3723.2475,N,12158.3416,W,161229.487,A,A*41

            //$WIMWV,214.8,R,0.1,K,A*28
            //$WIMWV,320,R,15.0,M,A*0B
            NmeaMessage nmea1 = NmeaMessage.FromString("$GPGLL,3953.88008971,N,10506.75318910,W,034138.00,A,D*7A");

            byte crc = NmeaCrcCalculator.CRC(nmea1);
            Console.WriteLine(string.Join(" ",nmea1.Fields));
            Console.WriteLine($"{crc.ToString("X02")} crc");

            Console.ReadLine();
        }
        private static void Display(object obj)
        {
            Type objType = obj.GetType();
            var properties = objType.GetProperties();

            foreach (var property in properties)
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(obj)}");
            }
        }
    }
}
