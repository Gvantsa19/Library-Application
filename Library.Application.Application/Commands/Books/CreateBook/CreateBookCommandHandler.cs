//using FluentValidation;
//using Library.Application.Application.Commands.Authors.CreateAuthor;
//using Library.Application.Infrastructure.Entities;
//using Library.Application.Infrastructure.Persistance;
//using Library.Application.Infrastructure.Repositories.Abstraction;
//using Library.Application.Shared;
//using MediatR;
//using Microsoft.EntityFrameworkCore;

//namespace Library.Application.Application.Commands.Books.CreateBook
//{
//    public class CreateBooksCommandValidator : AbstractValidator<CreateBooksCommand>
//    {
//        public CreateBooksCommandValidator()
//        {
//            RuleFor(x => x.Title).NotNull().NotEmpty();
//            RuleFor(x => x.Description).NotNull().NotEmpty();
//        }
//    }

//    public sealed class CreateBookCommandHandler : IRequestHandler<CreateBooksCommand, ApplicationResult>
//    {
//        private readonly IRepository<Book> _repository;
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IValidator<CreateBooksCommand> _validator;
//        private readonly LibraryDbContext _library;

//        public CreateBookCommandHandler(
//            IRepository<Book> repository, 
//            IUnitOfWork unitOfWork, 
//            IValidator<CreateBooksCommand> validator,
//            LibraryDbContext library
//        )
//        {
//            _repository = repository;
//            _unitOfWork = unitOfWork;
//            _validator = validator;
//            _library = library;
//        }
//        public async Task<ApplicationResult> Handle(CreateBooksCommand request, CancellationToken cancellationToken)
//        {
//            _validator.ValidateAndThrow(request);
//            var author = await _library.Author.Where(x => x.Id == request.AuthorId).FirstOrDefaultAsync();

//            if ( author == null )
//            {
//                return new ApplicationResult
//                {
//                    Data = "author does not exist",
//                    Errors = null,
//                    Success = false,
//                };
//            }

//            var res = new Book
//            {
//                Title = request.Title,
//                Description = request.Description,
//                AuthorId = request.AuthorId,
//                Author = author
//            };

//            await _repository.Store(res);
//            await _unitOfWork.SaveChangesAsync();

//            return new ApplicationResult
//            {
//                Data = res,
//                Errors = null,
//                Success = true,
//            };
//        }
//    }
//}
