using Library.Application.API.Controllers.Abstract;
using Library.Application.Application.Commands.Roles;
using Library.Application.Application.Commands.Users.Login;
using Library.Application.Application.Commands.Users.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
