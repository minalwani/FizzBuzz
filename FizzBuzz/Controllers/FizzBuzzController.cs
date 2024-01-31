using Microsoft.AspNetCore.Mvc;
using FizzBuzz.BusinessLogic;
using FizzBuzz.Interfaces;
using System.Linq;

namespace FizzBuzz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FizzBuzzController : ControllerBase
    {
       
        public readonly IFizzBuzz _iFizzBuzz;
        public readonly IConfiguration _iConfiguration;

        public FizzBuzzController(IFizzBuzz iFizzBuzz, IConfiguration iConfiguration)
        {
            _iFizzBuzz = iFizzBuzz;
            _iConfiguration = iConfiguration;

        }

        [HttpPost]
        public List<string> GetFizzBuzzResults([FromBody] List<string> value)
        {
            var divValues  = _iConfiguration["DivisibleValues"]!.Split(',').Where(n => !String.IsNullOrWhiteSpace(n))               
                .Select(n => int.Parse(n.Trim()))
                .ToList();
            return _iFizzBuzz.GetFizzBuzzList(value,divValues);
        }
    }
}
