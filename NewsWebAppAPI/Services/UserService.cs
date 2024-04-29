using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NewsWebAppAPI.Models;
using NewsWebAppAPI.ModelView;
using NewsWebAppAPI.Repositories;
using static NewsWebAppAPI.Models.User;

namespace NewsWebAppAPI.Services
{
	public class UserService:IUserService
	{
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Login(string email, string password)
        {
            User? user = _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new Exception("Email không tồn tại");
            }
            if (!VerifyPassword(password, user.HashPassword))
            {
                throw new Exception("Mật khẩu không đúng");
            }
            if (user == null)
            {
                throw new Exception("Email không tồn tại");
            }
           // return GenerateJwtToken(user);
        }
        public  void Register(UserModelView registerModel)
        {
            if (UserExistsWithPhoneNumber(registerModel.PhoneNumber))
            {
                throw new Exception("Số điện thoại đã tồn tại");
            }
            if (UserExistsWithEmail(registerModel.Email))
            {
                throw new Exception("Email đã tồn tại");
            }
            User user = new User
            {
                Email = registerModel.Email,
                FullName = registerModel.FullName,
                PhoneNumber = registerModel.PhoneNumber,
                HashPassword = HashPassword(registerModel.Password),
                Address = registerModel.Address,
              //  Active = true,
                DateOfBirth = registerModel.DateOfBirth,
                CreatedAt = DateTime.Now
            };
            _userRepository.CreateUser(user);
        }
        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("nguyen_phat_dat"); // Replace with your secret key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
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

        private bool VerifyPassword(string password, string hashPassword)
        {
            string hashOfInput = HashPassword(password);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, hashPassword) == 0;
        }
        

        public User? GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public  IEnumerable<User>? GetAllUsers()
        {
            return  _userRepository.GetAllUsers();
        }
        private  bool UserExistsWithPhoneNumber(string phoneNumber)
        {
            return _userRepository.UserExistsWithPhoneNumber(phoneNumber);
        }
        private  bool UserExistsWithEmail(string email)
        {
            return _userRepository.UserExistsWithEmail(email);
        }
    }
}

