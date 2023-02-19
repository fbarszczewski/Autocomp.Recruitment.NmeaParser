using Autocomp.Nmea.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nmea.Common.Tests
{
    internal class NmeaCrcCalculatorTests
    {
        [Test]
        public void IsCorrect_WithoutSSignShouldReturnFalse()
        {
            //act
            bool actual = NmeaCrcCalculator.IsCorrect("GNGLL,3150.788156,N,11711.922383,E,062735.00,A,A*76");
            //assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void IsCorrect_WithoutStarSignShouldReturnFalse()
        {
            //act
            bool actual = NmeaCrcCalculator.IsCorrect("$GNGLL,3150.788156,N,11711.922383,E,062735.00,A,A76");
            //assert
            Assert.That(actual, Is.False);

        }
        [Test]
        public void IsCorrect_WithIncorrectCrcShouldReturnFalse()
        {
            //act
            bool actual = NmeaCrcCalculator.IsCorrect("$GNGLL,3150.788156,N,11711.922383,E,062735.00,A,A*0");
            //assert
            Assert.That(actual, Is.False);

        }

    }
}
