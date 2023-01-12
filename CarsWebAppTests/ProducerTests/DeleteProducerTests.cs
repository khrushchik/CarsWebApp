﻿using CarsWebApp.DTOs;
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
    public class DeleteProducerTests: IntegrationTestBase
    {
        public DeleteProducerTests(CustomWebApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task Delete_Producer_ReturnNoContentResponse()
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
            var response = await DeleteProducerAsync(createdProducer.Id);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        protected async Task<HttpResponseMessage> DeleteProducerAsync(int id)
        {
            return await _client.DeleteAsync($"http://localhost:31365/api/producers/{id}");
        }
    }
}