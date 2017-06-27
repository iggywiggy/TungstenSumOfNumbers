using NUnit.Framework;
using SumOfNumbers.Classes;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Tests.Commands
{
    [TestFixture]
    public class CommandFactoryTests
    {
        private ICommandFactory _commandFactory;

        [OneTimeSetUp]
        public void SetUp()
        {
            _commandFactory = new CommandFactory();
        }

        [Test]
        public void Resolve_Returns_Type_ICommandWithResultLong()
        {
            var command = _commandFactory.Resolve();

            Assert.IsInstanceOf<ICommandWithResult<long>>(command);
        }
    }
}