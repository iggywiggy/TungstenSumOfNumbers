using NUnit.Framework;

namespace SumOfNumbers.Tests.Processors
{
    [TestFixture]
    public class AddProcessorTests
    {
        [TestCase(1, 1, ExpectedResult = 2)]
        [TestCase(10, 10, ExpectedResult = 20)]
        [TestCase(200, 200, ExpectedResult = 400)]
        public long AddTwoIntegers(long integerOne, long integerTwo)
        {
            return 0;
        }
    }
}