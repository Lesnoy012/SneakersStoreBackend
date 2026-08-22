using Microsoft.AspNetCore.Mvc;

namespace SneakersStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SneakersController : ControllerBase
    {
        [HttpGet]
        public String GetAllSneakers()
        {
            return "Sneakers";
        }
    }
}
