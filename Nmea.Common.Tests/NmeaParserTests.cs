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

    }
}
