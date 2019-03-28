using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace FotoQuestGo.API.Foto.IntegrationTesting
{
    public class InMemoryTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public InMemoryTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanUploadFile()
        {
            string fileName = "foto.jpg";
            string filePath = "";

            var form = new MultipartFormDataContent();
            HttpContent content = new StringContent("fileUpload");
            filePath = Directory.GetCurrentDirectory() + @"\Tests\" + fileName;
            form.Add(content);
            var stream = new FileStream(filePath, FileMode.Open);
            content = new StreamContent(stream);
            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = string.Format("foto"),
                FileName = fileName
            };
            form.Add(content);
            // Act
            var response = await _client.PostAsync("/api/foto/Upload", form);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}