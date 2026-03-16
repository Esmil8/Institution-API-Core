using Institution.Domain.Core;
using Institution.Domain.Entities;
using Institution.Domain.Interfaces;
using Institution.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Institution.Infrastructure.Core
{
    public class BaseRepository<T>(ApplicationDataContext context) : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDataContext _context = context;

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public async Task AddAsync(T Entity)
        {
            await _context.Set<T>().AddAsync(Entity);
            await _context.SaveChangesAsync();
        
        }

        public async Task PostAsync(T Entity)
        {
            await AddAsync(Entity);
        }
        
        public async Task UpdateAsync(T Entity)
        {
            _context.Set<T>().Update(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T Entity)
        {
            _context.Set<T>().Remove(Entity);
            await _context.SaveChangesAsync();
        }
        
    }
}