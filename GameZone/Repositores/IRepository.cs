﻿
namespace GameZone.Repositores
{
    public interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);

        Task  Insert(T entity);

        Task Update(int id,T entity);

        Task Delete(int id);

        Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate);
    }
}
