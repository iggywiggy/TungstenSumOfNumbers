using System;
using NUnit.Framework;
using SumOfNumbers.Classes.Commands;
using SumOfNumbers.Classes.Processors;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Tests.Commands
{
    [TestFixture]
    public class ReadLogFileCommandTests
    {
        private ICommandWithResult<string> _readFileLog;
        private IReadFileProcessor _readFileProcessor;

        [OneTimeSetUp]
        public void Setup()
        {
            _readFileProcessor = new ReadFileProcessor();
            _readFileLog = new ReadLogFileCommand(_readFileProcessor);
        }

        [Test]
        public void Constructor_Null_ReadFileProcessor_Parameter_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ReadLogFileCommand(null));
        }

        [Test]
        public void Execute_EmptyString_In_Args_Parameter_Throws_ArgumentNullException()
        {
            Assert.IsInstanceOf<ICommandWithResult<string>>(new ReadLogFileCommand(_readFileProcessor));
        }

        [Test]
        public void Execute_Null_Args_Parameter()
        {
            Assert.Throws<ArgumentNullException>(() => new ReadLogFileCommand(_readFileProcessor).Execute(null));
        }

        [Test]
        public void ReadFileProcess_Is_Of_Type_ICommand()
        {
            Assert.IsInstanceOf<ICommand>(new ReadLogFileCommand(_readFileProcessor));
        }

        [Test]
        public void ReadFileProcess_Is_Of_Type_ICommandWithResult_String()
        {
            var args = new object[] {""};
            Assert.Throws<ArgumentNullException>(() => _readFileLog.Execute(args));
        }
    }
}