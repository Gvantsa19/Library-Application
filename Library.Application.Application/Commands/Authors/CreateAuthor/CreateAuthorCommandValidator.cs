using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Application.Commands.Authors.CreateAuthor
{
    public sealed class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorRequestCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }
    }
}
