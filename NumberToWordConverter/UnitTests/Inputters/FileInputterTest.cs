using Moq;
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
            Mock<IInputterDialogue<string>> inputterDialogue = new Mock<IInputterDialogue<string>>();
            inputterDialogue.Setup(x => x.Dialogue()).Returns(@".\InputTest1.txt");
            FileInputter fileInputterSUT = new FileInputter(inputterDialogue.Object);
            Assert.AreEqual("testing 123 testing", fileInputterSUT.Get());
        }

        [Test]
        public void MissingFileException()
        {
            Mock<IInputterDialogue<string>> inputterDialogue = new Mock<IInputterDialogue<string>>();
            inputterDialogue.Setup(x => x.Dialogue()).Returns(@".\NonExistantFile.txt");
            FileInputter fileInputterSUT = new FileInputter(inputterDialogue.Object);
            Assert.Throws(typeof(MissingFileException), () => fileInputterSUT.Get());
        }
    }
}
