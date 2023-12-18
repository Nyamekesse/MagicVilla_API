using AutoMapper;
using MagicVilla_VillaApi.Logging;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.Dto;
using MagicVilla_VillaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_VillaApi.Controllers.v1
{
    [Route("/api/v{version:apiVersion}/VillaNumberApi")]
    [ApiController]
    [ApiVersion("1.0")]
    public class VillaNumberAPIController(ILogging logger, IMapper mapper, IVillaNumberRepository dbVillaNumber, IVillaRepository dbVilla) : ControllerBase
    {
        private readonly ILogging _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IVillaNumberRepository _dbVillaNumber = dbVillaNumber;
        protected APIResponse _response = new();
        private readonly IVillaRepository _dbVilla = dbVilla;

        [HttpGet("GetAllVillaNumbers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllVillaNumbers()
        {
            try
            {
                IEnumerable<VillaNumber> villaNumberList = await _dbVillaNumber.GetAllAsync();
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<List<VillaNumber>>(villaNumberList);
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

        [HttpGet("GetString")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<string> Get()
        {
            return new string[] { "string1", "string2" };
        }

        [HttpGet("{id:int}", Name = "GetVillaNumberById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetVillaNumberById(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var villaNumber = await _dbVillaNumber.GetAsync(villaNumber => villaNumber.VillaNo == id);
                if (villaNumber == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return _response;
                }

                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<VillaNumber>(villaNumber);
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateNewVillaNumber([FromBody] VillaNumberCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                if (await _dbVillaNumber.GetAsync(villaNumber => villaNumber.VillaNo == createDTO.VillaNo) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = [$"VillaNumber with the number {createDTO.VillaNo} already Exists!"];
                    _response.IsSuccess = false;
                    return _response;
                }
                if (await _dbVilla.GetAsync(villa => villa.Id == createDTO.VillaId) == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = ["Villa not found"];
                    return _response;
                }
                VillaNumber villaNumber = _mapper.Map<VillaNumber>(createDTO);
                await _dbVillaNumber.CreateAsync(villaNumber);
                _response.Result = villaNumber;
                _response.StatusCode = HttpStatusCode.Created;
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

        [HttpDelete("{id:int}", Name = "DeleteVillaNumberById")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumberById(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = ["Invalid Id"];
                    return _response;
                }

                var villNumberToBeDeleted = await _dbVillaNumber.GetAsync(villaNum => villaNum.VillaNo == id);

                if (villNumberToBeDeleted == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }

                await _dbVillaNumber.RemoveAsync(villNumberToBeDeleted);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
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

        [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> UpdateVillaNumber([FromBody] VillaNumberUpdateDTO updateDTO, int id)
        {
            try
            {
                if (updateDTO.VillaNo != id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = ["Id provided does not match"];
                    return _response;
                }
                if (await _dbVilla.GetAsync(villa => villa.Id == updateDTO.VillaId) == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = ["Villa not found"];
                    return _response;
                }

                VillaNumber modelToUpdate = _mapper.Map<VillaNumber>(updateDTO);
                await _dbVillaNumber.UpdateAsync(modelToUpdate);
                _response.StatusCode = HttpStatusCode.OK;
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
    }
}
