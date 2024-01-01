using MagicVilla_VillaApi.Models.Dto;

namespace MagicVilla_VillaApi.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<TokenDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> RegisterNewUser(RegisterationRequestDTO registrationRequestDTO);
    }
}
