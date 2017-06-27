namespace SumOfNumbers.Interfaces
{
    public interface ICommandWithResult<out T> : ICommand
    {
        T Result { get; }
    }
}