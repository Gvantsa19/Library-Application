using Library.Application.Infrastructure.Entities.Abstract;
using Library.Application.Infrastructure.Persistance;
using Library.Application.Infrastructure.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Application.Infrastructure.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : EntityBase
    {
        private LibraryDbContext _context;

        public EfRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task CommitChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<T?> Find(int uId, bool onlyActive = true)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == uId);
        }

        public IQueryable<T> Query(Expression<Func<T, bool>>? expression = null, bool onlyActives = true)
        {
            var baseQuery = _context.Set<T>();

            if (expression == null)
                return baseQuery.AsQueryable();
            return baseQuery.Where(expression).AsQueryable();
        }

        public async Task Store(T document)
        {
            await _context.Set<T>().AddAsync(document);
        }

        public void WithDbContext(LibraryDbContext dbContext)
        {
            _context = dbContext;
        }
    }
}
