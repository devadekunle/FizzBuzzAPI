using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzzAPI.Core;
using FizzBuzzAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FizzBuzzAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzzProcessor _fizzBuzzProcessor;
        public FizzBuzzController(IFizzBuzzProcessor fizzBuzzProcessor)
        {
            _fizzBuzzProcessor = fizzBuzzProcessor;
        }
        /// <summary>
        /// Enter a number between 1 and 100
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        // GET api/<FizzBuzzControlelr>/5
        [HttpGet("{number}")]
        public async Task<IActionResult> Get(int number)
        {
            var result = await _fizzBuzzProcessor.ProcessInputAsync(number);
            return Ok(new ApiResponse<string>(result, StatusCodes.Status200OK));
           
        }

       
    }
}
