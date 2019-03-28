﻿using FotoQuestGo.API.Foto.FileStorage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace FotoQuestGo.API.Foto.IntegrationTesting
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .BuildServiceProvider();

                services.AddScoped<IFotoStorage, InMemoryFotoStorage>();

                // Build the service provider.
                var sp = services.BuildServiceProvider();
            });
        }
    }
}