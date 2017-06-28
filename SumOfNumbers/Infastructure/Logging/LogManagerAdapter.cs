using System;
using log4net;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Infastructure.Logging
{
    public class LogManagerAdapter : ILogManager
    {
        public ILog GetLog(Type typeAssociatedWithRequestedLog)
        {
            if (typeAssociatedWithRequestedLog == null)
                throw new ArgumentNullException(nameof(typeAssociatedWithRequestedLog));

            return LogManager.GetLogger(typeAssociatedWithRequestedLog);
        }
    }
}