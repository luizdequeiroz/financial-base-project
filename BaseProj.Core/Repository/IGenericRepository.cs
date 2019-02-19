using BaseProj.Core.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BaseProj.Core.Repository
{
    public interface IGenericRepository<Entity> : IDisposable where Entity : GenericEntity
    {
        IQueryable<Entity> SelectAll();
        Task<IQueryable<Entity>> SelectAllAsync();
        IQueryable<Entity> SelectWhere(Expression<Func<Entity, bool>> predicate);
        Task<IQueryable<Entity>> SelectWhereAsync(Expression<Func<Entity, bool>> predicate);
        Entity SelectByID(object key);
        Task<Entity> SelectByIDAsync(object key);
        Entity Insert(Entity item);
        Task<Entity> InsertAsync(Entity item);
        void Update(Entity item);
        Task UpdateAsync(Entity item);
        void Delete(Entity item);
        Task DeleteAsync(Entity item);
        IQueryable<Entity> BulkInsert(IQueryable<Entity> items);
        Task<IQueryable<Entity>> BulkInsertAsync(IQueryable<Entity> items);
        void Commit();
        Task CommitAsync();
    }
}
