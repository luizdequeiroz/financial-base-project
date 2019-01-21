using BaseProj.Core.Entities;
using BaseProj.Core.Exceptions;
using BaseProj.Core.Repository;
using BaseProj.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProj.Entry
{
    public class EntryModule : IEntryModule
    {
        private readonly IGenericRepository<User> userRepository;

        public EntryModule(IGenericRepository<User> genericRepository)
        {
            this.userRepository = genericRepository;
        }

        public async Task<bool> UserAutenticatedAsync(User user)
        {
            var us = await userRepository.SelectWhereAsync(x => x.Email == user.Email);
            var u = await Task.Run(() => us.FirstOrDefault());
            if (u != null)
                if (u.Password == user.Password) return true;

            return false;
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            return await userRepository.InsertAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await userRepository.SelectByIDAsync(id);
            await userRepository.DeleteAsync(user);
        }

        public async Task<User[]> ListAllUsersAsync()
        {
            var users = await userRepository.SelectAllAsync();
            return users.Select(u => u.Without("Password")).ToArray();
        }

        public async Task<User> UpdateUserAsync(int id, User user)
        {
            var us = await userRepository.SelectByIDAsync(id);
            us.Name = user.Name;
            us.Password = user.Password;
            us.BirthDate = user.BirthDate;
            await userRepository.UpdateAsync(us);
            return us;
        }

        public async Task<User> GetUserByAsync(int id)
        {
            var user = await userRepository.SelectByIDAsync(id);
            return user.Without("Password");
        }

        public async Task<User[]> GetUsersByPropertyAsync(string property, object value)
        {
            var users = new List<User>().ToArray();
            if (property == "name")
                users = (await userRepository.SelectWhereAsync(u => u.Name.ToLower().Contains(value.ToString().ToLower()))).ToArray();
            else if (property == "email")
                users = (await userRepository.SelectWhereAsync(u => u.Email.ToLower().Contains(value.ToString().ToLower()))).ToArray();
            else if (property == "birthDate")
                users = (await userRepository.SelectWhereAsync(u => u.BirthDate.Date == (value as string).ToDateTime().Date)).ToArray();
            else throw new ArgumentPropertyException(property);

            return users;
        }
    }
}
