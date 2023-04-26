using FluentValidation;
using Library.Application.Infrastructure.Entities;
using Library.Application.Infrastructure.Persistance;
using Library.Application.Infrastructure.Repositories.Abstraction;
using Library.Application.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Application.Commands.Books.UpdateBook
{
    public sealed class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, ApplicationResult>
    {
        private readonly IRepository<Book> _repository;
        private readonly LibraryDbContext _library;
        private readonly IValidator<UpdateBookCommand> _validator;

        public UpdateBookCommandHandler(
            IRepository<Book> repository, 
            LibraryDbContext library,
            IValidator<UpdateBookCommand> validator
        )
        {
            _repository = repository;
            _library = library;
            _validator = validator;
        }
        public async Task<ApplicationResult> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var book = await _library.Book
                                   .SingleOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (book == null) { return null; }

            book = new Book(request.Title, request.Description);

            await _library.SaveChangesAsync();

            return new ApplicationResult
            {
                Success = true,
                Data = book,
                Errors = null
            };

        }
    }
}
