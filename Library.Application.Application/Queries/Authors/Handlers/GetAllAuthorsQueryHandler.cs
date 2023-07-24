//using Library.Application.Infrastructure.Entities;
//using Library.Application.Infrastructure.Persistance;
//using Library.Application.Infrastructure.Repositories.Abstraction;
//using Library.Application.Shared;
//using Library.Application.Shared.Dtos;
//using MediatR;
//using Microsoft.EntityFrameworkCore;

//namespace Library.Application.Application.Queries.Authors.Handlers
//{
//    public sealed class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, ApplicationResult>
//    {
//        private readonly LibraryDbContext _library;
//        private readonly IRepository<Author> _repository;

//        public GetAllAuthorsQueryHandler(LibraryDbContext library, IRepository<Author> repository)
//        {
//            _library = library;
//            _repository = repository;
//        }
//        public async Task<ApplicationResult> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
//        {
//            var skip = (request.page - 1) * request.pageSize;
//            var take = request.pageSize;

//            var authors = await _library.Author
//                .Skip(skip)
//                .Take(take)
//                .ToListAsync();

//            var res = new GetAllAuthorResponse
//            {
//                Authors = authors,
//                CurrentPage = request.page,
//                Page = (int)take
//            };

//            return new ApplicationResult
//            {
//                Success = true,
//                Data = res,
//                Errors = null
//            };
//        }
//    }
//}
