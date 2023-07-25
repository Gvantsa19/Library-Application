using Library.Application.Shared;
using MediatR;

namespace Library.Application.Application.Queries.Users
{
    public sealed record GetUserQuery(int Id) : IRequest<ApplicationResult>;
}
