using System;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Classes
{
    public class AddCommand : ICommandWithResult<long>
    {
        private readonly IAddProcessor _addProcessor;

        public AddCommand(IAddProcessor addProcessor)
        {
            _addProcessor = addProcessor;
        }

        public void Execute(object[] args = null)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var result = _addProcessor.Add(long.Parse(args[0].ToString()), long.Parse(args[1].ToString()));

            Result = result;
        }

        public long Result { get; private set; }
    }
}