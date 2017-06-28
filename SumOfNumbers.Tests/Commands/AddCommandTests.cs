using Moq;
using NUnit.Framework;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Tests.Commands
{
    [TestFixture]
    public class AddCommandTests
    {
        private Mock<IAddProcessor> _mockAddProcessor;

        [OneTimeSetUp]
        public void Setup()
        {
            _mockAddProcessor = new Mock<IAddProcessor>();
        }

        [TestCase(1, 1, 2, ExpectedResult = 2)]
        [TestCase(10, 10, 20, ExpectedResult = 20)]
        [TestCase(-1, -1, 1, ExpectedResult = 1)]
        public long Execute_Returns_Correct_Result(int integerOne, int integerTwo, int integerThree)
        {
            _mockAddProcessor.Setup(mock => mock.Add(integerOne, integerTwo)).Returns(integerThree);

            return _mockAddProcessor.Object.Add(integerOne, integerTwo);
        }
    }
}