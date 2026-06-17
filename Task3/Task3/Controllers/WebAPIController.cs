using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Task3.Controllers
{
    [Route("skorpalonekz_gmail_com")]
    [ApiController]
    public class WebAPIController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetLcm([FromQuery] string? x, [FromQuery] string? y)
        {
            if (!IsNaturalNumber(x) || !IsNaturalNumber(y))
            {
                return Content("NaN", "text/plain");
            }

            BigInteger a = BigInteger.Parse(x!);
            BigInteger b = BigInteger.Parse(y!);
            BigInteger result = Lcm(a, b);
            return Content(result.ToString(), "text/plain");
        }

        private static bool IsNaturalNumber(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            BigInteger number = BigInteger.Parse(value);
            return number > 0;
        }

        private static BigInteger Gcd(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private static BigInteger Lcm(BigInteger a, BigInteger b)
        {
            return a / Gcd(a, b) * b;
        }
    }
}