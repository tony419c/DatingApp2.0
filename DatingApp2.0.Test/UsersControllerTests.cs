using DatingApp2._0.Controllers;
using DatingApp2._0.DTOs;
using DatingApp2._0.Entities;
using DatingApp2._0.Extensions;
using DatingApp2._0.Interfaces;
using FluentAssertions;
using FluentAssertions.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;
using Xunit;

namespace DatingApp2._0.Test
{
    public class UsersControllerTests : BaseTestClass<UsersController>
    {
        [Fact]
        public async void GetUser_ReturnsSuccessfully()
        {
            // Arrange
            var username = "mocked username";
            var expectedUser = new MemberDto()
            {

            };

            autoMocker.GetMock<IUserRepository>()
                .Setup(x => x.GetMemberAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedUser);

            // Act
            var result = await Target.GetUser(username);

            // Assert
            result.Should().Result
                  .Should().BeOkObjectResult().Value
                  .Should().BeEquivalentTo(expectedUser);
        }

        [Fact]
        public async void UpdateUser_UserNotFound_ReturnsNotFound()
        {
            // Arrange
            var user = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new Claim[] { new Claim(ClaimTypes.NameIdentifier, "mocked user identifier"), }, "Test"
                    ));
            Target.ControllerContext = new ControllerContext();
            Target.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            /* https://stackoverflow.com/questions/14190066/is-there-any-way-i-can-mock-a-claims-principal-in-my-asp-net-mvc-web-application */

            autoMocker.GetMock<IUserRepository>()
                .Setup(x => x.GetUserByUsernameAsync(It.IsAny<string>()))
                .ReturnsAsync((AppUser)null);

            // Act
            var result = await Target.UpdateUser(new MemberUpdateDto());

            // Assert
            result.Should().BeNotFoundResult();
        }
    }
}