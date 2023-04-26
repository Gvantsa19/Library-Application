using Library.Application.Shared;
using MediatR;

namespace Library.Application.Application.Commands.Authors
{
    public sealed record DeleteAuthorCommand(int Id) : IRequest<ApplicationResult>;
}
