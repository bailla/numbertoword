using NumberToWordConverter.Exceptions;
using NumberToWordConverter.Parsers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Parsers
{
    [TestFixture]
    public class NumberParserTest
    {
        NumberParser _numberParserSUT;

        [SetUp]
        public void Setup()
        {
            _numberParserSUT = new NumberParser();
        }

        [Test]
        public void SimpleTest()
        {
            IList<long> result = _numberParserSUT.ParseInput("testing 123 testing");
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(123, result[0]);
        }

        [Test]
        public void SimpleTestMultiple()
        {
            IList<long> result = _numberParserSUT.ParseInput("89 testing 123 testing 567");
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(89, result[0]);
            Assert.AreEqual(123, result[1]);
            Assert.AreEqual(567, result[2]);
        }

        [Test]
        public void TestInvalidFront()
        {
            Assert.Throws(typeof(InvalidNumberException), () => _numberParserSUT.ParseInput("#89 at front"));
        }

        [Test]
        public void TestInvalidEnd()
        {
            Assert.Throws(typeof(InvalidNumberException), () => _numberParserSUT.ParseInput("at end 234w adf"));
        }

    }
}
