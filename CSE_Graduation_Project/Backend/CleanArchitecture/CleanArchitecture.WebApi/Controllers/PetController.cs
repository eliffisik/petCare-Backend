using CleanArchitecture.Core.Features.Pets.Queries.GetAllPets;
using CleanArchitecture.Core.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using CleanArchitecture.Core.Features.Pets.Commands.CreatePet;
using CleanArchitecture.Core.Features.Pets.Queries;
using CleanArchitecture.Core.Features.Messages.Queries;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Features.CaretakerInfos.Queries.GetCaretakerInfoByUserId;
using CleanArchitecture.Core.Features.Pets.Queries.GetPetsByUserIdQuery;

namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : BaseApiController
    {
        [HttpPost("Post")]
        public async Task<IActionResult> Post(CreatePetCommand command)
        {

            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<IEnumerable<GetAllPetsViewModel>>))]
        public async Task<PagedResponse<IEnumerable<GetAllPetsViewModel>>> Get([FromQuery] GetAllPetsParameter filter)
        {
            return await Mediator.Send(new GetAllPetsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber });
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<Pet>))]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var query = new GetPetsByUserIdQuery { UserId = userId };
            var response = await Mediator.Send(query);
            return Ok(response);
        }

    }
}