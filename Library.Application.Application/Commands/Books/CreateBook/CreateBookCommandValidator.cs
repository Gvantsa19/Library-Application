using FluentValidation;

namespace Library.Application.Application.Commands.Books.CreateBook
{
    public sealed class CreateBookCommandValidator : AbstractValidator<CreateBooksCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.AuthorId).NotEmpty();
        }
    }
}
