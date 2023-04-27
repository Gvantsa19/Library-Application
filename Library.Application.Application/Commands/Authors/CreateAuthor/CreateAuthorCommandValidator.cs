using FluentValidation;

namespace Library.Application.Application.Commands.Authors.CreateAuthor
{
    public sealed class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorRequestCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull();
            RuleFor(x => x.LastName).NotEmpty().NotNull();
        }
    }
}
