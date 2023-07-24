//using Library.Application.Application.Commands.Books.DeleteBook;
//using Library.Application.Infrastructure.Persistance;
//using Library.Application.Infrastructure.Repositories.Abstraction;
//using Library.Application.Shared;
//using MediatR;

//namespace Library.Application.Application.Commands.Books.Handlers
//{
//    public sealed class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, ApplicationResult>
//    {
//        private readonly LibraryDbContext _library;
//        private readonly IUnitOfWork _unitOfWork;

//        public DeleteBookCommandHandler(LibraryDbContext library, IUnitOfWork unitOfWork)
//        {
//           _library = library;
//            _unitOfWork = unitOfWork;
//        }
//        public async Task<ApplicationResult> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
//        {
//            var book = await _library.Book.FindAsync(request.Id);

//            if (book == null)
//            {
//                return null;
//            }

//            _library.Book.Remove(book);

//            await _unitOfWork.SaveChangesAsync(cancellationToken);

//            return new ApplicationResult
//            {
//                Success = true,
//                Data = "",
//                Errors = null
//            };

//        }
//    }
//}
