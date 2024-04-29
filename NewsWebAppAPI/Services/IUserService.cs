using System;
using NewsWebAppAPI.Models;
using NewsWebAppAPI.ModelView;
using static NewsWebAppAPI.Models.User;

namespace NewsWebAppAPI.Services
{
    public interface IUserService
    {
        void Register(UserModelView registerModel);
        User? GetUserById(int id);
        IEnumerable<User>? GetAllUsers();
        void Login(string email, string password);
    }
}

