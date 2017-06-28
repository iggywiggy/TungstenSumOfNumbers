using System;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using log4net;
using SumOfNumbers.Infastructure;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Controllers
{
    public class CalculatorController : ApiController
    {
        private readonly ICommandWithResult<long> _command;
        private readonly ILog _log;

        public CalculatorController(ICommandWithResult<long> commander, ILogManager logManager)
        {
            _command = commander ?? throw new ArgumentNullException(nameof(commander));
            _log = logManager?.GetLog(typeof(CalculatorController)) ??
                   throw new ArgumentNullException(nameof(logManager));
        }

        [HttpPost]
        public IHttpActionResult AddTwoNumbers([ModelBinder(typeof(StringParameterBinder))] string integerOne,
            [ModelBinder(typeof(StringParameterBinder))] string integerTwo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Utils.ConvertStringToInt(integerOne, out long valueOne);
            Utils.ConvertStringToInt(integerTwo, out long valueTwo);

            _command.Execute(new object[] {valueOne, valueTwo});

            _log.Info(
                $"DateTime: {DateTime.Now}, ValueOne: {valueOne}, ValueTwo: {valueTwo}, Result: {_command.Result}");

            return Ok(_command.Result);
        }
    }
}