using Library.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Application.Queries.books
{
    public sealed record GetBooksByAuthorQuery(string authorName, string authorLastName, int pageNumber = 1, int pageSize = 10) : IRequest<ApplicationResult>;
}
