﻿using AutoMapper;
using FotoQuestGo.API.Quest.Context;
using FotoQuestGo.API.Quest.UnitOfWork;
using FotoQuestGo.Common.AutoMapperProfiles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace FotoQuestGo.API.Quest.IntegrationTesting
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                // Add a database context (AppDbContext) using an in-memory database for testing.
                services.AddDbContext<FotoQuestContext>(options =>
                {
                    options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                    options.UseInternalServiceProvider(serviceProvider);
                });

                services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

                // Auto Mapper Configurations
                var mappingConfig = new MapperConfiguration(x =>
                {
                    x.AddProfiles(new[] {
                            typeof(QuestProfile),
                        });
                });

                IMapper mapper = mappingConfig.CreateMapper();
                services.AddSingleton(mapper);

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                //// Create a scope to obtain a reference to the database contexts
                //using (var scope = sp.CreateScope())
                //{
                //    var scopedServices = scope.ServiceProvider;
                //    var appDb = scopedServices.GetRequiredService<FotoQuestContext>();

                //    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                //    // Ensure the database is created.
                //    appDb.Database.EnsureCreated();

                //    try
                //    {
                //        // Seed the database with some specific test data.
                //        //SeedData.PopulateTestData(appDb);
                //    }
                //    catch (Exception ex)
                //    {
                //        logger.LogError(ex, "An error occurred seeding the " +
                //                            "database with test messages. Error: {ex.Message}");
                //    }
                //}
            });
        }
    }
}