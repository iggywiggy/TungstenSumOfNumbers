using NUnit.Framework;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Tests.Processors
{
    [TestFixture]
    public class AddProcessorTests
    {
        private IAddProcessor _addProcessor;

        [OneTimeSetUp]
        public void SetUp()
        {
            _addProcessor = new AddProcess();
        }

        [TestCase(1, 1, ExpectedResult = 2)]
        [TestCase(10, 10, ExpectedResult = 20)]
        [TestCase(200, 200, ExpectedResult = 400)]
        public long AddTwoIntegers(long integerOne, long integerTwo)
        {
            return _addProcessor.Add(integerOne, integerTwo);
        }
    }

    public class AddProcess : IAddProcessor
    {
        public long Add(long integerOne, long integerTwo)
        {
            return integerOne + integerTwo;
        }
    }
}