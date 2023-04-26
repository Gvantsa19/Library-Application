﻿using Library.Application.Shared;
using MediatR;

namespace Library.Application.Application.Commands.Books
{
    public sealed record CreateBooksCommand(string Title, string Author, string Description) : IRequest<ApplicationResult>;
}
