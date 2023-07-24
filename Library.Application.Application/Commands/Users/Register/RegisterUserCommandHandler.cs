using FluentValidation;
using Library.Application.Application.Commands.Books.CreateBook;
using Library.Application.Infrastructure.Entities;
using Library.Application.Infrastructure.Persistance;
using Library.Application.Infrastructure.Repositories.Abstraction;
using Library.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Application.Commands.Users.Register
{
    public sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ApplicationResult>
    {
        private readonly IRepository<User> _repository;
        private readonly IValidator<RegisterUserCommand> _validator;
        private readonly LibraryDbContext _context;

        public RegisterUserCommandHandler(
            IRepository<User> repository, 
            IValidator<RegisterUserCommand> validator, 
            LibraryDbContext context
            )
        {
            _repository = repository;
            _validator = validator;
            _context = context;
        }
        public async Task<ApplicationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var existed = await _context.Users.FirstOrDefaultAsync(u => u.UserName == request.Username);
            if (existed != null)
            {
                return new ApplicationResult
                {
                    Data = "user already exist",
                    Errors = null,
                    Success = false,
                };
            }

            var salt = Salt();
            string hashed = EncryptPassword(request.Password, salt);

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Username,
                Password = hashed,
                Salt = salt,
                RoleID = 2,
                Email = request.Email,
                Phone = request.Phone,
                CreateDate = DateTimeOffset.Now
            };
            user.Activate();

            await _repository.Store(user);
            await _repository.CommitChanges();

            return new ApplicationResult
            {
                Data = user,
                Errors = null,
                Success = true,
            };
        }

        private int GetRoleIdByName(string roleName)
        {
            return _context.Roles.FirstOrDefault(r => r.RoleName == roleName)?.Id ?? 0;
        }

        private string EncryptPassword(string password, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                                         password: password,
                                                         salt: Convert.FromBase64String(salt),
                                                         prf: KeyDerivationPrf.HMACSHA256,
                                                         iterationCount: 100000,
                                                         numBytesRequested: 256 / 8));
        }

        private string Salt()
        {
            byte[] salt = new byte[128 / 8];

            RandomNumberGenerator.Fill(salt);

            return Convert.ToBase64String(salt);
        }
    }
}
