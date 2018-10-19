using AutoMapper;
using Moq;
using PlayTogether.Core.Domains;
using PlayTogether.Infrastructure.Services.UserServices;
using System;
using System.Threading.Tasks;
using PlayTogether.Infrastructure.Repository;
using PlayTogether.Infrastructure.Services;
using Xunit;

namespace PlayTogether.Test
{
    public class UserServiceTest
    {

        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encryptMock = new Mock<IEncrypter>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object, encryptMock.Object);
            await userService.RegisterUserAsync("user@gmail.com", "234", "karol");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task when_calling_get_async_and_user_exist_it_should_invoke_user_respository_get_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encryptedMock = new Mock<IEncrypter>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object, encryptedMock.Object);
            await userService.GetByEmailAsync("karol@gmail.com");

            var user = new User("karol@gmail.com", "123", "123", "ktos");

            userRepositoryMock.Setup(x => x.GetAsyncByEmail(It.IsAny<string>()))
                .ReturnsAsync(user);

            userRepositoryMock.Verify(x => x.GetAsyncByEmail(It.IsAny<string>()), Times.Once);
        }
        [Fact]
        public async Task when_calling_get_async_and_user_does_not_exist_it_should_invoke_user_respository_get_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encryptMock = new Mock<IEncrypter>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object, encryptMock.Object);
            await userService.GetByEmailAsync("fake@gmail.com");

            userRepositoryMock.Setup(x => x.GetAsyncByEmail(It.IsAny<string>()))
                .ReturnsAsync(() => null);

            userRepositoryMock.Verify(x => x.GetAsyncByEmail(It.IsAny<string>()), Times.Once);
        }
    }
}
