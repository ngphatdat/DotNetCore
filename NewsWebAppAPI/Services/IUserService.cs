using System;
using NewsWebAppAPI.Models;
using NewsWebAppAPI.ModelView;
using static NewsWebAppAPI.Models.User;

namespace NewsWebAppAPI.Services
{
    public interface IUserService
    {
        Task<User> getUserById(int id);
        Task<User> createUser(UserModelView newUser);
        Task<IEnumerable<User>> getAllUsers();
        Task<User?> getUserByEmail(string email);
        Task<User> register(UserModelView newUser);

    }
}

