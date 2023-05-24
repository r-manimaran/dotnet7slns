using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ObjectMappings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("new-person")]
        public IActionResult GetNewPerson()
        {
            var person = MappingFun.MapPersonToNewDto();
            return Ok(person);
        }


    }
}
