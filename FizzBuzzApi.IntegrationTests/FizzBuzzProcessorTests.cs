using FizzBuzzAPI.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Security.Policy;
using System.Threading.Tasks;
using Xunit;

namespace FizzBuzzApi.IntegrationTests
{
    public class FizzBuzzProcessorTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(300)]
        public async Task Should_Return_400_if_Invalid_Arguments(int figure)
        {
            //arrange

            var client = new TestContext().Client;

            //act
            
            var response = await client.GetAsync($"/api/v1/FizzBuzz/{figure}");
           
            response.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

        }
        [Theory]
        [InlineData(97)]
        [InlineData(38)]
        public async Task Should_Return_Figure_if_figure_not_multiple_of_3_or_5(int figure)
        {
            //Arrange
            var client = new TestContext().Client;


            //Act

            var response = await client.GetAsync($"/api/v1/FizzBuzz/{figure}");

            //Assert
            var act = JsonConvert.DeserializeObject<ApiResponse<string>>(response.Content.ReadAsStringAsync().Result);

            act.Data.Should().Be(figure.ToString());


        }


        [Theory]
        [InlineData(33)]
        [InlineData(63)]
        public async Task Should_Return_Fizz_if_figure_is_multiple_of_3(int figure)
        {
            //Arrange
            var client = new TestContext().Client;

            //Act

            var response = await client.GetAsync($"/api/v1/FizzBuzz/{figure}");

            //Assert
            var act = JsonConvert.DeserializeObject<ApiResponse<string>>(response.Content.ReadAsStringAsync().Result);

            //Assert

            act.Data.Should().BeOfType(typeof(string)).And.Contain("Fizz").And.HaveLength(4);


        }


        [Theory]
        [InlineData(20)]
        [InlineData(40)]
        public async Task Should_Return_Fizz_if_figure_is_multiple_of_5(int figure)
        {
            //Arrange
            var client = new TestContext().Client;

            //Act

            var response = await client.GetAsync($"/api/v1/FizzBuzz/{figure}");

            //Assert
            var act = JsonConvert.DeserializeObject<ApiResponse<string>>(response.Content.ReadAsStringAsync().Result);

            //Assert

            act.Data.Should().BeOfType(typeof(string)).And.Contain("Buzz").And.HaveLength(4);


        }


        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        public async Task Should_Return_Fizz_if_figure_is_multiple_of_3_and_5(int figure)
        {
            //Arrange
            var client = new TestContext().Client;

            //Act

            var response = await client.GetAsync($"/api/v1/FizzBuzz/{figure}");

            //Assert
            var act = JsonConvert.DeserializeObject<ApiResponse<string>>(response.Content.ReadAsStringAsync().Result);

            //Assert

            act.Data.Should().BeOfType(typeof(string)).And.Contain("FizzBuzz").And.HaveLength(8);


        }
    }
}
