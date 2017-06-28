using System;
using System.Collections.Generic;
using System.ComponentModel;
using SumOfNumbers.Infastructure.Common;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Classes.Commands
{
    public class CommandFactory : ICommandFactory
    {
        private IDictionary<CommandEnum, Type> _commandsDictionary;

        public CommandFactory()
        {
            RegisterCommands();
        }

        public ICommand Resolve(CommandEnum commandEnum, object[] args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            if (!Enum.IsDefined(typeof(CommandEnum), commandEnum))
                throw new InvalidEnumArgumentException(nameof(commandEnum), (int) commandEnum, typeof(CommandEnum));

            var commandType = _commandsDictionary[commandEnum];

            return WebContainerManager.Get<ICommand>(commandType.Name);
        }

        private void RegisterCommands()
        {
            _commandsDictionary = new Dictionary<CommandEnum, Type>
            {
                {
                    CommandEnum.Add, typeof(AddCommand)
                },
                {
                    CommandEnum.ReadLogFile, typeof(ReadLogFileCommand)
                }
            };
        }
    }
}