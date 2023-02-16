using CarsWebApp;
using CarsWebApp.DTOs;
using CarsWebApp.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CarsWebAppTests
{
    public class IntagrationTest
    {
        public readonly HttpClient TestClient;

        public IntagrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(DbContextOptions<CarContext>));
                        services.AddDbContext<CarContext>(options => { options.UseInMemoryDatabase("TestDb"); });
                    });
                });
            TestClient = appFactory.CreateClient();
        }

        protected async Task AuthenticateAsync()
        {
            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }
        
        private async Task<string> GetJwtAsync()
        {
            var register = await TestClient.PostAsJsonAsync("http://localhost:31365/api/users/register", new UserDTO
            {
                Email = "qwerty@gmail.com",
                Password = "12345qwerty"
            });

            var login = await TestClient.PostAsJsonAsync("http://localhost:31365/api/users/login", new UserDTO
            {
                Email = "qwerty@gmail.com",
                Password = "12345qwerty"
            });

            var regResponse = await login.Content.ReadFromJsonAsync<LoginResponse>();
            return regResponse.AccessToken;
        }

        protected async Task<ProducerDTO> CreateProducerAsync(ProducerCreateDTO dTO)
        {
            var response = await TestClient.PostAsJsonAsync("http://localhost:31365/api/producers/", dTO);
            return await response.Content.ReadAsAsync<ProducerDTO>();
        }
        
        protected async Task<HttpResponseMessage> DeleteProducerAsync(int id)
        {
            return await TestClient.DeleteAsync($"http://localhost:31365/api/producers/{id}");
        }
    }
}
