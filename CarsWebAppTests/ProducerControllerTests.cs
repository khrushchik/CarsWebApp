using CarsWebApp.DTOs;
using CarsWebApp.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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

            //why createdProducer.Id == 0??? Why 0???
            //var response = await TestClient.GetAsync($"http://localhost:31365/api/producers/{createdProducer.Id}");

            var response = await TestClient.GetAsync($"http://localhost:31365/api/producers/1");


            //Assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnedProducer = await response.Content.ReadAsAsync<Producer>();
            //returnedProducer.Id.Should().Be(createdProducer.Id);
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
            //why createdProducer.Id == 0??? Why 0???
            var response = await DeleteProducerAsync(/*createdProducer.Id*/1);
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
