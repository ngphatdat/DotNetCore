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

        public async Task<User> CreateUser(User newUser)
        {
            _context.User.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
        
        public async Task<User?> GetUserById(int id)
        {   
                return await _context.User.FirstOrDefaultAsync(u => u.Id == id);
        }
         public  async Task<User?> GetUserByEmail(string email)
                {
                    return await _context.User.FirstOrDefaultAsync(user => user.Email == email);
                }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.User.ToListAsync();
        }
        public bool UserExistsWithEmail(string email)
        {
            return _context.User.Any(user => user.Email == email);
        }
       
        
    }
}


