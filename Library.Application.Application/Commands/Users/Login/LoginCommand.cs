using Library.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Application.Commands.Users.Login
{
    public class LoginCommand : IRequest<ApplicationResult>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
