using CarsWebApp;
using CarsWebApp.DTOs;
using CarsWebApp.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarsWebAppTests.Setup
{
    public class IntegrationTestBase : IClassFixture<CustomWebApplicationFactory>
    {
        public HttpClient _client;

        public IntegrationTestBase(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        protected async Task<ProducerDTO> CreateProducerAsync(ProducerCreateDTO dTO)
        {
            var response = await _client.PostAsJsonAsync("http://localhost:31365/api/producers/", dTO);
            return await response.Content.ReadFromJsonAsync<ProducerDTO>();
        }
    }
}
