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
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookCommandHandler(
            IRepository<Book> repository,
            LibraryDbContext library,
            IValidator<UpdateBookCommand> validator,
            IUnitOfWork unitOfWork
        )
        {
            _repository = repository;
            _library = library;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationResult> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var book = await _library.Book
                                   .SingleOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (book == null) 
            {
                return new ApplicationResult
                {
                    Success = false,
                    Data = "book does not exist!",
                    Errors = null
                };
            }

            book.Title = request.Title;
            book.Description = request.Description;

            await _unitOfWork.SaveChangesAsync();

            return new ApplicationResult
            {
                Success = true,
                Data = book,
                Errors = null
            };

        }
    }
}
