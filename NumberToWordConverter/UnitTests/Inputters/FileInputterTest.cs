using NumberToWordConverter.Exceptions;
using NumberToWordConverter.Inputters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Inputters
{
    [TestFixture]
    public class FileInputterTest
    {
        [Test]
        public void OpenAndReadFileTest()
        {
            FileInputter fileInputterSUT = new FileInputter(@".\InputTest1.txt");
            Assert.AreEqual("testing 123 testing", fileInputterSUT.Get());
        }

        [Test]
        public void MissingFileException()
        {
            FileInputter fileInputterSUT = new FileInputter(@".\NonExistantFile.txt");
            Assert.Throws(typeof(MissingFileException), () => fileInputterSUT.Get());
        }
    }
}
