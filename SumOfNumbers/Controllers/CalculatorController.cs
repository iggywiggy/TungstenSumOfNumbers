using System.Web.Http;
using System.Web.Http.ModelBinding;
using SumOfNumbers.Infastructure;
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
        public IHttpActionResult AddTwoNumbers([ModelBinder(typeof(StringParameterBinder))] string integerOne,
            [ModelBinder(typeof(StringParameterBinder))] string integerTwo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _command.Execute(new object[] {integerOne, integerTwo});

            return Ok(_command.Result);
        }
    }
}