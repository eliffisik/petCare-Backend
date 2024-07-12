using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Features.CaretakerInfos.Queries;
using CleanArchitecture.Core.Features.CaretakerInfos.Queries.GetAllCaretakerInfos;
using CleanArchitecture.Core.Features.CaretakerInfos.Queries.GetCaretakerInfoByUserId;
using CleanArchitecture.Core.Features.PetOwnerInfos.Queries;
using CleanArchitecture.Core.Features.PetOwnerInfos.Queries.GetAllPetOwnerInfos;
using CleanArchitecture.Core.Features.PetOwnerInfos.Queries.GetPetOwnerInfoByUserId;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetOwnerInfoController : BaseApiController
    {
        // Endpoint for creating a new caretaker info
        [HttpPost("Post")]
        public async Task<IActionResult> Post(CreatePetOwnerInfoCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        // Endpoint for fetching all caretaker infos with pagination support
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<IEnumerable<GetAllPetOwnerInfosViewModel>>))]
        public async Task<PagedResponse<IEnumerable<GetAllPetOwnerInfosViewModel>>> Get([FromQuery] GetAllPetOwnerInfosParameter filter)
        {
            var query = new GetAllPetOwnerInfosQuery
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber
            };
            var result = await Mediator.Send(query);
            return result;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<PetOwnerInfo>))]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var query = new GetPetOwnerInfoByUserIdQuery { UserId = userId };
            var response = await Mediator.Send(query);
            return Ok(response);
        }

    }
}

