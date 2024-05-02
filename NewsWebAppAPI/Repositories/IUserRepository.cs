using System;
using NewsWebAppAPI.Models;
using NewsWebAppAPI.ModelView;
using static NewsWebAppAPI.Models.User;

namespace NewsWebAppAPI.Repositories
{
	public interface IUserRepository
	{
        Task<User> CreateUser(User newUser);
        Task<User?> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
		bool UserExistsWithEmail(string email);
		Task<User?> GetUserByEmail(string email);
    }
}

