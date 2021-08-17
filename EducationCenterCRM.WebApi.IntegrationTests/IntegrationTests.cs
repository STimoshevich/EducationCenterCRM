using NUnit.Framework;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Mvc.Testing;
using EducationCenterCRM.BLL;
using Microsoft.Extensions.DependencyInjection.Extensions;
using EducationCenterCRM.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EducationCenterCRM.BLL.Contracts.V1;
using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using System.Net.Http.Json;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;

namespace EducationCenterCRM.WebApi.IntegrationTests
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [TestFixture]
    public class IntegrationTests  : IDisposable
    {
        protected readonly HttpClient _client;
        private readonly IServiceProvider _serviceProvider;

        public IntegrationTests()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(EducationCenterDatabase));
                        services.AddDbContext<EducationCenterDatabase>(options =>
                        {
                            options.UseInMemoryDatabase("TestDb");
                        });
                    });
                });

            _serviceProvider = appFactory.Services;
            _client = appFactory.CreateClient();
        }





        public async Task AuthentificateAsync()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        public void Dispose()
        {
            using var serviceScope = _serviceProvider.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<EducationCenterDatabase>();
            context.Database.EnsureDeleted();
        }

        private async Task<string> GetJwtAsync()
        {

            var newUser = new UserRegistrationRequest()
            {
                Email = "newEmail@gmail.com",
                Password = "NewPassword1234!"
            };
            var registraionResponse = await _client.PostAsJsonAsync(ApiRoutes.Identity.Register, newUser);
            var registraionResponseContent = await registraionResponse.Content.ReadFromJsonAsync<AuthSuccessResponse>();
            return registraionResponseContent.Token;
        }
    }
}