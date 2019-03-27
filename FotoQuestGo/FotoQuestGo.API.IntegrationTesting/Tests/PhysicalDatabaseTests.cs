using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FotoQuestGo.API.Models;
using Newtonsoft.Json;
using Xunit;

namespace FotoQuestGo.API.IntegrationTesting
{
    public class PhysicalDatabaseTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public PhysicalDatabaseTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task CanGetQuests()
        {
            // Arrange
            var request = "/api/quest";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();

            //Use the following lines to test for existing content in database
            //var result = await response.Content.ReadAsAsync<List<Quest>>();
            //Assert.True(result.Count == 2);
        }
    }
}