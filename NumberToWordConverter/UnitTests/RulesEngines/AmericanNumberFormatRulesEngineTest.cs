using NumberToWordConverter.RulesEngines;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.RulesEngines
{
    [TestFixture]
    public class AmericanNumberFormatRulesEngineTest
    {
        AmericanNumberFormatRulesEngine _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new AmericanNumberFormatRulesEngine();
        }

        [Test]
        public void WhenRootNumbers()
        {
            Assert.AreEqual("one", _sut.ProcessItem(1));
            Assert.AreEqual("two", _sut.ProcessItem(2));
            Assert.AreEqual("three", _sut.ProcessItem(3));
            Assert.AreEqual("four", _sut.ProcessItem(4));
            Assert.AreEqual("five", _sut.ProcessItem(5));
            Assert.AreEqual("six", _sut.ProcessItem(6));
            Assert.AreEqual("seven", _sut.ProcessItem(7));
            Assert.AreEqual("eight", _sut.ProcessItem(8));
            Assert.AreEqual("nine", _sut.ProcessItem(9));
            Assert.AreEqual("ten", _sut.ProcessItem(10));
            Assert.AreEqual("eleven", _sut.ProcessItem(11));
            Assert.AreEqual("twelve", _sut.ProcessItem(12));
            Assert.AreEqual("thirteen", _sut.ProcessItem(13));
            Assert.AreEqual("fourteen", _sut.ProcessItem(14));
            Assert.AreEqual("fifteen", _sut.ProcessItem(15));
            Assert.AreEqual("sixteen", _sut.ProcessItem(16));
            Assert.AreEqual("seventeen", _sut.ProcessItem(17));
            Assert.AreEqual("eighteen", _sut.ProcessItem(18));
            Assert.AreEqual("nineteen", _sut.ProcessItem(19));
        }

        [Test]
        public void WhenTees()
        {
            Assert.AreEqual("twenty", _sut.ProcessItem(20));
            Assert.AreEqual("thirty", _sut.ProcessItem(30));
            Assert.AreEqual("forty", _sut.ProcessItem(40));
            Assert.AreEqual("fifty", _sut.ProcessItem(50));
            Assert.AreEqual("sixty", _sut.ProcessItem(60));
            Assert.AreEqual("seventy", _sut.ProcessItem(70));
            Assert.AreEqual("eighty", _sut.ProcessItem(80));
            Assert.AreEqual("ninety", _sut.ProcessItem(90));
        }

        [Test]
        public void WhenMidTees()
        {
            Assert.AreEqual("twenty-one", _sut.ProcessItem(21));
            Assert.AreEqual("thirty-two", _sut.ProcessItem(32));
            Assert.AreEqual("forty-three", _sut.ProcessItem(43));
            Assert.AreEqual("fifty-four", _sut.ProcessItem(54));
            Assert.AreEqual("sixty-five", _sut.ProcessItem(65));
            Assert.AreEqual("seventy-six", _sut.ProcessItem(76));
            Assert.AreEqual("eighty-seven", _sut.ProcessItem(87));
            Assert.AreEqual("ninety-eight", _sut.ProcessItem(98));
        }

        [Test]
        public void WhenHundreds()
        {
            Assert.AreEqual("one hundred", _sut.ProcessItem(100));
            Assert.AreEqual("five hundred", _sut.ProcessItem(500));
            Assert.AreEqual("nine hundred", _sut.ProcessItem(900));
        }

        [Test]
        public void WhenMidHundreds()
        {
            Assert.AreEqual("two hundred and eight", _sut.ProcessItem(208));
            Assert.AreEqual("four hundred and fifty", _sut.ProcessItem(450));
            Assert.AreEqual("five hundred and thirty-six", _sut.ProcessItem(536));
            Assert.AreEqual("six hundred and ninety-nine", _sut.ProcessItem(699));
        }

        [Test]
        public void WhenThousands()
        {
            Assert.AreEqual("one thousand", _sut.ProcessItem(1000));
            Assert.AreEqual("fifteen thousand", _sut.ProcessItem(15000));
            Assert.AreEqual("two hundred thousand", _sut.ProcessItem(200000));
        }

        [Test]
        public void WhenMidThousands()
        {
            Assert.AreEqual("nine thousand, one hundred and twenty-one", _sut.ProcessItem(9121));
            Assert.AreEqual("ten thousand and twenty-two", _sut.ProcessItem(10022));
        }

        [Test]
        public void WhenMillions()
        {
            Assert.AreEqual("one million", _sut.ProcessItem(1000000));
            Assert.AreEqual("seven hundred and twenty-three million", _sut.ProcessItem(723000000));
        }

        [Test]
        public void WhenMidMillions()
        {
            Assert.AreEqual("one million, nine thousand, one hundred and twenty-one", _sut.ProcessItem(1009121));
            Assert.AreEqual("seven hundred and twenty-three million, ten thousand and twenty-two", _sut.ProcessItem(723010022));
        }

        [Test]
        public void WhenBillions()
        {
            Assert.AreEqual("sixty-six billion", _sut.ProcessItem(66000000000));
        }

        [Test]
        public void WhenBillionsMid()
        {
            Assert.AreEqual("sixty-six billion, seven hundred and twenty-three million, one hundred and seven thousand and eight", _sut.ProcessItem(66723107008));
        }
    }
}
