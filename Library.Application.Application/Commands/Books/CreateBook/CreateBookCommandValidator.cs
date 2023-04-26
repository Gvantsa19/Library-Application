using FluentValidation;
using Library.Application.Application.Commands.Authors.CreateAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Application.Commands.Books.CreateBook
{
    public sealed class CreateBookCommandValidator : AbstractValidator<CreateBooksCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Author).NotEmpty();
        }
    }
}
