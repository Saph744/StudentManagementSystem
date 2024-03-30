using Microsoft.EntityFrameworkCore;
using schoolmanagement.Domain.Models;
using System.Linq.Expressions;

namespace schoolmanagement.data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SchoolManagementDbContext _context;
        private readonly DbSet<T> entities;
        public Repository(SchoolManagementDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            try
            {
                var entitiesList = await this.entities.ToListAsync();
                return entitiesList;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                // Log the exception or perform additional error handling as needed.
                throw;
            }
        }
        public async Task<IList<T>> GetByIdAsync(Expression<Func<T, bool>> expression)
        {
            return await this.entities.AsNoTracking().Where(expression).ToListAsync();
        }
        public async Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            entities.AsNoTracking();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
