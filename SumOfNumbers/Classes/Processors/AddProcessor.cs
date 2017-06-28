using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Classes.Processors
{
    public class AddProcessor : IAddProcessor
    {
        public long Add(long integerOne, long integerTwo)
        {
            return integerOne + integerTwo;
        }
    }
}