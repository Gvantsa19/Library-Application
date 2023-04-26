using FluentValidation;
using Library.Application.Application.Commands.Books.CreateBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Application.Commands.Books.UpdateBook
{
    public sealed class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
