using System;
using NewsWebAppAPI.Models;
using NewsWebAppAPI.ModelView;
using static NewsWebAppAPI.Models.User;

namespace NewsWebAppAPI.Repositories
{
	public interface IUserRepository
	{
        void CreateUser(User newUser);
        User? GetUserById(int id);
        IEnumerable<User>? GetAllUsers();
        bool UserExistsWithPhoneNumber(string phoneNumber);
		bool UserExistsWithEmail(string email);
		User? GetUserByEmail(string email);
    }
}

