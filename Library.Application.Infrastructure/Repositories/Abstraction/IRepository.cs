using Library.Application.Infrastructure.Persistance;
using System.Linq.Expressions;

namespace Library.Application.Infrastructure.Repositories.Abstraction
{
    public interface IRepository<T> where T : class
    {
        Task<T?> Find(int uId, bool onlyActive = true);

        IQueryable<T> Query(Expression<Func<T, bool>>? expression = null, bool onlyActives = true);

        Task Store(T document);

        void WithDbContext(LibraryDbContext dbContext);

        Task CommitChanges();
    }
}
