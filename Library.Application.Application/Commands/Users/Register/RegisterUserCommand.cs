using Library.Application.Shared;
using MediatR;

namespace Library.Application.Application.Commands.Users.Register
{
    public class RegisterUserCommand : IRequest<ApplicationResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
