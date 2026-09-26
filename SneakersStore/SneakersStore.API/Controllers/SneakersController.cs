using Microsoft.AspNetCore.Mvc;
using SneakersStore.API.Contracts;
using SneakersStore.Core.Abstractions;
using SneakersStore.Core.Filters;
using SneakersStore.Core.Models;
using SneakersStore.Core.Sort;

namespace SneakersStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SneakersController : ControllerBase
    {
        private readonly ISneakersService _sneakersService;

        public SneakersController(ISneakersService sneakersService)
        {
            _sneakersService = sneakersService;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateSneakers([FromBody] SneakersRequest request)
        {
            var sneakers = Sneakers.Create(Guid.NewGuid(), request.Title, request.Price, request.Img);

            var result = await _sneakersService.CreateSneakers(sneakers);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<SneakersResponse>>> GetSneakers(
            [FromQuery] SneakersFilterRequest filterRequest,
            [FromQuery] SneakersSortRequest sortRequest)
        {
            var filter = new SneakersFilter(filterRequest.Title);

            var sort = new SneakersSort(sortRequest.SortBy, sortRequest.SortDirection);

            var sneakers = await _sneakersService.GetAllSneakers(filter, sort);

            var result = sneakers.Select(s => new SneakersResponse(
                s.Id,
                s.Title,
                s.Price,
                s.Img
            )).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SneakersResponse>> GetSneakersById(Guid id)
        {
            var sneakers = await _sneakersService.GetSneakersById(id);

            var result = new SneakersResponse(sneakers.Id, sneakers.Title, sneakers.Price, sneakers.Img);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<Guid>> DeleteSneakersById([FromQuery] Guid id)
        {
            var result = await _sneakersService.DeleteSneakersById(id);

            return Ok(result);
        }
    }
}
