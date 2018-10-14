using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayTogether.Api.Base;
using PlayTogether.Core.Domains;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Commands.User;
using PlayTogether.Infrastructure.Dto;
using PlayTogether.Infrastructure.Services.UserServices;

namespace PlayTogether.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userContext;

        public UserController(IUserService UserContext, ICommandDispatcher _dispatcher)
            : base(_dispatcher)
        {
            _userContext = UserContext;
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userContext.GetAllAsync().Result;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userContext.GetByEmailAsync(email);

            if(user == null)
            {
                return NotFound();
            }
            return Json(user);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUsers user)
        {
            await _commandDispatcher.DispatchAsync(user);
            return Created($"User/{user.Email}", null);
        }
    }
}
