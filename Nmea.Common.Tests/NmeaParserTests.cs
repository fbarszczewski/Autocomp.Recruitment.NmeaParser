using Autocomp.Nmea.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nmea.Common.Tests
{
    internal class NmeaParserTests
    {
        [Test]
        public void StringToLongitude_ShouldReturnCorrectValue()
        {
            //Arrange
            double expected = -105.11255315;

            //Act
            double actual = NmeaParser.StringToLongitude("10506.75318910", "W");

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void StringToLatitude_ShouldReturnCorrectValue()
        {
            //Arrange
            double expected = 39.8980015;

            //Act
            double actual = NmeaParser.StringToLatitude("3953.88008971", "N");

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void StringToTimespan_ShouldReturnCorrectValue()
        {
            //Arrange
            TimeSpan expected = new TimeSpan(3,41,38);

            //Act
            TimeSpan actual = NmeaParser.StringToTimeSpan("034138.00");

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void StringToDouble_ShouldReturnCorrectValue()
        {
            //Arrange
            double expected = 319.289;

            //Act
            double actual = NmeaParser.StringToDouble("319,289");

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
