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

            //$WIMWV,214.8,R,0.1,K,A*28
            //$WIMWV,320,R,15.0,M,A*0B


            bool correctInput = false;
            string userInput = "";
            NmeaMessage nmea=null;
            object nmeaType;



            while (true)
            {
                Console.WriteLine("Enter Nmea message (only GLL & MWV supported)");

                //check user input

                while (!correctInput)
                {
                    userInput = Console.ReadLine();
                    //check if Nmea message can be created
                    if (NmeaMessage.IsNmeaMessage(userInput))
                    {
                        nmea = NmeaMessage.FromString(userInput);
                        //check nmea checksum
                        if (NmeaCrcCalculator.CrcIsCorrect(nmea))
                        {
                            nmeaType = NmeaParser.Parse(nmea);
                            Display(nmeaType);
                            correctInput = true;
                        }
                        else
                            Console.WriteLine("Nmea checksum is incorrect. Try again..");
                    }
                    else
                        Console.WriteLine("Input is not Nmea message. Try again..");
                }




                Console.WriteLine("Click enter to continue.");
                correctInput = false;
                Console.ReadLine();
            }


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
