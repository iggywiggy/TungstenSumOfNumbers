using System;
using Moq;
using NUnit.Framework;
using SumOfNumbers.Classes.Commands;
using SumOfNumbers.Infastructure.Common;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Tests.Commands
{
    [TestFixture]
    public class CommandFactoryTests
    {
        private Mock<ICommandFactory> _mockCommandFactory;
        private Mock<IAddProcessor> _mockAddProcessor;
        private Mock<IReadFileProcessor> _readFileProcessor;
        private ICommandWithResult<long> _addcommand;
        private ICommandWithResult<string> _readLogFileCommand;
        private ICommandFactory _commandFactory;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _mockCommandFactory = new Mock<ICommandFactory>();
            _mockAddProcessor = new Mock<IAddProcessor>();
            _readFileProcessor = new Mock<IReadFileProcessor>();

            _addcommand = new AddCommand(_mockAddProcessor.Object);
            _readLogFileCommand = new ReadLogFileCommand(_readFileProcessor.Object);

            _mockCommandFactory.Setup(mock => mock.Resolve(CommandEnum.Add, new object[] {"1", "1"}))
                .Returns(_addcommand);

            _mockCommandFactory.Setup(mock => mock.Resolve(CommandEnum.ReadLogFile, new object[] {"FilePath"}))
                .Returns(_readLogFileCommand);

            _commandFactory = new CommandFactory();
        }

        [TestCase(CommandEnum.Add, new object[] {"1", "1"}, ExpectedResult = typeof(AddCommand))]
        [TestCase(CommandEnum.ReadLogFile, new object[] {"FilePath"}, ExpectedResult = typeof(ReadLogFileCommand))]
        public Type ResolveCommand_Command_Enum_CorrectCommand_Returned(CommandEnum commandEnum, object[] args)
        {
            return _mockCommandFactory.Object.Resolve(commandEnum, args).GetType();
        }

        [Test]
        public void ResolveCommand_Command_Enum_Returns_Type_Of_ICommand()
        {
            var command = _mockCommandFactory.Object.Resolve(CommandEnum.Add, new object[] {"1", "1"});

            Assert.IsInstanceOf(typeof(ICommand), command);
        }

        [Test]
        public void ResolveCommand_CommandEnum_OfType_Add_Returns_Type_Of_ICommandWithResult_Long()
        {
            var command = _mockCommandFactory.Object.Resolve(CommandEnum.Add, new object[] {"1", "1"});

            Assert.IsInstanceOf(typeof(ICommandWithResult<long>), command);
        }

        [Test]
        public void ResolveCommand_CommandEnum_OfType_ReadLogFile_Returns_Type_Of_ICommandWithResult_String()
        {
            var command = _mockCommandFactory.Object.Resolve(CommandEnum.ReadLogFile, new object[] {"FilePath"});

            Assert.IsInstanceOf(typeof(ICommandWithResult<string>), command);
        }
    }
}