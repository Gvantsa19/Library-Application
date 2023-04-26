using Library.Application.Shared;
using MediatR;

namespace Library.Application.Application.Commands.Books
{
    public sealed record DeleteBookCommand(int Id) : IRequest<ApplicationResult>;
}
