//using Library.Application.Infrastructure.Entities;
//using Library.Application.Infrastructure.Persistance;
//using Library.Application.Infrastructure.Repositories.Abstraction;
//using Library.Application.Shared;
//using MediatR;
//using Microsoft.EntityFrameworkCore;

//namespace Library.Application.Application.Queries.books.Handlers
//{
//    public sealed class GetBookByAuthorHandler : IRequestHandler<GetBooksByAuthorQuery, ApplicationResult>
//    {
//        private readonly LibraryDbContext _library;
//        private readonly IRepository<Book> _repository;

//        public GetBookByAuthorHandler(LibraryDbContext library, IRepository<Book> repository)
//        {
//            _library = library;
//            _repository = repository;
//        }
//        public async Task<ApplicationResult> Handle(GetBooksByAuthorQuery request, CancellationToken cancellationToken)
//        {
//            var skip = (request.page - 1) * request.pageSize;
//            var take = request.pageSize;

//            var res = await _library.Book
//                           .Where(b => b.AuthorId == request.Id)
//                           .Skip(skip)
//                           .Take(take)
//                           .ToListAsync();

//            var totalCount = await _library.Book
//                                       .CountAsync(b => b.AuthorId == request.Id);

//            var totalPages = (int)Math.Ceiling(totalCount / (double)request.pageSize);

//            return new ApplicationResult
//            {
//                Success = true,
//                Data = new
//                {
//                    Books = res,
//                    TotalCount = totalCount,
//                    TotalPages = totalPages
//                },
//                Errors = null
//            };
//        }
//    }
//}
