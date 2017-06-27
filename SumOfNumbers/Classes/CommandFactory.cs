using System;
using System.Collections.Generic;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Classes
{
    public class CommandFactory : ICommandFactory
    {
        private IDictionary<string, Type> _commandsDictionary;

        public CommandFactory()
        {
            RegisterTypes();
        }


        public ICommand Resolve(object[] args = null)
        {
            var commandType = _commandsDictionary["Add"];

            return WebContainerManager.Get<ICommand>(commandType.Name);
        }

        private void RegisterTypes()
        {
            _commandsDictionary = new Dictionary<string, Type>
            {
                {
                    "Add", typeof(AddCommand)
                }
            };
        }
    }
}