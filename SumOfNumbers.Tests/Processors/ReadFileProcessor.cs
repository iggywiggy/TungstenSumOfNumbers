using System;
using NUnit.Framework;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Tests.Processors
{
    [TestFixture]
    public class ReadFileProcessor
    {
        private IReadFileProcessor _readFileProcessor;

        [OneTimeSetUp]
        public void Setup()
        {
            _readFileProcessor = new Classes.Processors.ReadFileProcessor();
        }


        [Test]
        public void Read_EmptyString_Path_Parameter()
        {
            Assert.Throws<ArgumentNullException>(() => _readFileProcessor.Read(""));
        }

        [Test]
        public void Read_Null_Path_Parameter()
        {
            Assert.Throws<ArgumentNullException>(() => _readFileProcessor.Read(null));
        }

        [Test]
        public void Read_Return_EmptyString_File_DoesntExist()
        {
            Assert.That(() => _readFileProcessor.Read("file") == string.Empty);
        }

        [Test]
        public void ReadFileProcessor_IsInstance_Of_IReadFileProcessor()
        {
            Assert.IsInstanceOf<IReadFileProcessor>(_readFileProcessor);
        }
    }
}