using Library.Application.Infrastructure.Persistance;
using Library.Application.Infrastructure.Repositories.Abstraction;
using Library.Application.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Application.Commands.Authors.DeleteAuthor
{
    public sealed class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, ApplicationResult>
    {
        private readonly LibraryDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAuthorCommandHandler(LibraryDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApplicationResult> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {

            var books = await _dbContext.Book
               .Where(b => b.AuthorId == request.Id)
               .ToListAsync();

            _dbContext.Book.RemoveRange(books);
            _dbContext.Author.Remove(await _dbContext.Author.FirstOrDefaultAsync(x => x.Id == request.Id));
            await _unitOfWork.SaveChangesAsync();

            if (true)
            {

            }

            return new ApplicationResult
            {
                Success = true,
                Data = "Author successfully deleted",
                Errors = null
            };
        }
    }
}
