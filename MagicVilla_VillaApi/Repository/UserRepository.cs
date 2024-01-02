using AutoMapper;
using MagicVilla_VillaApi.Data;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.Dto;
using MagicVilla_VillaApi.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace MagicVilla_VillaApi.Repository
{
    public class UserRepository(ApplicationDBContext db, IConfiguration configuration, UserManager<ApplicationUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager) : IUserRepository
    {
        private readonly ApplicationDBContext _db = db;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;
        private readonly IMapper _mapper = mapper;


        private readonly string secretKey = Environment.GetEnvironmentVariable("SECRET");
        public bool IsUniqueUser(string username)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(user => user.UserName == username);
            if (user == null) return true;
            return false;
        }

        public async Task<UserDTO> RegisterNewUser(RegisterationRequestDTO registerationRequestDTO)
        {
            ApplicationUser user = new()
            {
                UserName = registerationRequestDTO.UserName,
                Email = registerationRequestDTO.UserName,
                NormalizedEmail = registerationRequestDTO.UserName.ToUpper(),
                Name = registerationRequestDTO.Name
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registerationRequestDTO.Password);
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
                    {
                        await _roleManager.CreateAsync(new IdentityRole("admin"));
                        await _roleManager.CreateAsync(new IdentityRole("customer"));
                        await _roleManager.CreateAsync(new IdentityRole("user"));
                    }
                    await _userManager.AddToRoleAsync(user, "admin");
                    var userToReturn = _db.ApplicationUsers
                        .FirstOrDefault(user => user.UserName == registerationRequestDTO.UserName);
                    return _mapper.Map<UserDTO>(userToReturn);

                }
            }
            catch (Exception)
            {

                throw;
            }

            return new UserDTO();

        }

        public async Task<TokenDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = await _db.ApplicationUsers.FirstOrDefaultAsync(user => user.UserName == loginRequestDTO.Username);
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
            if (user == null || isValid == false) return new TokenDTO()
            {
                Token = "",

            };

            var roles = await _userManager.GetRolesAsync(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, user.Id.ToString()),
                new(ClaimTypes.Role, roles.FirstOrDefault())
            }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);
            TokenDTO loginResponseDTO = new()
            {
                Token = tokenHandler.WriteToken(token),
            };

            return loginResponseDTO;
        }

        public Task<TokenDTO> RefreshAccessToken(TokenDTO tokenDTO)
        {
            throw new NotImplementedException();
        }
    }
}
