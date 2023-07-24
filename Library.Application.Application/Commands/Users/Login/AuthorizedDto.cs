using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Application.Commands.Users.Login
{
    public class AuthorizedDto
    {
        public string AuthToken { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
