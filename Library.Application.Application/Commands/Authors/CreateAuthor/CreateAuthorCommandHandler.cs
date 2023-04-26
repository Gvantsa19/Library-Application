using FluentValidation;
using Library.Application.Infrastructure.Entities;
using Library.Application.Infrastructure.Repositories.Abstraction;
using Library.Application.Shared;
using MediatR;

namespace Library.Application.Application.Commands.Authors.CreateAuthor
{
    public sealed class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorRequestCommand, ApplicationResult>
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateAuthorRequestCommand> _validator;

        public CreateAuthorCommandHandler(
            IRepository<Author> authorRepository, 
            IUnitOfWork unitOfWork, 
            IValidator<CreateAuthorRequestCommand> validator
        )
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }
        public async Task<ApplicationResult> Handle(CreateAuthorRequestCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var res = new Author(request.FirstName, request.LastName);

            await _authorRepository.Store(res);
            await _authorRepository.CommitChanges();

            return new ApplicationResult
            {
                Success = true,
                Data = res,
                Errors = null
            };
        }
    }
}
