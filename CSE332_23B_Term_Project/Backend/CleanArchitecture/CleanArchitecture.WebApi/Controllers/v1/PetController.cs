using CleanArchitecture.Core.Features.Pets.Queries.GetAllPets;
using CleanArchitecture.Core.Wrappers;
using CleanArchitecture.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using CleanArchitecture.Core.Features.Pets.Commands.CreatePet;
using CleanArchitecture.Core.Features.Pets.Queries;

namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController1 : BaseApiController
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
    }
}