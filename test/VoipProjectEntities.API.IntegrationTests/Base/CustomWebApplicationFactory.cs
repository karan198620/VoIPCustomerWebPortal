using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using VoipProjectEntities.Api;
using Xunit;

namespace VoipProjectEntities.API.IntegrationTests.Base
{
    [Collection("Database")]
    public class WebApplicationFactory : WebApplicationFactory<Startup>
    {
        private readonly DbFixture _dbFixture;

        public WebApplicationFactory(DbFixture dbFixture)
            => _dbFixture = dbFixture;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(
                        "ConnectionStrings:ApplicationConnectionString", _dbFixture.ApplicationConnString),
                });
            });
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(
                        "ConnectionStrings:IdentityConnectionString", _dbFixture.IdentityConnString)
                });
            });
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(
                        "ConnectionStrings:HealthCheckConnectionString", _dbFixture.HealthCheckConnString)
                });
            });
        }
    }
}
