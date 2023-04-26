using AutoMapper;
using Library.Application.Application.Infrastructure;
using Library.Application.Infrastructure.Entities;
using Library.Application.Infrastructure.Persistance;
using Library.Application.Infrastructure.Repositories.Abstraction;
using Library.Application.Shared;
using Library.Application.Shared.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            var pageResult = 3f;
            var pageCount = Math.Ceiling(_library.Book.Count() / pageResult);

            var books = await _library.Book
                .Skip((request.PageIndex - 1) * (int)pageResult)
                .Take((int)pageResult)
                .ToListAsync();

            var res = new GetAllBooksResponse
            {
                Books = books,
                CurrentPage = request.PageIndex,
                Page = (int)pageCount
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
