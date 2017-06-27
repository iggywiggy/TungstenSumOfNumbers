using System.Web.Http;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Controllers
{
    public class CalculatorController : ApiController
    {
        private readonly IAddProcessor _addProcessor;

        public CalculatorController(IAddProcessor addProcessor)
        {
            _addProcessor = addProcessor;
        }

        [HttpPost]
        public IHttpActionResult AddTwoNumbers(string integerOne, string integerTwo)
        {
            return Ok(_addProcessor.Add(long.Parse(integerOne), long.Parse(integerTwo)));
        }
    }
}