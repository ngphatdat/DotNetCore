using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsWebAppAPI.Models;
using NewsWebAppAPI.ModelView;

namespace NewsWebAppAPI.Repositories
{
	public class UserRepository:IUserRepository
	{
        private readonly Database _context;

        public UserRepository(Database context)
        {
            _context = context;
        }

        public void CreateUser(User newUser)
        {
            _context.User.Add(newUser);
            _context.SaveChanges();
        }
        
        public User? GetUserById(int id)
        {
                return _context.User.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User>? GetAllUsers()
        {
            try
            {
                return _context.User.ToList();
            }
            catch
            {
                return null;
            }
        }
        public bool UserExistsWithPhoneNumber(string phoneNumber)
        {
            return _context.User.Any(user => user.PhoneNumber == phoneNumber);
        }
        public bool UserExistsWithEmail(string email)
        {
            return _context.User.Any(user => user.Email == email);
        }
        public  User? GetUserByEmail(string email)
        {
            return  _context.User.FirstOrDefault(user => user.Email == email);
        }
        
    }
}


