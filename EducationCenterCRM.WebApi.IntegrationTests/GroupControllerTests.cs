using EducationCenterCRM.BLL.Contracts.V1;
using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using EducationCenterCRM.DAL.Enums;
using FluentAssertions;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace EducationCenterCRM.WebApi.IntegrationTests
{

    public class GroupControllerTests : IntegrationTests
    {
        [Test]
        public async Task Get_WithoutAnyPosts_ReturnEmptyAsync()
        {
            //Arrange 
            await AuthentificateAsync();

            //Act
            var response = await _client.GetAsync(ApiRoutes.Groups.GetAll);

            //Assert
             response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<List<GroupResponse>>()).Should().BeEmpty();
        }
        [Test]
        public async Task Create_ReturnOkAsync()
        {
            //Arrange 
            await AuthentificateAsync();
            var newGroup = new GroupRequest()
            {
                Title = "title",
                StartDate = DateTime.Now,
                Status = GroupStatus.NotStarted,
                Students = null,
                TeacherId = 1
            };

            //Act
            var response = await _client.PostAsJsonAsync(ApiRoutes.Groups.Create, newGroup);
            var getAllResponse = await _client.GetAsync(ApiRoutes.Groups.GetAll);
            var cretedGroup = (await getAllResponse.Content.ReadAsAsync<List<GroupResponse>>())
                .SingleOrDefault(x => x.Title == newGroup.Title);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK); 
            cretedGroup.Should().NotBeNull();


        }
        [Test]
        public async Task Create_NotValid_ReturnBadRequest()
        {
            //Arrange 
            await AuthentificateAsync();
            var newGroup = new GroupRequest()
            {
                Title = null,
                StartDate = DateTime.Now,
                Status = GroupStatus.NotStarted,
                Students = null,
                TeacherId = 1
            };

            //Act
            var response = await _client.PostAsJsonAsync(ApiRoutes.Groups.Create, newGroup);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
