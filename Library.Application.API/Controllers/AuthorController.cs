using Library.Application.API.Controllers.Abstract;
using Library.Application.Application.Commands.Authors.CreateAuthor;
using Library.Application.Application.Commands.Authors.DeleteAuthor;
using Library.Application.Application.Queries.Authors;
using Microsoft.AspNetCore.Mvc;

namespace Library.Application.API.Controllers
{
    [Route("api/authors")]
    public class AuthorController : APIController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllAuthorsQuery req)
           => Ok(await Mediator.Send(req));

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateAuthorRequestCommand req)
            => Ok(await Mediator.Send(req));

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteAuthorCommand req)
            => Ok(await Mediator.Send(req));
    }
}
