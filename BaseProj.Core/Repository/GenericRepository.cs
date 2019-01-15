using BaseProj.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BaseProj.Core.Repository
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : GenericEntity
    {
        private BaseProjContext _context;

        public GenericRepository(BaseProjContext context)
        {
            _context = context;
        }

        public Entity SelectByID(object key) 
        {
            return _context.Set<Entity>().Find(key);
        }

        public async Task<Entity> SelectByIDAsync(object key) 
        {
            return await _context.Set<Entity>().FindAsync(key);
        }

        public IQueryable<Entity> SelectAll() 
        {
            return _context.Set<Entity>();
        }

        public async Task<IQueryable<Entity>> SelectAllAsync() 
        {
            return await Task.Run(() => _context.Set<Entity>());
        }

        public IQueryable<Entity> SelectWhere(Expression<Func<Entity, bool>> predicate) 
        {
            return _context.Set<Entity>().Where(predicate);
        }

        public async Task<IQueryable<Entity>> SelectWhereAsync(Expression<Func<Entity, bool>> predicate) 
        {
            return await Task.Run(() => _context.Set<Entity>().Where(predicate));
        }

        public int Insert(Entity item) 
        {
            _context.Set<Entity>().Add(item);
            Commit();
            return item.Id;
        }

        public async Task<int> InsertAsync(Entity item) 
        {
            await _context.Set<Entity>().AddAsync(item);
            CommitAsync();
            return item.Id;
        }

        public void Delete(Entity item) 
        {
            _context.Set<Entity>().Remove(item);
            Commit();
        }

        public async void DeleteAsync(Entity item) 
        {
            await Task.Run(() => _context.Set<Entity>().Remove(item));
            CommitAsync();
        }

        public void Update(Entity item) 
        {
            _context.Entry(item).State = EntityState.Modified;
            Commit();
        }

        public async void UpdateAsync(Entity item) 
        {
            await Task.Run(() => _context.Entry(item).State = EntityState.Modified);
            CommitAsync();
        }

        public void Commit()
        {
            int ret = 0;
            bool saveFailed;
            do
            {
                saveFailed = false;

                try
                {
                    ret = _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException exception)
                {
                    saveFailed = true;

                    var entry = exception.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                }
                catch (DbUpdateException exception)
                {
                    saveFailed = true;
                    throw exception;
                }
            }
            while (saveFailed);
        }

        public async void CommitAsync()
        {
            int ret = 0;
            bool saveFailed;
            do
            {
                saveFailed = false;

                try
                {
                    ret = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException exception)
                {
                    saveFailed = true;

                    var entry = exception.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                }
                catch (DbUpdateException exception)
                {
                    saveFailed = true;
                    throw exception;
                }
            }
            while (saveFailed);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
