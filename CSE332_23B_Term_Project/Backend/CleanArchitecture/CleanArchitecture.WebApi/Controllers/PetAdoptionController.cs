
using CleanArchitecture.Core.Features.PetAdoptions.Commands.CreatePetAdoption;
using CleanArchitecture.Core.Features.PetAdoptions.Queries;
using CleanArchitecture.Core.Features.PetAdoptions.Queries.GetAllPetAdoptions;
using CleanArchitecture.Core.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetAdoptionController : BaseApiController
    {
        [HttpPost("Post")]
        public async Task<IActionResult> Post(CreatePetAdoptionCommand command)
        {

            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<IEnumerable<GetAllPetAdoptionsViewModel>>))]
        public async Task<PagedResponse<IEnumerable<GetAllPetAdoptionsViewModel>>> Get([FromQuery] GetAllPetAdoptionsParameter filter)
        {
            return await Mediator.Send(new GetAllPetAdoptionsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber });
        }
    }
}