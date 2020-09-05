using FizzBuzzAPI.Core;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FizzBuzzApi.UnitTests
{
    public class FizzBuzzProcessorTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        public async Task Should_Throw_ArgumentException_When_Invalid_Figure_Is_Passed(int figure)
        {
            //Arrange
            var fizzBuzzProcessor = new FizzBuzzProcessor();

            //Act
            try
            {
                var act = await fizzBuzzProcessor.ProcessInputAsync(figure);
            }
            catch (Exception ex)
            {
                //Assert

                ex.Should().BeOfType(typeof(ArgumentException)).And.NotBeNull(ex.Message);
            }

        }

        [Theory]
        [InlineData(97)]
        [InlineData(38)]
        public async Task Should_Return_Figure_if_figure_not_multiple_of_3_or_5(int figure)
        {
            //Arrange
            var fizzBuzzProcessor = new FizzBuzzProcessor();

            //Act
            
                var act = await fizzBuzzProcessor.ProcessInputAsync(figure);
           
                //Assert

               act.Should().Be(figure.ToString());
            

        }


        [Theory]
        [InlineData(33)]
        [InlineData(63)]
        public async Task Should_Return_Fizz_if_figure_is_multiple_of_3(int figure)
        {
            //Arrange
            var fizzBuzzProcessor = new FizzBuzzProcessor();

            //Act
            
                var act = await fizzBuzzProcessor.ProcessInputAsync(figure);

            //Assert

            act.Should().BeOfType(typeof(string)).And.Contain("Fizz").And.HaveLength(4);
            

        }


        [Theory]
        [InlineData(20)]
        [InlineData(40)]
        public async Task Should_Return_Fizz_if_figure_is_multiple_of_5(int figure)
        {
            //Arrange
            var fizzBuzzProcessor = new FizzBuzzProcessor();

            //Act

            var act = await fizzBuzzProcessor.ProcessInputAsync(figure);

            //Assert

            act.Should().BeOfType(typeof(string)).And.Contain("Buzz").And.HaveLength(4);


        }


        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        public async Task Should_Return_Fizz_if_figure_is_multiple_of_3_and_5(int figure)
        {
            //Arrange
            var fizzBuzzProcessor = new FizzBuzzProcessor();

            //Act

            var act = await fizzBuzzProcessor.ProcessInputAsync(figure);

            //Assert

            act.Should().BeOfType(typeof(string)).And.Contain("FizzBuzz").And.HaveLength(8);


        }
    }
}
