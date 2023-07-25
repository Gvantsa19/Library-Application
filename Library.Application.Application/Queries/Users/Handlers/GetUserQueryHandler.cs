using Library.Application.Infrastructure.Entities;
using Library.Application.Infrastructure.Repositories.Abstraction;
using Library.Application.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Application.Queries.Users.Handlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ApplicationResult>
    {
        private readonly IRepository<User> _repository;

        public GetUserQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<ApplicationResult> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.Query(x => x.Id == request.Id).FirstOrDefaultAsync();

            var res = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                RoleID = user.RoleID,
                Email = user.Email,
                Phone = user.Phone
            };

            return new ApplicationResult
            {
                Success = true,
                Data = new
                {
                    user = res
                },
                Errors = null
            };
        }
    }
}
