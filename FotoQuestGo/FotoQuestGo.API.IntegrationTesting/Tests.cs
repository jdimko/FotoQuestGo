using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FotoQuestGo.API;
using FotoQuestGo.API.IntegrationTesting;
using FotoQuestGo.API.Models;
using Newtonsoft.Json;
using Xunit;

namespace Web.Api.IntegrationTests.Controllers
{
    public class PlayersControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public PlayersControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanGetPlayers()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/quest");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var quests = JsonConvert.DeserializeObject<IEnumerable<Quest>>(stringResponse);
        }
    }
}