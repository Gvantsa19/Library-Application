using FluentValidation;
using Library.Application.Application.Commands.Users.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Application.Commands.Roles
{
    public class CreateRoleCommandHandlerValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandHandlerValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty();
        }
    }
}
