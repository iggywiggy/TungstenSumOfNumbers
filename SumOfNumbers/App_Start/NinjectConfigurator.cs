using System;
using log4net.Config;
using Ninject;
using SumOfNumbers.Classes.Commands;
using SumOfNumbers.Classes.Processors;
using SumOfNumbers.Infastructure.Logging;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            AddBindings(container);
        }

        private static void AddBindings(IKernel container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            ConfigureProcessors(container);
            ConfigureCommands(container);
            ConfigureLog4Net(container);
        }

        private static void ConfigureProcessors(IKernel container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            container.Bind<IAddProcessor>().To<AddProcessor>();
            container.Bind<IReadFileProcessor>().To<ReadFileProcessor>();
        }

        private static void ConfigureCommands(IKernel container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            container.Bind<ICommandFactory>().To<CommandFactory>();
            container.Bind<ICommandWithResult<long>>().To<AddCommand>().Named("AddCommand");
            container.Bind<ICommandWithResult<string>>().To<ReadLogFileCommand>().Named("ReadFileCommand");
        }

        private static void ConfigureLog4Net(IKernel container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            XmlConfigurator.Configure();

            var logManager = new LogManagerAdapter();
            container.Bind<ILogManager>().ToConstant(logManager);
        }
    }
}