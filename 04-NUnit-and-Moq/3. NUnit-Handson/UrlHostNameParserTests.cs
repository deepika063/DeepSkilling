using NUnit.Framework;
using UtilLib;
using System;

namespace UtilLib.Tests
{
    [TestFixture]
    public class UrlHostNameParserTests
    {
        private UrlHostNameParser parser;

        [SetUp]
        public void SetUp()
        {
            parser = new UrlHostNameParser();
        }

        [Test]
        public void ParseHostName_ValidHttpUrl_ReturnsHostName()
        {
            string actual = parser.ParseHostName("http://www.google.com/index.html");

            Assert.That(actual, Is.EqualTo("www.google.com"));
        }

        [Test]
        public void ParseHostName_ValidHttpsUrl_ReturnsHostName()
        {
            string actual = parser.ParseHostName("https://www.microsoft.com/home");

            Assert.That(actual, Is.EqualTo("www.microsoft.com"));
        }

        [Test]
        public void ParseHostName_InvalidProtocol_ThrowsFormatException()
        {
            var ex = Assert.Throws<FormatException>(() =>
                parser.ParseHostName("ftp://www.google.com"));

            Assert.That(ex.Message, Is.EqualTo("Url is not in correct format"));
        }
    }
}
