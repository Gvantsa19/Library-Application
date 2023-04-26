
using Library.Application.Shared;
using MediatR;

namespace Library.Application.Application.Commands.Authors
{
    public sealed record CreateAuthorRequestCommand(string FirstName, string LastName) : IRequest<ApplicationResult>;
}
