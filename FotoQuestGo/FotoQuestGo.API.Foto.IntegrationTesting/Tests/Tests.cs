using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FotoQuestGo.API.Foto.IntegrationTesting
{
    public class Tests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Tests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanUploadFile()
        {
            string fileName = "foto-to-upload.jpg";

            var form = new MultipartFormDataContent();
            HttpContent content = new StringContent("fileUpload");
            var filePath = Directory.GetCurrentDirectory() + @"\Tests\" + fileName;
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
            var result = await response.Content.ReadAsStringAsync();
            Guid guid;
            Assert.True(Guid.TryParse(result, out guid));
        }

        [Fact]
        public async Task CanDownloadFile()
        {
            // Act
            var response = await _client.GetAsync("/api/foto/Download/foto-to-download.jpg");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CanDownloadThumbnailFile()
        {
            // Act
            var response = await _client.GetAsync("/api/foto/Download/Thumbnail/foto-to-download.jpg");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CanDownloadSmallFile()
        {
            // Act
            var response = await _client.GetAsync("/api/foto/Download/Small/foto-to-download.jpg");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CanDownloadLargeFile()
        {
            // Act
            var response = await _client.GetAsync("/api/foto/Download/Large/foto-to-download.jpg");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CanDownloadCustomFile()
        {
            // Act
            var response = await _client.GetAsync("/api/foto/Download/Custom/foto-to-download.jpg/777");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}