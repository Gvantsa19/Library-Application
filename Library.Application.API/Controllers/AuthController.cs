using Library.Application.API.Controllers.Abstract;
using Library.Application.Application.Commands.Roles;
using Library.Application.Application.Commands.Users.Login;
using Library.Application.Application.Commands.Users.Register;
using Library.Application.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System;
using Library.Application.Application.Queries.Users;
using Library.Application.Application.Commands.Users.ResetPassword;
using Microsoft.AspNetCore.Authorization;

namespace Library.Application.API.Controllers
{
    [Route("api/auth")]
    public class AuthController : APIController
    {
        [HttpPost("login")]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Login([FromBody] LoginCommand req)
         => Ok(await Mediator.Send(req));

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RegisterUserCommand req)
         => Ok(await Mediator.Send(req));

        [HttpPost("me/reset-password"), Authorize(Roles = "2")]
        public async Task<ActionResult<ApplicationResult>> ResetPassword([FromBody] ResetPasswordCommand req)
        {
            return await Mediator.Send(req);
        }

        [HttpGet("me"), Authorize(Roles = "2")]
        public async Task<ActionResult<ApplicationResult>> Me([FromQuery] GetUserQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
