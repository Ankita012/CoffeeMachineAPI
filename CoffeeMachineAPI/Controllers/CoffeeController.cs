using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachineAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : ControllerBase
    {
        private static int brewCounter = 0;

        [HttpGet("brew-coffee")]
        public IActionResult BrewCoffee(DateTime? dateTime = null)
        {
            if (dateTime == null)
            {
                dateTime = DateTime.UtcNow;
            }

            if (dateTime.Value.Month == 4 && dateTime.Value.Day == 1)
            {
                return StatusCode(418, "I'm a teapot");
            }

            brewCounter++;
            if (brewCounter % 5 == 0)
            {
                return StatusCode(503, "Service Unavailable");
            }

            var response = new
            {
                message = "Your piping hot coffee is ready",
                prepared = dateTime.Value.ToString("yyyy-MM-ddTHH:mm:sszzz")
            };
            return Ok(response);
        }
    }
}
