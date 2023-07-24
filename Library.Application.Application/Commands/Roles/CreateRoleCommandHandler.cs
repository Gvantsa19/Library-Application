using FluentValidation;
using Library.Application.Application.Commands.Users.Register;
using Library.Application.Infrastructure.Entities;
using Library.Application.Infrastructure.Persistance;
using Library.Application.Infrastructure.Repositories;
using Library.Application.Infrastructure.Repositories.Abstraction;
using Library.Application.Shared;
using MediatR;

namespace Library.Application.Application.Commands.Roles
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, ApplicationResult>
    {
        private readonly IRepository<Role> _repository;
        private readonly IValidator<CreateRoleCommand> _validator;
        private readonly LibraryDbContext _context;

        public CreateRoleCommandHandler(IRepository<Role> repository, IValidator<CreateRoleCommand> validator, LibraryDbContext context)
        {
            _repository = repository;
            _validator = validator;
            _context = context;
        }
        public async Task<ApplicationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var res = new Role
            {
                RoleName = request.RoleName,
            };

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
