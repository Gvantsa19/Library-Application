using Library.Application.Shared;
using MediatR;

namespace Library.Application.Application.Queries.books
{
    public sealed record GetAllBooksQuery(int Page) : IRequest<ApplicationResult>;
}
