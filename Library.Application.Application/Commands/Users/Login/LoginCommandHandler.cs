using Library.Application.Infrastructure.Entities;
using Library.Application.Infrastructure.Persistance;
using Library.Application.Infrastructure.Repositories.Abstraction;
using Library.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Library.Application.Application.Commands.Users.Login
{
    public class LoginCommandHandler : BaseService, IRequestHandler<LoginCommand, ApplicationResult>
    {
        private readonly IRepository<User> _repository;
        private readonly LibraryDbContext _context;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(
            IRepository<User> repository,
            LibraryDbContext context,
            IConfiguration configuration
            )
        {
            _repository = repository;
            _context = context;
            _configuration = configuration;
        }
        public async Task<ApplicationResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.Query(x => x.Email == request.UserName).FirstOrDefaultAsync();
            if ( user != null )
            {
                string hashed = EncryptPassword(request.Password, user.Salt);
                if (hashed == user.Password)
                {

                }
            }

            string token = CreateToken(user);

            return await Ok(new AuthorizedDto
            {
                AuthToken = token,
                ExpiresIn = DateTime.Now.AddDays(1),
            });
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

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.RoleID.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
