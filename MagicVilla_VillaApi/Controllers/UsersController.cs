using MagicVilla_VillaApi.Logging;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.Dto;
using MagicVilla_VillaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_VillaApi.Controllers
{
    [Route("/api/v{version:apiVersion}/UsersAuth")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UsersController(IUserRepository userRepository, ILogging logger) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ILogging _logger = logger;
        protected APIResponse _response = new();

        [HttpPost("login")]
        public async Task<ActionResult<APIResponse>> LogIn([FromBody] LoginRequestDTO loginRequestDTO)
        {
            try
            {
                var loginResponse = await _userRepository.Login(loginRequestDTO);
                if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = ["Invalid username or password"];
                    return _response;
                }
                loginResponse.User.Password = "";
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = loginResponse;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                _logger.Log(ex.ToString(), ex.GetType().ToString());
                _response.IsSuccess = false;
                _response.ErrorMessages = [ex.ToString()];
            }

            return _response;
        }



        [HttpPost("signup")]
        public async Task<ActionResult<APIResponse>> SignUp([FromBody] RegistrationRequestDTO registrationRequestDTO)
        {
            try
            {
                bool ifUserNameUnique = _userRepository.IsUniqueUser(registrationRequestDTO.Username);
                if (!ifUserNameUnique)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = ["Username already exists"];
                    return BadRequest(_response);
                }

                var user = await _userRepository.RegisterNewUser(registrationRequestDTO);
                if (user == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = ["An error occurred while registering user"];
                    return BadRequest(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = user;
                return _response;
            }
            catch (Exception ex)
            {

                _logger.Log(ex.ToString(), ex.GetType().ToString());
                _response.IsSuccess = false;
                _response.ErrorMessages = [ex.ToString()];
            }

            return _response;
        }
    }
}
