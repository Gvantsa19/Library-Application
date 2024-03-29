using FluentValidation.AspNetCore;
using Library.Application.Infrastructure.Persistance;
using Library.Application.Infrastructure.Repositories.Abstraction;
using Library.Application.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Library.Application.Application.Behaviors;
using FluentValidation;
using Library.Application.Shared;
using Library.Application.Application.Commands.Roles;
using Library.Application.Application.Commands.Users.Register;
using Library.Application.Application.Commands.Users.Login;
using Microsoft.AspNet.Identity.EntityFramework;
using Library.Aoolication.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .AddFluentValidation(options =>
                {
                    options.ImplicitlyValidateChildProperties = true;
                    options.ImplicitlyValidateRootCollectionElements = true;
                
                    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                
                });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    opt.OperationFilter<SecurityRequirementsOperationFilter>();
});


builder.Services.AddDbContext<LibraryDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddMediatR(typeof(Program));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateAuthorCommandHandler).Assembly));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
//builder.Services.AddValidatorsFromAssembly(typeof(CreateAuthorCommandHandler).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateRoleCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(LoginCommandHandler).Assembly));
builder.Services.AddTransient<IValidator<RegisterUserCommand>, RegisterUserCommandValidator>();
builder.Services.AddTransient<IValidator<CreateRoleCommand>, CreateRoleCommandHandlerValidator>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Add your Angular app's URL here
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
