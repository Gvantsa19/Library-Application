using Library.Application.Shared;
using MediatR;

namespace Library.Application.Application.Queries.Authors
{
    public sealed record GetAllAuthorsQuery(int page, int pageSize) : IRequest<ApplicationResult>;
}
