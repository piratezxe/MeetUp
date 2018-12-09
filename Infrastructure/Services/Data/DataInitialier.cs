using Microsoft.Extensions.Logging;
using PlayTogether.Infrastructure.Repository;
using PlayTogether.Infrastructure.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayTogether.Infrastructure.Services.Data
{
    public class DataInitialier : IDataInitializer
    {
        private readonly IUserService _userService;

        private ILogger<DataInitialier> _logger;

        public DataInitialier(IUserService userService, ILogger<DataInitialier> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        public async Task SeedAsync()
        {
            _logger.LogTrace("initializate data...");
            var tasks = new List<Task>(); 

            for(int i = 0; i< 10; i++)
            {
                var userId = Guid.NewGuid();
                var userName = $"user{i}";
                _logger.LogTrace($"Created new user{userName}");
                tasks.Add(_userService.RegisterUserAsync(userId, $"{userName}@gmail.com", "secret", userName));
            }
            await Task.WhenAll(tasks);
        }
    }
}
