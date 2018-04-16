using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PiwoBack.Data.ViewModels;
using PiwoBack.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiwoBack.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountController: Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _accountService.Register(registerModel);

            if (result.IsError)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginViewModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _accountService.Login(loginModel);

            if (result.IsError)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
