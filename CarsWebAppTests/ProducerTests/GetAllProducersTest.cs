using CarsWebApp.DTOs;
using CarsWebApp.Models;
using CarsWebAppTests.Setup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarsWebAppTests.ProducerTests
{
    //[Collection("Qwerty")]
    public class GetAllProducersTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;
        public GetAllProducersTest(CustomWebApplicationFactory factory)
        {
            _client = factory.HttpClient;
        }
        protected async Task<ProducerDTO> CreateProducerAsync(ProducerCreateDTO dTO)
        {
            var response = await _client.PostAsJsonAsync("http://localhost:31365/api/producers/", dTO);
            return await response.Content.ReadFromJsonAsync<ProducerDTO>();
        }

        [Fact]
        public async Task GetAll_WithoutAnyProducers_ReturnEmptyOkResponse()
        {
            //Arrange
            //await AuthenticateAsync();
            //Act
            var response = await _client.GetAsync("http://localhost:44346/api/producers");
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var res = await response.Content.ReadFromJsonAsync<List<Producer>>();
            _ = res.Should().BeEmpty();

        }
    }
}
