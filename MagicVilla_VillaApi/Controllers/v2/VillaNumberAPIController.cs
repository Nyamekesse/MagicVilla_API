using MagicVilla_VillaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaApi.Controllers.v2
{
    [Route("/api/v{version:apiVersion}/VillaNumberApi")]
    [ApiController]
    [ApiVersion("2.0")]
    public class VillaNumberAPIController() : ControllerBase
    {

        protected APIResponse _response = new();


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


    }
}
