using Library.Application.API.Controllers.Abstract;
using Library.Application.Application.Commands.Authors.CreateAuthor;
using Library.Application.Application.Commands.Roles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Application.API.Controllers
{
    [Route("api/roles")]
    public class RolesController : APIController
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateRoleCommand req)
          => Ok(await Mediator.Send(req));
    }
}
