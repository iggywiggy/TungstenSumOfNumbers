using System;
using System.Web.Http.ExceptionHandling;
using log4net;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Infastructure.Logging
{
    public class ExceptionLogger : System.Web.Http.ExceptionHandling.ExceptionLogger
    {
        private readonly ILog _log;

        public ExceptionLogger(ILogManager logManager)
        {
            _log = logManager?.GetLog(typeof(ExceptionLogger)) ?? throw new ArgumentNullException(nameof(logManager));
        }

        public override void Log(ExceptionLoggerContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _log.Error("Unhandle exception", context.Exception);
        }
    }
}