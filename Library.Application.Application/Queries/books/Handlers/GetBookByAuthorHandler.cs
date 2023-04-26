using Library.Application.Infrastructure.Persistance;
using Library.Application.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Application.Queries.books.Handlers
{
    public sealed class GetBookByAuthorHandler : IRequestHandler<GetBooksByAuthorQuery, ApplicationResult>
    {
        private readonly LibraryDbContext _library;

        public GetBookByAuthorHandler(LibraryDbContext library)
        {
            _library = library;
        }
        public async Task<ApplicationResult> Handle(GetBooksByAuthorQuery request, CancellationToken cancellationToken)
        {
            var res = _library.Book
                .Include(x => x.Author)
                .Where(x =>
                           (string.IsNullOrEmpty(request.authorName) || x.Author.Select(x => x.FirstName).Contains(request.authorName)) &&
                           (string.IsNullOrEmpty(request.authorLastName) || x.Author.Select(x => x.LastName).Contains((request.authorLastName))));

            var count = await res.CountAsync();
            var items = await res.Skip((request.pageNumber - 1) * request.pageSize).Take(request.pageSize).ToListAsync();

            return new ApplicationResult
            {
                Success = true,
                Data = items,
                Errors = null
            };
        }
    }
}
