namespace SumOfNumbers.Interfaces
{
    public interface ICommandFactory
    {
        ICommand Resolve(object[] args = null);
    }
}