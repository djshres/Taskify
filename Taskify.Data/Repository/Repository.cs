using Microsoft.EntityFrameworkCore;
using Taskify.Data.Repository.IRepository;

namespace Taskify.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TaskifyContext _context;

        public Repository(TaskifyContext context)
        {
            _context = context;
        }

        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public async Task Create(T entity)
        {
            await _context.AddAsync(entity);
            await SaveAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Remove(entity);
            await SaveAsync();
        }

        public async Task<IEnumerable<T>> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().AsNoTracking().Where(predicate);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Task.FromResult(_context.Set<T>().AsNoTracking());
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }

        protected Task SaveAsync() => _context.SaveChangesAsync();
    }
}
