using CarsWebApp;
using CarsWebApp.DTOs;
using CarsWebApp.Models;
using CarsWebAppTests.Setup;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
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
    [Collection("Qwerty")]
    public class ProducerControllerIntegrationTests
    {
        private HttpClient _client;
        public ProducerControllerIntegrationTests(CustomWebApplicationFactory factory) 
        {
            _client = factory.HttpClient;
        }
        protected async Task<ProducerDTO> CreateProducerAsync(ProducerCreateDTO dTO)
        {
            var response = await _client.PostAsJsonAsync("http://localhost:31365/api/producers/", dTO);
            return await response.Content.ReadFromJsonAsync<ProducerDTO>();
        }

        [Fact]
        public async Task Update_Producer_ReturnOkResponse()
        {
            //Arrange
            //await AuthenticateAsync();
            var createdProducer = await CreateProducerAsync(new ProducerCreateDTO
            {
                Info = "mytestInfo",
                Label = "mytestLabel",
                Name = "mytestName"
            });

            //Act            
            var response = await _client.PutAsJsonAsync($"http://localhost:31365/api/producers/{createdProducer.Id}", new ProducerDTO
            {
                Id = createdProducer.Id,
                Info = "new info",
                Label = "new label",
                Name = "new name"
            });

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnedProducer = await response.Content.ReadFromJsonAsync<Producer>();
            returnedProducer.Id.Should().Be(createdProducer.Id);
            returnedProducer.Info.Should().Be("new info");
            returnedProducer.Label.Should().Be("new label");
            returnedProducer.Name.Should().Be("new name");
        }

        [Fact]
        public async Task ChangeInfo_Producer_ReturnOkResponse()
        {
            //Arrange
            //await AuthenticateAsync();
            var createdProducer = await CreateProducerAsync(new ProducerCreateDTO
            {
                Info = "mytestInfo",
                Label = "mytestLabel",
                Name = "mytestName"
            });

            //Act
            var content = new StringContent(JsonConvert.SerializeObject(new ProducerInfoDTO { Info = "sdf" }), Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync($"http://localhost:31365/api/producers/{createdProducer.Id}", content);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnedProducer = await response.Content.ReadFromJsonAsync<Producer>();
            returnedProducer.Info.Should().Be("sdf");
        }
    }
}
