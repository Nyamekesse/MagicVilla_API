using MagicVilla_VillaApi.Data;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.Dto;
using MagicVilla_VillaApi.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace MagicVilla_VillaApi.Repository
{
    public class UserRepository(ApplicationDBContext db, IConfiguration configuration) : IUserRepository
    {
        private readonly ApplicationDBContext _db = db;
        private readonly string secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        public bool IsUniqueUser(string username)
        {
            var user = _db.LocalUsers.FirstOrDefault(user => user.Username == username);
            if (user == null) return true;
            return false;
        }

        public async Task<LocalUser> Registration(RegistrationRequestDTO registrationRequestDTO)
        {
            LocalUser user = new()
            {
                Username = registrationRequestDTO.Username,
                Password = registrationRequestDTO.Password,
                Name = registrationRequestDTO.Name,
                Role = registrationRequestDTO.Role,
            };

            await _db.LocalUsers.AddAsync(user);
            await _db.SaveChangesAsync();
            user.Password = "";
            return user;

        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _db.LocalUsers.FirstOrDefault(user => user.Username == loginRequestDTO.Username && user.Password == loginRequestDTO.Password);
            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, user.Id.ToString()),
                new(ClaimTypes.Role, user.Role)
            }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponseDTO = new()
            {
                Token = tokenHandler.WriteToken(token),
                User = user,
            };

            return loginResponseDTO;
        }
    }
}
