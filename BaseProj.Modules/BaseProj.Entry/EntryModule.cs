using BaseProj.Core.Entities;
using BaseProj.Core.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProj.Entry
{
    public class EntryModule : IEntryModule
    {
        private readonly IGenericRepository<User> repository;

        public EntryModule(IGenericRepository<User> genericRepository)
        {
            this.repository = genericRepository;
        }

        public async Task<bool> UserAutenticatedAsync(User user)
        {
            var us = await repository.SelectWhereAsync(x => x.Email == user.Email);
            var u = await Task.Run(() => us.FirstOrDefault());
            if(u != null)
                if (u.Password == user.Password) return true;

            return false;
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            return await repository.InsertAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            repository.DeleteAsync(new User { Id = id });
        }
    }
}
