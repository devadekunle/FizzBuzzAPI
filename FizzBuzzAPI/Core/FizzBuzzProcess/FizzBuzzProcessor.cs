using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzAPI.Core
{
    public class FizzBuzzProcessor : IFizzBuzzProcessor
    {
       
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";


        public string ProcessInput(int figure)
        {
            Validate(figure);
            if (figure % 3 == 0 && figure % 5 == 0)
                return string.Concat(Fizz, Buzz);

           

            if (figure % 3 == 0)
                return Fizz;

            if (figure % 5 == 0)
                return Buzz;

            return figure.ToString();

            

            

        }
        private void Validate(int figure)
        {
            if (figure < 1 || figure > 100)
                throw new ArgumentException("Input must range from 1 to 100...Jazz Up!");
        }

        public Task<string> ProcessInputAsync(int figure)
        {
            return Task.Run(() => ProcessInput(figure));
        }
    }
}
