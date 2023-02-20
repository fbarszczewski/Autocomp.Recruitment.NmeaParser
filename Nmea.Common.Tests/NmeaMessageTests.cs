using Autocomp.Nmea.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nmea.Common.Tests
{
    internal class NmeaMessageTests
    {
        [Test]
        public void FromString_ShouldReturnCorrectChecksumValue()
        {
            //Arrange
            string expected = "7A";
            //Act
            string actual = NmeaMessage.FromString("$GPGLL,3953.88008971,N,10506.75318910,W,034138.00,A,D*7A").Checksum;

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void FromString_ShouldReturnCorrectFieldsValue()
        {
            //Arrange
            string[] expected = new string[] { "3953.88008971", "N", "10506.75318910", "W", "034138.00", "A", "D" };
            //Act
            string[] actual = NmeaMessage.FromString("$GPGLL,3953.88008971,N,10506.75318910,W,034138.00,A,D*7A").Fields;

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void FromString_ShouldReturnCorrectHeaderValue()
        {
            //Arrange
            string expected = "GPGLL";
            //Act
            string actual = NmeaMessage.FromString("$GPGLL,3953.88008971,N,10506.75318910,W,034138.00,A,D*7A").Header;

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void IsNmeaMessage_ShouldReturnTrueWhenCorrectString()
        {
            //Arrange
            bool expected = true;
            //Act
            bool actual = NmeaMessage.IsNmeaMessage("$GPGLL,3953.88008971,N,10506.75318910,W,034138.00,A,D*7A");

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void IsNmeaMessage_ShouldReturnFalseWhenOneSignMissing()
        {
            //Arrange
            bool expected = false;
            //Act
            bool actual = NmeaMessage.IsNmeaMessage("GPGLL,3953.88008971,N,10506.75318910,W,034138.00,A,D*7A");

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void IsNmeaMessage_ShouldReturnFalseWhenEmpty()
        {
            //Arrange
            bool expected = false;
            //Act
            bool actual = NmeaMessage.IsNmeaMessage("");

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
