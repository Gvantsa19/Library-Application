using Library.Application.Shared;
using MediatR;

namespace Library.Application.Application.Commands.Authors.DeleteAuthor
{
    public sealed record DeleteAuthorCommand(int Id) : IRequest<ApplicationResult>;
}
