using Library.Application.API.Controllers.Abstract;
using Library.Application.Application.Commands.Books.CreateBook;
using Library.Application.Application.Commands.Books.DeleteBook;
using Library.Application.Application.Commands.Books.UpdateBook;
using Library.Application.Application.Queries.books;
using Microsoft.AspNetCore.Mvc;

namespace Library.Application.API.Controllers
{
    [Route("api/books")]
    public class BooksControllers : APIController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllBooksQuery req)
            => Ok(await Mediator.Send(req));

        [HttpGet("getByAuthor")]
        public async Task<IActionResult> GetByAuthor([FromQuery] GetBooksByAuthorQuery req)
            => Ok(await Mediator.Send(req));

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateBooksCommand req)
            => Ok(await Mediator.Send(req));

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateBookCommand req)
           => Ok(await Mediator.Send(req));

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteBookCommand req)
           => Ok(await Mediator.Send(req));

    }
}
