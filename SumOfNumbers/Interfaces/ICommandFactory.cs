using SumOfNumbers.Infastructure.Common;

namespace SumOfNumbers.Interfaces
{
    public interface ICommandFactory
    {
        ICommand Resolve(CommandEnum commandEnum, object[] args = null);
    }
}