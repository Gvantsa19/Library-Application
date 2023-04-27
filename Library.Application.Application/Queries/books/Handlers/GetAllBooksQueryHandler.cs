using AutoMapper;
using Library.Application.Infrastructure.Entities;
using Library.Application.Infrastructure.Persistance;
using Library.Application.Infrastructure.Repositories.Abstraction;
using Library.Application.Shared;
using Library.Application.Shared.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Application.Queries.books.Handlers
{
    public sealed class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, ApplicationResult>
    {
        private readonly LibraryDbContext _library;
        private readonly IRepository<Book> _repository;
        private readonly IMapper _mapper;

        public GetAllBooksQueryHandler(LibraryDbContext library, IRepository<Book> repository, IMapper mapper)
        {
            _library = library;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ApplicationResult> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var skip = (request.page - 1) * request.pageSize;
            var take = request.pageSize;

            var books = await _library.Book
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            var res = new GetAllBooksResponse
            {
                Books = books,
                CurrentPage = request.page,
                Page = (int)take
            };

            return new ApplicationResult
            {
                Success = true,
                Data = res,
                Errors = null
            };
        }
    }
}
