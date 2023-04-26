using Library.Application.Infrastructure.Persistance;
using Library.Application.Shared;
using MediatR;

namespace Library.Application.Application.Commands.Books.Handlers
{
    public sealed class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, ApplicationResult>
    {
        private readonly LibraryDbContext _library;

        public DeleteBookCommandHandler(LibraryDbContext library)
        {
           _library = library;
        }
        public async Task<ApplicationResult> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _library.Book.FindAsync(request.Id);

            if (book == null)
            {
                return null;
            }

            _library.Book.Remove(book);

            await _library.SaveChangesAsync(cancellationToken);

            return new ApplicationResult
            {
                Success = true,
                Data = "",
                Errors = null
            };

        }
    }
}
