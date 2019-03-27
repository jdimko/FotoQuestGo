using System;
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

            // Assert
            var result = await response.Content.ReadAsAsync<List<Quest>>();
            Assert.True(result.Count == 0);
        }

        [Fact]
        public async Task CanAddQuest()
        {
            // Arrange
            var request = new
            {
                Url = "/api/quest",
                Body = new
                {
                    Longitude = "21231231",
                    Latitude = "1231231211",
                    SubmissionTime = DateTime.Now
                }
            };

            // Act
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<Quest>();
            Assert.True(result.ID > 0);
        }
    }
}