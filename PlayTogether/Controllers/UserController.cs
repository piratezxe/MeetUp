using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlayTogether.Api.Base;
using PlayTogether.Infrastructure.Commands;
<<<<<<< HEAD
using PlayTogether.Infrastructure.Commands.Account;
using PlayTogether.Infrastructure.Services.UserServices;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PlayTogether.Core.Domains;
using PlayTogether.Infrastructure.Commands.User;
=======
using PlayTogether.Infrastructure.Services.UserServices;
using System.Threading.Tasks;
using PlayTogether.Core.Domains;
using PlayTogether.Infrastructure.Commands.User;
using Microsoft.AspNetCore.Authorization;
>>>>>>> IocRepair-

namespace PlayTogether.Api.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userContext;

        public UserController(IUserService UserContext, ICommandDispatcher _dispatcher)
            : base(_dispatcher)
        {
            _userContext = UserContext;
        }
<<<<<<< HEAD

        [HttpGet]
        public  IEnumerable<User> GetAll()
        {
            try
            {
                return _userContext.GetAlAsync().Result;

            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.Message);
            }
=======
        [HttpGet]
        public  IEnumerable<User> GetAll()
        {
>>>>>>> IocRepair-
            return  _userContext.GetAlAsync().Result;
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
