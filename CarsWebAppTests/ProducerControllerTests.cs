using CarsWebApp.DTOs;
using CarsWebApp.Models;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarsWebAppTests
{
    public class ProducerControllerTests: IntagrationTest
    {
        [Fact]
        public async Task GetAll_WithoutAnyProducers_ReturnEmptyOkResponse()
        {
            //Arrange
            await AuthenticateAsync();
            //Act
            var response = await TestClient.GetAsync("http://localhost:31365/api/producers");
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<List<Producer>>()).Should().BeEmpty();

        }

        [Fact]
        public async Task Get_ReturnsProducer_WhenProducerExistsInTheDatabase()
        {
            //Arrange
            await AuthenticateAsync();
            var createdProducer = await CreateProducerAsync(new ProducerCreateDTO
            {
                Info = "mytestInfo",
                Label = "mytestLabel",
                Name = "mytestName"
            });

            //Act
            var response = await TestClient.GetAsync($"http://localhost:31365/api/producers/{createdProducer.Id}");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnedProducer = await response.Content.ReadAsAsync<Producer>();
            returnedProducer.Id.Should().Be(createdProducer.Id);
            returnedProducer.Name.Should().Be(createdProducer.Name);
            returnedProducer.Label.Should().Be(createdProducer.Label);
            returnedProducer.Info.Should().Be(createdProducer.Info);
        }


        [Fact]
        public async Task Delete_Producer_ReturnNoContentResponse()
        {
            //Arrange
            await AuthenticateAsync();
            var createdProducer = await CreateProducerAsync(new ProducerCreateDTO
            {
                Info = "mytestInfo",
                Label = "mytestLabel",
                Name = "mytestName"
            });

            //Act
            var response = await DeleteProducerAsync(createdProducer.Id);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Update_Producer_ReturnOkResponse()
        {
            //Arrange
            await AuthenticateAsync();
            var createdProducer = await CreateProducerAsync(new ProducerCreateDTO
            {
                Info = "mytestInfo",
                Label = "mytestLabel",
                Name = "mytestName"
            });

            //Act            
            var response = await TestClient.PutAsJsonAsync($"http://localhost:31365/api/producers/{createdProducer.Id}", new ProducerDTO
            {
                Id = createdProducer.Id,
                Info = "new info",
                Label = "new label",
                Name = "new name"
            });

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnedProducer = await response.Content.ReadAsAsync<Producer>();
            returnedProducer.Id.Should().Be(createdProducer.Id);
            returnedProducer.Info.Should().Be("new info");
            returnedProducer.Label.Should().Be("new label");
            returnedProducer.Name.Should().Be("new name");
        }

        [Fact]
        public async Task ChangeInfo_Producer_ReturnOkResponse()
        {
            //Arrange
            await AuthenticateAsync();
            var createdProducer = await CreateProducerAsync(new ProducerCreateDTO
            {
                Info = "mytestInfo",
                Label = "mytestLabel",
                Name = "mytestName"
            });

            //Act
            var content = new StringContent(JsonConvert.SerializeObject(new ProducerInfoDTO { Info = "sdf" }), Encoding.UTF8, "application/json");
            var response = await TestClient.PatchAsync($"http://localhost:31365/api/producers/{createdProducer.Id}",  content);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnedProducer = await response.Content.ReadAsAsync<Producer>();
            returnedProducer.Info.Should().Be("sdf");
        }
    }
}
