using Library.Application.Infrastructure.Persistance;
using Library.Application.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Application.Commands.Authors.DeleteAuthor
{
    public sealed class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, ApplicationResult>
    {
        private readonly LibraryDbContext _dbContext;

        public DeleteAuthorCommandHandler(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationResult> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Author.Remove(await _dbContext.Author.FirstOrDefaultAsync(x => x.Id == request.Id));
            _dbContext.SaveChanges();

            return new ApplicationResult
            {
                Success = true,
                Data = "",
                Errors = null
            };
        }
    }
}
