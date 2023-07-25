using Library.Application.Application.Commands.Users.Register;
using Library.Application.Infrastructure.Entities;
using Library.Application.Infrastructure.Repositories.Abstraction;
using Library.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Application.Commands.Users.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ApplicationResult>
    {
        private readonly IRepository<User> _repository;

        public ResetPasswordCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<ApplicationResult> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.Find(request.Id);

            if (user != null)
            {
                var salt = Salt();
                string hashed = EncryptPassword(request.Password, salt);

                user.Password = hashed;
                user.Salt = salt;

                await _repository.CommitChanges();

            }
            else 
            {
                return new ApplicationResult
                {
                    Errors = null,
                    Success = false,
                };
            }

            return new ApplicationResult
            {
                Data = user,
                Errors = null,
                Success = true,
            };
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
