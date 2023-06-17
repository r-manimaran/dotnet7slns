using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly AppRepository _appRepository;

        public UsersController(AppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        [HttpGet("{id}")]
       [Authorize("UserPolicy")]
       // [Authorize("AdminPolicy")]
        public IActionResult GetUser(int id)
        {
            var user = _appRepository.GetUser(id);
            return Ok(user);
        }
    }
}
