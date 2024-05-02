using System.Security.Cryptography;
using System.Text;
using NewsWebAppAPI.Models;
using NewsWebAppAPI.ModelView;
using NewsWebAppAPI.Repositories;
using NewsWebAppAPI.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<User> getUserById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> createUser(UserModelView newUser)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> getAllUsers()
    {
        throw new NotImplementedException();
    }

    public async Task<User?> getUserByEmail(string email)
    {
        return await _userRepository.GetUserByEmail(email);
    }
    
    public async Task<User> register(UserModelView newUser)
    {
         var user = new User() 
        {
            Email = newUser.Email,
            HashPassword =HashPassword(newUser.Password),
            UserName = newUser.UserName,
            RoleId = newUser.RoleId,
            DateOfBirth = newUser.DateOfBirth
        };
        if ( await getUserByEmail(user.Email) != null) 
        { 
            throw new Exception("Email đã tồn tại");
        }else
        {
            await _userRepository.CreateUser(user);
            return user;
        }
        
    }
    private string HashPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
 
    public async void login(string email, string password)
    {
        if ( await getUserByEmail(email) != null)
        {
            var user = await getUserByEmail(email);
            if (user.HashPassword == HashPassword(password))
            {
                return;
            }
            else
            {
                throw new Exception("Sai mật khẩu");
            }
        }
        else
        {
            throw new Exception("Email không tồn tại");   
            
        }
    }
}