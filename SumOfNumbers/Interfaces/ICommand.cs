namespace SumOfNumbers.Interfaces
{
    public interface ICommand
    {
        void Execute(object[] args = null);
    }
}