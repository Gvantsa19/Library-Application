using Library.Application.Application.Infrastructure;
using Library.Application.Shared;
using Library.Application.Shared.Dtos;
using MediatR;

namespace Library.Application.Application.Queries.books
{
    public sealed record GetAllBooksQuery(string? Title, int PageIndex, int PageSize) : IRequest<ApplicationResult>;
}
