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
    public class GetProducerTests /*: IClassFixture<CustomWebApplicationFactory>*/
    {
        private readonly HttpClient _client;
        public GetProducerTests(CustomWebApplicationFactory factory) 
        {
            _client = factory.HttpClient;
        }
        protected async Task<ProducerDTO> CreateProducerAsync(ProducerCreateDTO dTO)
        {
            var response = await _client.PostAsJsonAsync("http://localhost:31365/api/producers/", dTO);
            return await response.Content.ReadFromJsonAsync<ProducerDTO>();
        }

        [Fact]
        public async Task Get_ReturnsProducer_WhenProducerExistsInTheDatabase()
        {
            //Arrange
            //await AuthenticateAsync();
            var createdProducer = await CreateProducerAsync(new ProducerCreateDTO
            {
                Info = "mytestInfo",
                Label = "mytestLabel",
                Name = "qww"
            });

            //Act
            var response = await _client.GetAsync($"http://localhost:31365/api/producers/{createdProducer.Id}");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnedProducer = await response.Content.ReadFromJsonAsync<Producer>();
            returnedProducer.Id.Should().Be(createdProducer.Id);
            returnedProducer.Name.Should().Be(createdProducer.Name);
            returnedProducer.Label.Should().Be(createdProducer.Label);
            returnedProducer.Info.Should().Be(createdProducer.Info);
        }

        //[Fact]
        //public async Task GetAll_WithoutAnyProducers_ReturnEmptyOkResponse()
        //{
        //    //Arrange
        //    //await AuthenticateAsync();
        //    //Act
        //    var response = await _client.GetAsync("http://localhost:44346/api/producers");
        //    //Assert
        //    response.StatusCode.Should().Be(HttpStatusCode.OK);
        //    var res = await response.Content.ReadFromJsonAsync<List<Producer>>();
        //    _ = res.Should().BeEmpty();

        //}
    }
}
