using System;
using System.Web.Configuration;
using System.Web.Http;
using log4net;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Controllers
{
    public class LoggerController : ApiController
    {
        private readonly ICommandWithResult<string> _command;
        private readonly ILog _log;

        public LoggerController(ICommandWithResult<string> command, ILogManager logManager)
        {
            _command = command ?? throw new ArgumentNullException(nameof(command));
            _log = logManager?.GetLog(typeof(LoggerController)) ??
                   throw new ArgumentNullException(nameof(logManager));
        }

        [HttpGet]
        public IHttpActionResult GetLogFileContents()
        {
            _command.Execute(new object[] {WebConfigurationManager.AppSettings["LogFile"]});

            _log.Info(
                $"DateTime: {DateTime.Now}, Accessed Logging Controller");

            return Ok(_command.Result);
        }
    }
}