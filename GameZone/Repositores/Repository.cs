﻿

namespace GameZone.Repositores
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        internal DbSet<T> _dbset;


        public Repository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
            _dbset=dbContext.Set<T>();
        }
        public async Task Delete(int id)
        {
            T entity = await GetById(id);
             _dbset.Remove(entity);
            _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return  await _dbset.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            await _dbset.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int id,T entity)
        {
            _dbset.Attach(entity);
            _dbContext.Entry<T>(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
