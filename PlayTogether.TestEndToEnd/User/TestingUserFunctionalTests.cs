using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Dto;
using Xunit;

namespace PlayTogether.TestEndToEnd.User
{
    public class TestingUserFunctionalTests : TestingBase
    {
        public TestingUserFunctionalTests() : base()
        {
        }

        [Fact]
        public async Task Given_valid_email_user_should_exist()
        {
            var email = "karol@gmail.com";
            var response = await _client.GetAsync($"User/Get/{email}");

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var responseString = await response.Content.ReadAsStringAsync();

            var user = JsonConvert.DeserializeObject<UserDto>(responseString);
            //assert
            user.Email.Should().BeEquivalentTo(email);
        }

        [Fact]
        public async Task Given_invalid_email_user_should_not_exist()
        {
            var email = "kdasd@gmail.com";
            var response = await _client.GetAsync($"User/Get/{email}");

            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task Given_unique_email_user_should_be_created()
        {
            var email = "test@gmail.com";
            var request = new CreateUsers
            {
                Email = email,
                UserName = "test",
                Password = "secret"
            };
            var response = await _client.PostAsync($"User/CreateUser", GetPayload(request));
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().Should().BeEquivalentTo($"User/{request.Email}"); //work now
        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json"); 
        }
    }
}
