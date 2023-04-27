using FluentValidation;
using Library.Application.Infrastructure.Entities;
using Library.Application.Infrastructure.Persistance;
using Library.Application.Infrastructure.Repositories.Abstraction;
using Library.Application.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Application.Commands.Authors.CreateAuthor
{
    public sealed class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorRequestCommand, ApplicationResult>
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateAuthorRequestCommand> _validator;
        private readonly LibraryDbContext _library;

        public CreateAuthorCommandHandler(
            IRepository<Author> authorRepository, 
            IUnitOfWork unitOfWork, 
            IValidator<CreateAuthorRequestCommand> validator,
            LibraryDbContext library
        )
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
            _library = library;
        }
        public async Task<ApplicationResult> Handle(CreateAuthorRequestCommand request, CancellationToken cancellationToken)
        {

            _validator.ValidateAndThrow(request);

            var author = await _library.Author.Where(x => x.FirstName == request.FirstName && x.LastName == request.LastName).FirstOrDefaultAsync();

            if ( author != null ) 
            {
                return new ApplicationResult
                {
                    Success = false,
                    Data = "Author already exists!",
                    Errors = null
                };
            }

            var res = new Author(request.FirstName, request.LastName);

            await _authorRepository.Store(res);
            await _unitOfWork.SaveChangesAsync();

            return new ApplicationResult
            {
                Success = true,
                Data = res,
                Errors = null
            };
        }
    }
}
