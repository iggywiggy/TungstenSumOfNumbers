using System.Web.Http;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Controllers
{
    public class CalculatorController : ApiController
    {
        private readonly ICommandWithResult<long> _command;

        public CalculatorController(ICommandWithResult<long> command)
        {
            _command = command;
        }

        [HttpPost]
        public IHttpActionResult AddTwoNumbers(string integerOne, string integerTwo)
        {
            _command.Execute(new object[] {integerOne, integerTwo});

            return Ok(_command.Result);
        }
    }
}