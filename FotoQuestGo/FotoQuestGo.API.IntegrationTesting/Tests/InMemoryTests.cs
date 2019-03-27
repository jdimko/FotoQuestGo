using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
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
            var url = "api/quest";
            var values = new[]{
                new KeyValuePair<string, string>("Longitude", "Bar"),
                new KeyValuePair<string, string>("Latitude", "Less"),
                new KeyValuePair<string, string>("SubmissionTime", DateTime.Now.ToString())
            };

            MultipartFormDataContent form = new MultipartFormDataContent();
            foreach (var keyValuePair in values)
                form.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);

            HttpContent content = new StringContent("files");
            string fileName = "foto{0}.jpg";
            string filePath = "";

            foreach (var value in Enum.GetValues(typeof(CardinalDirection)))
            {
                filePath = Directory.GetCurrentDirectory() + string.Format(@"\Tests\" + fileName, value);
                form.Add(content);
                var stream = new FileStream(filePath, FileMode.Open);
                content = new StreamContent(stream);
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = string.Format("foto{0}", value),
                    FileName = string.Format(fileName, value)
                };
                form.Add(content);
            }

            // Act
            var response = await _client.PostAsync(url, form);

            // Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<Quest>();
            Assert.True(result.ID > 0);
        }
    }
}