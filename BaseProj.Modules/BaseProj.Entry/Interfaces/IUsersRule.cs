﻿using BaseProj.Core.Entities;
using System.Threading.Tasks;

namespace BaseProj.Entry.Interfaces
{
    public partial interface IEntryModule
    {
        Task<bool> UserAutenticatedAsync(User user);

        Task<User> RegisterUserAsync(User user);

        Task DeleteUserAsync(int id);

        Task<User[]> ListUsersAsync(int quantity);

        Task<User> UpdateUserAsync(int id, User user);

        Task<User> GetUserByIdAsync(int id);

        Task<User[]> GetUsersByPropertyAsync(string property, object value);
    }
}