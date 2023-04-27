using FluentValidation;

namespace Library.Application.Application.Commands.Books.UpdateBook
{
    public sealed class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
