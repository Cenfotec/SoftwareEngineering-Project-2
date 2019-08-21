using Xunit;
using WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;
using MyTested.WebApi;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers.Tests
{
    public class MembershipControllerTests
    {
        [Fact]
        public void WithStatusCodeShouldNotThrowExceptionWithCorrectStatusCode()
        {
            MyWebApi.
               Controller<MembershipController>()
               .Calling(c => c.Get())
                .ShouldReturn()
                .Ok();
        }

        [Fact]
        public void CheckingReturnOkTest()
        {
            var modelDetailsTestBuilder = MyWebApi.
                Controller<MembershipController>()
                .Calling(c => c.Get())
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<Models.ApiResponse>();
            Assert.NotNull(modelDetailsTestBuilder);
        }

        [Fact]
        public void ReceiveMembershipAndDoesntThrowException()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Membership")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{""Id"": 0, ""FkHotel"": ""9"", ""Price"": ""1200"", ""NumberMonths"": ""12""}")
                .To<MembershipController>(c => c.Post(new Membership(12)
                {
                    Id = 0,
                    FkHotel = 9,
                    Price = 1200.000M
                }));
        }
        [Fact]
        public void ShouldHavePostAttribute()
        {
            var member = new Membership(12)
            {
                Id = 0,
                FkHotel = 9,
                Price = 1200.000M
            };
            // tests whether action has specific attribute type
            MyWebApi
                .Controller<MembershipController>()
                .Calling(c => c.Post(member))
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                    .ContainingAttributeOfType<HttpPostAttribute>());
        }
    }
}