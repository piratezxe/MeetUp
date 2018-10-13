using AutoMapper;
using Moq;
using PlayTogether.Core.Domains;
using PlayTogether.Core.Repository;
using PlayTogether.Infrastructure.Services.UserServices;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PlayTogether.Test
{
    public class UserServiceTest
    {
        [Fact]
        public async Task Test()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
            await userService.RegisterUserAsync("user@gmail.com", "234", "karol");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

    }
}
