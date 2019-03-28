using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace FotoQuestGo.API.Quest.IntegrationTesting
{
    public class RealTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public RealTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task CanGetQuests()
        {
            // Arrange
            var request = "/api/quest/GetAll";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}