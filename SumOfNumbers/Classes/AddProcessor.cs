using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Classes
{
    public class AddProcessor : IAddProcessor
    {
        public long Add(long integerOne, long integerTwo)
        {
            return integerOne + integerTwo;
        }
    }
}