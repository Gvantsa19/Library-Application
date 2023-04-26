using Library.Application.Infrastructure.Persistance;
using Library.Application.Shared;
using Library.Application.Shared.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Application.Queries.books.Handlers
{
    public sealed class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, ApplicationResult>
    {
        private readonly LibraryDbContext _library;

        public GetAllBooksQueryHandler(LibraryDbContext library)
        {
           _library = library;
        }
        public async Task<ApplicationResult> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var pageResult = 3f;
            var pageCount = Math.Ceiling(_library.Book.Count() / pageResult);

            var books = await _library.Book
                .Skip((request.Page - 1) * (int)pageResult)
                .Take((int)pageResult)
                .ToListAsync();

            var res = new GetAllBooksResponse
            {
                Books = books,
                CurrentPage = request.Page,
                Page = (int)pageCount
            };

            return new ApplicationResult
            {
                Success = true,
                Data = res,
                Errors = null
            };
        }
    }
}
