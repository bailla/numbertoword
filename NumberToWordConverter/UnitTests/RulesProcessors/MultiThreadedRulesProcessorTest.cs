using Moq;
using NumberToWordConverter.RulesEngines;
using NumberToWordConverter.RulesProcessor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.RulesProcessors
{
    [TestFixture]
    public class MultiThreadedRulesProcessorTest
    {
        [Test]
        public void RunSomeRulesTest()
        {
            Mock<IRulesEngine<long, string>> rulesEngineMock = new Mock<IRulesEngine<long, string>>();
            rulesEngineMock.Setup(x => x.ProcessItem(1234)).Returns("one-hundred and twenty three");
            rulesEngineMock.Setup(x => x.ProcessItem(567)).Returns("five-hundred and sixty-seven");
            rulesEngineMock.Setup(x => x.ProcessItem(89)).Returns("eighty-nine");

            MultiThreadedRulesProcessor<long, string> sut = new MultiThreadedRulesProcessor<long, string>();

            IList<long> items = new List<long>()
            {
                1234,
                567,
                89
            };

            IList<string> results = sut.Process(items, rulesEngineMock.Object);
            Assert.AreEqual(3, results.Count);
            Assert.AreEqual("one-hundred and twenty three", results[0]);
            Assert.AreEqual("five-hundred and sixty-seven", results[1]);
            Assert.AreEqual("eighty-nine", results[2]);
        }
    }
}
