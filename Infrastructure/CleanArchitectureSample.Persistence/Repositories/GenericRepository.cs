using CleanArchitectureSample.Application.Contracts.Persistence;
using CleanArchitectureSample.Domain.Common;
using CleanArchitectureSample.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CleanArchitectureDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(CleanArchitectureDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}