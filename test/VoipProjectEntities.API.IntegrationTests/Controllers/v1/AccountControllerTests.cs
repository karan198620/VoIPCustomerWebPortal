using Newtonsoft.Json;
using Shouldly;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VoipProjectEntities.API.IntegrationTests.Base;
using VoipProjectEntities.Application.Models.Authentication;
using Xunit;

namespace VoipProjectEntities.API.IntegrationTests.Controllers.v1
{
    [Collection("Database")]
    public class AccountControllerTests : IClassFixture<WebApplicationFactory>
    {
        private readonly WebApplicationFactory _factory;
        public AccountControllerTests(WebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Post_Authenticate_ReturnsSuccessResult()
        {
            var client = _factory.CreateClient();

            var request = new AuthenticationRequest()
            {
                Email = "john@test.com",
                Password = "User123!@#"
            };

            var requestJson = JsonConvert.SerializeObject(request);

            HttpContent content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/v1/Account/authenticate", content);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<AuthenticationResponse>(responseString);

            result.IsAuthenticated.ShouldBeEquivalentTo(true);
            result.Token.ShouldNotBeNull();
            result.RefreshToken.ShouldNotBeNull();
        }

        [Fact]
        public async Task Post_Register_ReturnsSuccessResult()
        {
            var client = _factory.CreateClient();

            var request = new RegistrationRequest()
            {
                CustomerName = "fname",
                ISTrialBalanceOpted = true,
                ISMigrated = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CustomerTypeID = 2,
                Email = "fname@test.com",
                UserName = "fname.lname",
                Password = "User123!@#"
            };

            var requestJson = JsonConvert.SerializeObject(request);

            HttpContent content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/v1/Account/register", content);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<RegistrationResponse>(responseString);

            result.UserId.ShouldNotBeNull();
        }
    }
}
