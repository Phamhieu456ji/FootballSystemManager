using System.Threading.Tasks;
using FastConnectFootballSystem.Models.TokenAuth;
using FastConnectFootballSystem.Web.Controllers;
using Shouldly;
using Xunit;

namespace FastConnectFootballSystem.Web.Tests.Controllers
{
    public class HomeController_Tests: FastConnectFootballSystemWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}