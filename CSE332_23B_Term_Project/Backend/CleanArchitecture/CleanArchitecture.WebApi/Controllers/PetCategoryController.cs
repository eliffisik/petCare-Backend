using CleanArchitecture.Core.Features.PetCategories.Queries.GetAllPetCategories;
using CleanArchitecture.Core.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;



using CleanArchitecture.Core.Features.PetCategories.Queries;
using CleanArchitecture.Core.Features.Pets.Commands.CreatePetCategory;

namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetCategoryController : BaseApiController
    {
        [HttpPost("Post")]
        public async Task<IActionResult> Post(CreatePetCategoryCommand command)
        {

            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<IEnumerable<GetAllPetCategoriesViewModel>>))]
        public async Task<PagedResponse<IEnumerable<GetAllPetCategoriesViewModel>>> Get([FromQuery] GetAllPetCategoriesParameter filter)
        {
            return await Mediator.Send(new GetAllPetCategoriesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber });
        }
    }
}