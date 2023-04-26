using FluentValidation;
using Library.Application.Application.Commands.Authors.CreateAuthor;
using Library.Application.Infrastructure.Entities;
using Library.Application.Infrastructure.Repositories.Abstraction;
using Library.Application.Shared;
using MediatR;

namespace Library.Application.Application.Commands.Books.CreateBook
{
    public class CreateBooksCommandValidator : AbstractValidator<CreateBooksCommand>
    {
        public CreateBooksCommandValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
        }
    }

    public sealed class CreateBookCommandHandler : IRequestHandler<CreateBooksCommand, ApplicationResult>
    {
        private readonly IRepository<Book> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateBooksCommand> _validator;

        public CreateBookCommandHandler(
            IRepository<Book> repository, 
            IUnitOfWork unitOfWork, 
            IValidator<CreateBooksCommand> validator
        )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }
        public async Task<ApplicationResult> Handle(CreateBooksCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var res = new Book(request.Title, request.Description);

            await _repository.Store(res);
            await _repository.CommitChanges();

            return new ApplicationResult
            {
                Data = res,
                Errors = null,
                Success = true,
            };
        }
    }
}
