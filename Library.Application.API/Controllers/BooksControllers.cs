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
        [HttpPost("get")]
        public async Task<IActionResult> Get(GetAllBooksQuery req)
            => Ok(await Mediator.Send(req));

        [HttpPost("getByAuthor")]
        public async Task<IActionResult> GetByAuthor(GetBooksByAuthorQuery req)
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
