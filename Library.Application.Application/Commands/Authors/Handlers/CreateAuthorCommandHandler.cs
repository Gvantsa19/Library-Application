using Library.Application.Infrastructure.Entities;
using Library.Application.Infrastructure.Repositories.Abstraction;
using Library.Application.Shared;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Library.Application.Application.Commands.Authors.Handlers
{
    public sealed class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorRequestCommand, ApplicationResult>
    {
        private readonly IRepository<Author> _authorRepository;

        public CreateAuthorCommandHandler(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<ApplicationResult> Handle(CreateAuthorRequestCommand request, CancellationToken cancellationToken)
        {
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
