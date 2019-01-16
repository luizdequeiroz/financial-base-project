using BaseProj.Core.Entities;
using System.Threading.Tasks;

namespace BaseProj.Entry
{
    public interface IEntryModule
    {
        Task<bool> UserAutenticatedAsync(User user);

        Task<User> RegisterUserAsync(User user);

        Task DeleteUserAsync(int id);
    }
}