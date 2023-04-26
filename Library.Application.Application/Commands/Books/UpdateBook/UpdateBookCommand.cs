using Library.Application.Shared;
using MediatR;

namespace Library.Application.Application.Commands.Books.UpdateBook
{
    public sealed record class UpdateBookCommand(int Id, string Title, string Description) : IRequest<ApplicationResult>;
}
