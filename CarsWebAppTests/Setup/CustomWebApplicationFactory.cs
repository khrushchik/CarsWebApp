using CarsWebApp;
using CarsWebApp.Models;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarsWebAppTests.Setup
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>, IAsyncLifetime
    {
        private readonly TestcontainerDatabase _dbContainer = new TestcontainersBuilder<MsSqlTestcontainer>()
             .WithDatabase(new MsSqlTestcontainerConfiguration
             {
                    //Database = "CarWebAppDB",
                    //Username = "sa",
                 Password = "12345Qwerty!",
             })
             .WithImage("mcr.microsoft.com/mssql/server:2019-latest")
             .WithCleanUp(true)
             .Build();

        public HttpClient HttpClient { get; private set; } = default!;
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveDbContext<CarContext>();
                services.AddDbContext<CarContext>(options => { options.UseSqlServer(_dbContainer.ConnectionString); });
                services.EnsureDbCreated<CarContext>();
            });
        }

        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();
            HttpClient = CreateClient();
        }

        public async new Task DisposeAsync() => await _dbContainer.DisposeAsync();
    }
}
