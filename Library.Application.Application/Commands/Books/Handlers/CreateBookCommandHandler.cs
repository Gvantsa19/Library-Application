using FluentValidation;
using Library.Application.Infrastructure.Entities;
using Library.Application.Infrastructure.Repositories.Abstraction;
using Library.Application.Shared;
using MediatR;

namespace Library.Application.Application.Commands.Books.Handlers
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

        public CreateBookCommandHandler(IRepository<Book> repository)
        {
            _repository = repository;
        }
        public async Task<ApplicationResult> Handle(CreateBooksCommand request, CancellationToken cancellationToken)
        {
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
