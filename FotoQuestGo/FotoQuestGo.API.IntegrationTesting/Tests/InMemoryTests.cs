using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FotoQuestGo.API.Models;
using Xunit;

namespace FotoQuestGo.API.IntegrationTesting
{
    public class InMemoryTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public InMemoryTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanGetQuestsThereAreNoQuests()
        {
            // Arrange
            var request = "/api/quest";

            // Act
            var response = await _client.GetAsync(request);
            var temp = await response.Content.ReadAsStringAsync();

            // Assert.
            var result = await response.Content.ReadAsAsync<List<Quest>>();
            Assert.True(result.Count == 0);
        }
    }
}