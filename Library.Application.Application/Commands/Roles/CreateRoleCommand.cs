using Library.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Application.Commands.Roles
{
    public class CreateRoleCommand : IRequest<ApplicationResult>
    {
        public string RoleName { get; set; }
    }
}
