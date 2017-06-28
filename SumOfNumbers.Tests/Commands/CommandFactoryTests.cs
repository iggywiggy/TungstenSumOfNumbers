using Moq;
using NUnit.Framework;
using SumOfNumbers.Classes;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Tests.Commands
{
    [TestFixture]
    public class CommandFactoryTests
    {
        private Mock<ICommandFactory> _mockCommandFactory;
        private Mock<IAddProcessor> _mockAddProcessor;
        private ICommandWithResult<long> _addCommand;

        [OneTimeSetUp]
        public void SetUp()
        {
            _mockCommandFactory = new Mock<ICommandFactory>();
            _mockAddProcessor = new Mock<IAddProcessor>();
            _addCommand = new AddCommand(_mockAddProcessor.Object);


            _mockCommandFactory.Setup(mock => mock.Resolve(new object[] {"1", "1"})).Returns(_addCommand);
        }

        [Test]
        public void Resolve_Returns_Type_ICommand()
        {
            var command = _mockCommandFactory.Object.Resolve(new object[] {"1", "1"});

            Assert.IsInstanceOf<ICommandWithResult<long>>(command);
        }

        [Test]
        public void Resolve_Returns_Type_ICommandWithResultLong()
        {
            var command = _mockCommandFactory.Object.Resolve(new object[] {"1", "1"});

            Assert.IsInstanceOf<ICommand>(command);
        }
    }
}