using Microsoft.AspNetCore.Mvc;
using SneakersStoreAuth.API.Contracts;

namespace SneakersStoreAuth.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> Register(UserRegisterRequest userRegisterRequest)
        {
            return Ok("Зарегался");
        }

        [HttpPost]
        public ActionResult<string> Login(UserRegisterRequest userRegisterRequest)
        {
            return Ok("Залогинился");
        }
    }
}
